using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PBRHex.Core
{
    public class Project
    {
        internal const string ProjectFilePath = "project";

        private readonly ProjectInfo Metadata;

        public string Name => Metadata.Name;
        public string Path => Metadata.Path;

        internal Project(string path) {
            Trace.Assert(System.IO.Path.IsPathFullyQualified(path));

            try {
                Metadata = LoadProjectInfo(path);
            }
            catch {
                throw new InvalidProjectException();
            }
        }

        private static ProjectInfo LoadProjectInfo(string projectPath) {
            string projectFilePath = System.IO.Path.Combine(projectPath, ProjectFilePath);

            string json = File.ReadAllText(projectFilePath);
            ProjectInfo metadata = JsonSerializer.Deserialize<ProjectInfo>(json);
            metadata.Path = projectPath;

            return metadata;
        }
    }

    public struct ProjectInfo
    {
        [JsonInclude]
        public string Name { get; internal set; }
        [JsonIgnore]
        public string Path { get; internal set; }
    }
}
