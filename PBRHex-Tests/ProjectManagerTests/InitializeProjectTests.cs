using PBRHex.Core;
using PBRHex_Tests;
using System.Xml.Linq;

namespace ProjectManagerTests
{
    [TestClass]
    public class InitializeProjectTests
    {
        [TestMethod]
        public void DirectoryDoesNotExist_CreatesProject() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            try {
                // Act
                ProjectManager.InitializeProject(tempDir, name);

                // Assert
                Project project = ProjectManager.GetProject(tempDir);
                Assert.IsTrue(project.Name == name);
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void DirectoryExistsAndIsEmpty_CreatesProject() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            Directory.CreateDirectory(tempDir);

            string name = "Test";

            try {
                // Act
                ProjectManager.InitializeProject(tempDir, name);

                // Assert
                Project project = ProjectManager.GetProject(tempDir);
                Assert.IsTrue(project.Name == name);
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void DirectoryExistsAndIsNotEmpty_ThrowsIOException() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            Directory.CreateDirectory(tempDir);
            TestUtils.CreateEmptyFile(tempDir);

            string name = "Test";

            try {
                // Act
                ProjectManager.InitializeProject(tempDir, name);

                // Assert
                // Succeeds if appropriate exception is thrown
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ProjectAddedToProjectList() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            try {
                // Act
                ProjectManager.InitializeProject(tempDir, name);

                // Assert
                var matches = ProjectManager.Projects.Where(proj => proj.Path == tempDir);

                Assert.IsTrue(matches.Count() == 1);
                Assert.IsTrue(matches.First().Name == name);
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }
    }
}
