using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBRHex.Core.IO;

namespace PBRHex.Core
{
    internal class ProjectList
    {
        private List<Project> Projects = new();

        private readonly object accessLock = new();

        private readonly FileInfo fileInfo;

        private string Path => fileInfo.GetPath();

        internal ProjectList(FileInfo file) {
            fileInfo = file;

            if (!fileInfo.Exists) {
                fileInfo.Create().Close();
            }

            LoadList();
        }

        private void LoadList() {
            lock (accessLock) {
                string[] paths = File.ReadAllLines(Path);

                Projects = new();
                foreach (string path in paths) {
                    DirectoryInfo directory = new(path);

                    try {
                        Project project = new(directory);
                        Projects.Add(project);
                    }
                    catch (InvalidProjectException) {
                        Debug.WriteLine($"Invalid project on project list: {path}");
                    }
                }
            }
        }

        private void WriteList() {
            lock (accessLock) {
                using StreamWriter file = new(Path);

                foreach (Project project in Projects) {
                    file.WriteLine(project.Path);
                }
            }
        }

        public void Add(Project project) {
            // Keep from adding the same project twice
            if (Projects.Any(p => p.ID == project.ID))
                return;

            Projects.Add(project);

            WriteList();
        }

        public void Remove(Project project) {
            Project? match = Projects.Find(p => p.ID == project.ID);

            if (match is null)
                return;

            Projects.Remove(match);

            WriteList();
        }

        public Project[] GetList() {
            return Projects.ToArray();
        }
    }
}
