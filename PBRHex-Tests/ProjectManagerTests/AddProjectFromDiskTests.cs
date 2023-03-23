using PBRHex.Core;
using PBRHex_Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerTests
{
    [TestClass]
    public class AddProjectFromDiskTests
    {
        [TestMethod]
        public void PathIsValidProject_AddsToProjectList() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            ProjectManager.InitializeProject(tempDir, name);
            ProjectManager.RemoveProject(tempDir);

            try {
                // Act
                ProjectManager.AddProjectFromDisk(tempDir);

                // Assert
                var matches = ProjectManager.Projects.Where(proj => proj.Path == tempDir);

                Assert.IsTrue(matches.Count() == 1);
                Assert.IsTrue(matches.First().Name == name);
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProjectException))]
        public void PathIsNotValidProject_ThrowsException() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();

            Directory.CreateDirectory(tempDir);

            try {
                // Act
                ProjectManager.AddProjectFromDisk(tempDir);

                // Assert
                // Succeeds if appropriate exception is thrown
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ProjectAlreadyOnList_NoExceptionThrown() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            ProjectManager.InitializeProject(tempDir, name);

            try {
                // Act
                ProjectManager.AddProjectFromDisk(tempDir);

                // Assert
                // Succeeds if no exception is thrown
            }
            finally {
                Directory.Delete(tempDir, true);
                ProjectManager.RemoveProject(tempDir);
            }
        }
    }
}
