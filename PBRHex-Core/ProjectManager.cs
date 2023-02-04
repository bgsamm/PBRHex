using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PBRHex.Core
{
    public class ProjectManager
    {
        /// <summary>
        /// Initializes a new project in the given directory. If the directory does not exist,
        /// it will be created. If it does exist, it must be empty.
        /// </summary>
        /// <param name="name">The new project's name</param>
        /// <param name="path">The directory in which to place the project</param>
        public static void CreateProject(string name, string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            Debug.Assert(Directory.GetFiles(path).Length == 0);

            Project project = new(name);
            string json = JsonSerializer.Serialize(project);

            Console.WriteLine(json);
        }

        public static void DeleteProject(string name) {

        }

        public static void RenameProject(string name, string newName) {

        }
    }
}
