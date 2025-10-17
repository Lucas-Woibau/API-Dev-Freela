using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectIsCreated_Start_Success()
        {
            //Arrange
            var project = new Project("Projeto A", "Desccricao", 1, 2, 1000);

            //Act
            project.Start();

            //Assert
            Assert.Equal(ProjectsStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            Assert.True(project.Status == ProjectsStatusEnum.InProgress);
            Assert.False(project.StartedAt is null);
        }

        [Fact]
        public void PublicIsInavalidState_Start_ThrowsException()
        {
            //Arrange
            var project = new Project("Projeto B", "Desccricao2", 2, 1, 2000);
            project.Start();

            //Act + Assert
            Action? start = project.Start;

            var exception = Assert.Throws<InvalidOperationException>(start);
            Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);
        }
    }
}
