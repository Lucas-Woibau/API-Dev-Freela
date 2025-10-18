using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.UnitTests.Helpers;
using FluentAssertions;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectIsCreated_Start_Success()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();

            // Act
            project.Start();

            // Assert
            Assert.Equal(ProjectsStatusEnum.InProgress, project.Status);

            // Fluent Assertions
            project.Status.Should().Be(ProjectsStatusEnum.InProgress);

            Assert.NotNull(project.StartedAt);

            // Fluent Assertions
            project.StartedAt.Should().NotBeNull();

            Assert.True(project.Status == ProjectsStatusEnum.InProgress);
            Assert.False(project.StartedAt is null);
        }

        [Fact]
        public void PublicIsInavalidState_Start_ThrowsException()
        {
            // Arrange
            var project = FakeDataHelper.CreateFakeProject();
            project.Start();

            // Act + Assert
            Action? start = project.Start;

            var exception = Assert.Throws<InvalidOperationException>(start);
            Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);

            // Fluent Assertions
            start.Should()
                .Throw<InvalidOperationException>()
                .WithMessage(Project.INVALID_STATE_MESSAGE);
        }
    }
}
