using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.Core
{
    internal class ProjectList
    {
        private List<Project> Projects = new();

        private readonly string filePath;

        private readonly object accessLock = new();

        internal ProjectList(string filePath) {
            Trace.Assert(Path.IsPathFullyQualified(filePath));

            this.filePath = filePath;

            if (!File.Exists(filePath)) {
                File.Create(filePath).Close();
            }

            LoadList();
        }

        private void LoadList() {
            lock (accessLock) {
                string[] paths = File.ReadAllLines(filePath);

                Projects = new();
                foreach (string path in paths) {
                    try {
                        Project project = new(path);
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
                using StreamWriter file = new(filePath);

                foreach (Project project in Projects) {
                    file.WriteLine(project.Path);
                }
            }
        }

        public void Add(string path) {
            Trace.Assert(Path.IsPathFullyQualified(path));

            // Keep from adding the same project twice
            if (Projects.Any(p => p.Path == path)) {
                return;
            }

            Project project = new(path);

            Projects.Add(project);

            WriteList();
        }

        public void Remove(string path) {
            Trace.Assert(Path.IsPathFullyQualified(path));

            Project? project = Projects.Find(p => p.Path == path);

            if (project is null)
                return;

            Projects.Remove(project);

            WriteList();
        }

        public Project[] GetList() {
            return Projects.ToArray();
        }
    }
}
