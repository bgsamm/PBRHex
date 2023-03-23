using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBRHex.Core;
using PBRHex_Tests;

namespace ProjectManagerTests
{
    [TestClass]
    public class RemoveProjectTests
    {
        [TestMethod]
        public void PathIsInList_RemovesFromProjectList() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            ProjectManager.InitializeProject(tempDir, name);

            try {
                // Act
                ProjectManager.RemoveProject(tempDir);

                // Assert
                Assert.IsFalse(ProjectManager.Projects.Any(proj => proj.Path == tempDir));
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ProjectAlreadyRemoved_NoExceptionThrown() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            ProjectManager.InitializeProject(tempDir, name);
            ProjectManager.RemoveProject(tempDir);

            try {
                // Act
                ProjectManager.RemoveProject(tempDir);

                // Assert
                // Succeeds if no exception is thrown
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ProjectRemainsOnDisk() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            ProjectManager.InitializeProject(tempDir, name);

            try {
                // Act
                ProjectManager.RemoveProject(tempDir);

                // Assert
                ProjectManager.AddProjectFromDisk(tempDir);
                // Succeeds if no exception is thrown
            }
            finally {
                Directory.Delete(tempDir, true);
                ProjectManager.RemoveProject(tempDir);
            }
        }
    }
}
