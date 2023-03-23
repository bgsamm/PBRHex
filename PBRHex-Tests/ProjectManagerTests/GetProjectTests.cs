using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PBRHex.Core;
using PBRHex_Tests;

namespace ProjectManagerTests
{
    [TestClass]
    public class GetProjectTests
    {
        [TestMethod]
        public void PathIsValidProject_ReturnsProject() {
            // Arrange
            string tempDir = TestUtils.GetTempDirectory();
            string name = "Test";

            ProjectManager.InitializeProject(tempDir, name);

            try {
                // Act
                Project project = ProjectManager.GetProject(tempDir);

                // Assert
                Assert.IsTrue(project.Name == name);
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
                Project project = ProjectManager.GetProject(tempDir);

                // Assert
                // Succeeeds if appropriate exception is thrown
            }
            finally {
                Directory.Delete(tempDir, true);
            }
        }
    }
}
