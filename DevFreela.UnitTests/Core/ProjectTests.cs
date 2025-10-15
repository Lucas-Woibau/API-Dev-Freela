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
    }
}
