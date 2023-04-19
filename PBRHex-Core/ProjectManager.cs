using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PBRHex.Core.IO;

namespace PBRHex.Core
{
    public static class ProjectManager
    {
        public static Project[] Projects => projectList.GetList();

        private static readonly ProjectList projectList;

        private static string ProjectListPath => Path.Combine(Application.DataPath, "projects");

        static ProjectManager() {
            FileInfo projectListFile = new(ProjectListPath);
            projectList = new ProjectList(projectListFile);
        }

        /// <summary>
        /// <para>
        ///     Initializes a new project in the given directory. If the directory
        ///     does not exist, it is created. If it exists, it must be empty.
        /// </para>
        /// <para>
        ///     Post-condition(s):
        ///     <br>-directory contains the newly created project</br>
        ///     <br>-project is added to the project list</br>
        /// </para>
        /// </summary>
        /// <param name="name">The new project's name</param>
        /// <param name="path">The directory in which to place the project</param>
        /// <exception cref="IOException"></exception>
        public static void InitializeProject(string name, DirectoryInfo directory) {
            string path = directory.GetPath();

            if (directory.Exists && directory.GetFiles().Length > 0)
                throw new IOException($"Cannot initialize project in '{path}' - directory is not empty");

            if (!directory.Exists)
                directory.Create();

            ProjectInfo projectInfo = new()
            {
                ID = Guid.NewGuid(),
                Name = name,
                Path = path
            };

            string projectFilePath = Project.GetProjectFilePath(directory);
            string json = JsonSerializer.Serialize(projectInfo);
            File.WriteAllText(projectFilePath, json);

            Project project = new(directory);
            projectList.Add(project);
        }

        /// <summary>
        /// <para>
        ///     Creates a Project object for the project at the given path.
        /// </para>
        /// </summary>
        /// <param name="path">The path to the project's directory</param>
        /// <returns></returns>
        /// <exception cref="InvalidProjectException"></exception>
        public static Project GetProject(DirectoryInfo directory) {
            Project project = new(directory);

            return project;
        }

        /// <summary>
        /// <para>
        ///     Adds a project from disk to the project list.
        /// </para>
        /// <para>
        ///     Post-condition(s):
        ///     <br>-project is added to the project list</br>
        /// </para>
        /// </summary>
        /// <param name="path">The path to the project to be added</param>
        /// <exception cref="InvalidProjectException"></exception>
        public static Project AddProjectFromDisk(DirectoryInfo directory) {
            Project project = new(directory);
            projectList.Add(project);

            return project;
        }

        /// <summary>
        /// <para>
        ///     Removes a project from the application's project list.
        /// </para>
        /// <para>
        ///     Post-condition(s):
        ///     <br>-project is removed from the project list</br>
        /// </para>
        /// </summary>
        /// <param name="path">The path of the project to remove</param>
        /// <exception cref="InvalidProjectException"></exception>
        public static void RemoveProject(DirectoryInfo directory) {
            Project project = new(directory);
            projectList.Remove(project);
        }
    }

    public class InvalidProjectException : Exception { }
}
