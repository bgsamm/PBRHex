using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PBRHex.Core
{
    public static class ProjectManager
    {
        public static Project[] Projects => projectList.GetList();

        private static readonly ProjectList projectList;

        private static string ProjectListPath => Path.Combine(Application.DataPath, "projects");

        static ProjectManager() {
            projectList = new ProjectList(ProjectListPath);
        }

        /// <summary>
        /// <para>
        ///     Initializes a new project in the given directory. If the directory
        ///     does not exist, it is created. If it exists, it must be empty.
        /// </para>
        /// <para>
        ///     Pre-condition(s):
        ///     <br>-path is fully qualified</br>
        /// </para>
        /// <para>
        ///     Post-condition(s):
        ///     <br>-path contains the newly created project</br>
        ///     <br>-project is added to the project list</br>
        /// </para>
        /// </summary>
        /// <param name="path">The directory in which to place the project</param>
        /// <param name="name">The new project's name</param>
        /// <exception cref="IOException"></exception>
        public static void InitializeProject(string path, string name) {
            Trace.Assert(Path.IsPathFullyQualified(path));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (Directory.GetFiles(path).Length > 0)
                throw new IOException("Directory was not empty when initializing project");

            ProjectInfo projectInfo = new()
            {
                Name = name,
                Path = path,
            };

            string projectFilePath = Path.Combine(path, Project.ProjectFilePath);

            string json = JsonSerializer.Serialize(projectInfo);
            File.WriteAllText(projectFilePath, json);

            projectList.Add(path);
        }

        /// <summary>
        /// <para>
        ///     Creates a Project object for the project at the given path.
        /// </para>
        /// <para>
        ///     Pre-condition(s):
        ///     <br>-path is fully qualified</br>
        /// </para>
        /// </summary>
        /// <param name="path">The path to the project's directory</param>
        /// <returns></returns>
        /// <exception cref="InvalidProjectException"></exception>
        public static Project GetProject(string path) {
            Trace.Assert(Path.IsPathFullyQualified(path));

            Project project = new(path);

            return project;
        }

        /// <summary>
        /// <para>
        ///     Removes a project from the application's project list.
        /// </para>
        /// <para>
        ///     Pre-condition(s):
        ///     <br>-path is fully qualified</br>
        /// </para>
        /// <para>
        ///     Post-condition(s):
        ///     <br>-project is removed from the project list</br>
        /// </para>
        /// </summary>
        /// <param name="path">The path of the project to remove</param>
        public static void RemoveProject(string path) {
            Trace.Assert(Path.IsPathFullyQualified(path));

            projectList.Remove(path);
        }

        /// <summary>
        /// <para>
        ///     Adds a project from disk to the project list.
        /// </para>
        /// <para>
        ///     Pre-condition(s):
        ///     <br>-path is fully qualified</br>
        /// </para>
        /// <para>
        ///     Pos-condition(s):
        ///     <br>-project is added to the project list</br>
        /// </para>
        /// </summary>
        /// <param name="path">The path to the project to be added</param>
        /// <exception cref="InvalidProjectException"></exception>
        public static void AddProjectFromDisk(string path) {
            Trace.Assert(Path.IsPathFullyQualified(path));

            projectList.Add(path);
        }
    }

    public class InvalidProjectException : Exception { }
}
