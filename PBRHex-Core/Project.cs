using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PBRHex.Core.IO;

namespace PBRHex.Core
{
    public class Project
    {
        private const string ProjectFileName = "project";

        private readonly ProjectInfo Metadata;

        internal Guid ID => Metadata.ID;

        public string Name => Metadata.Name;
        public string Path => Metadata.Path;

        internal Project(DirectoryInfo directory) {
            try {
                Metadata = LoadProjectInfo(directory);
            }
            catch {
                throw new InvalidProjectException();
            }
        }

        internal static string GetProjectFilePath(DirectoryInfo projectDirectory) {
            string path = projectDirectory.GetPath();

            return System.IO.Path.Combine(path, ProjectFileName);
        }

        private static ProjectInfo LoadProjectInfo(DirectoryInfo directory) {
            string projectFilePath = GetProjectFilePath(directory);

            string json = File.ReadAllText(projectFilePath);
            ProjectInfo metadata = JsonSerializer.Deserialize<ProjectInfo>(json);
            metadata.Path = directory.GetPath();

            return metadata;
        }
    }

    internal struct ProjectInfo
    {
        [JsonInclude]
        public Guid ID { get; internal init; }
        [JsonInclude]
        public string Name { get; internal init; }
        [JsonIgnore]
        public string Path { get; internal set; }
    }
}
