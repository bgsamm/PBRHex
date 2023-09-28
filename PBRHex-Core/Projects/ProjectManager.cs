using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PBRHex.Core.IO;

namespace PBRHex.Core.Projects
{
    /*
     * This class provides the public interface for creating new
     * projects on disk.
     * 
     * This class is also responsible for maintaining a list of known
     * projects. It provides the public interface for manually adding
     * and removing existing projects to and from the list as well.
     * 
     * This class does NOT provide for loading ISOs into projects,
     * renaming projects, or any other project-specific functions. See,
     * instead, the Project class.
     * 
     * This class should not expose any details of the project list's
     * implementation, such as the location, format, or even existence
     * of the project list file.
     */
    public static class ProjectManager
    {
        private static string ProjectListPath => Path.Combine(Application.DataPath, "projects");

        static ProjectManager() {
            FileInfo projectListFile = new(ProjectListPath);

            if (!projectListFile.Exists) {
                projectListFile.Create().Close();
            }

            CleanProjectList();
        }

        private static void CleanProjectList() {
            List<Project> projectList = LoadProjectList();
            WriteProjectList(projectList);
        }

        public static IReadOnlyList<Project> GetProjectList() {
            List<Project> projectList = LoadProjectList();
            return projectList;
        }

        /// <summary>
        /// <para>
        ///     Pre-conditions:
        ///     <br>- name is not an empty string</br>
        /// </para>
        /// <para>
        ///     Notes:
        ///     <br>- If directory exists, must be empty</br>
        /// </para>
        /// </summary>
        /// <exception cref="DirectoryNotEmptyException"></exception>
        public static void InitializeProject(string name, DirectoryInfo directory) {
            Trace.Assert(name.Length > 0);

            if (directory.Exists && directory.GetFiles().Length > 0) {
                string path = directory.GetPath();
                throw new DirectoryNotEmptyException($"Cannot initialize project in '{path}' - directory is not empty");
            }

            if (!directory.Exists) {
                directory.Create();
            }

            ProjectInfo projectInfo = new()
            {
                Name = name,
            };

            Project project = Project.CreateProject(projectInfo, directory);
            AddToList(project);
        }

        public static Project GetProjectFromDirectory(DirectoryInfo directory) {
            Project project = Project.LoadProject(directory);
            return project;
        }

        /// <summary>
        /// <para>
        ///     Notes:
        ///     <br>- Succeeds even if the project is already on the project list</br>
        /// </para>
        /// </summary>
        /// <param name="project"></param>
        public static void AddProjectToList(Project project) {
            AddToList(project);
        }

        /// <summary>
        /// <para>
        ///     Notes:
        ///     <br>- Succeeds even if the project is not currently on the project list</br>
        ///     <br>- Does NOT delete the project's files from disk</br>
        /// </para>
        /// </summary>
        public static void RemoveProjectFromList(Project project) {
            RemoveFromList(project);
        }

        private static void AddToList(Project project) {
            DirectoryInfo projectDir = new(project.Location);

            List<Project> projectList = LoadProjectList();

            // Keep from adding the same project twice
            if (projectList.Any(proj => projectDir.PathEquals(proj.Location)))
                return;

            projectList.Add(project);
            WriteProjectList(projectList);
        }

        private static void RemoveFromList(Project project) {
            DirectoryInfo projectDir = new(project.Location);

            List<Project> projectList = LoadProjectList();
            Project? match = projectList.Find(proj => projectDir.PathEquals(proj.Location));

            if (match is null)
                return;

            projectList.Remove(match);
            WriteProjectList(projectList);
        }

        /// <summary>
        /// <para>
        ///     Notes:
        ///     <br>- Automatically filters out duplicate and invalid projects from the list</br>
        /// </para>
        /// </summary>
        private static List<Project> LoadProjectList() {
            string[] projectPaths = File.ReadAllLines(ProjectListPath);

            List<Project> projects = new();
            foreach (string path in projectPaths) {
                DirectoryInfo directory = new(path);

                if (projects.Any(proj => directory.PathEquals(proj.Location))) {
                    Debug.WriteLine($"Duplicate project on project list: {path}");
                    continue;
                }

                try {
                    Project project = Project.LoadProject(directory);
                    projects.Add(project);
                }
                catch (InvalidProjectException) {
                    Debug.WriteLine($"Invalid project on project list: {path}");
                }
            }

            return projects;
        }

        private static void WriteProjectList(IEnumerable<Project> projects) {
            using StreamWriter file = new(ProjectListPath, false);

            foreach (Project project in projects) {
                file.WriteLine(project.Location);
            }
        }
    }
}
