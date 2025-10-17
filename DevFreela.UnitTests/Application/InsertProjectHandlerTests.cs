using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using Moq;
using NSubstitute;

namespace DevFreela.UnitTests.Application
{
    public class InsertProjectHandlerTests
    {
        [Fact]
        public async Task InputDataAreOk_Isert_Success_NSubstitute()
        {
            // Arrange
            const int ID = 1;

            var repository = Substitute.For<IProjectRepository>();
            repository.Add(Arg.Any<Project>()).Returns(Task.FromResult(ID));

            var command = new InsertProjectCommand
            {
                Title = "Projeto A",
                Description = "Descricao do Projeto",
                TotalCost = 20000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);
            await repository.Received(1).Add(Arg.Any<Project>());
        }

        [Fact]
        public async Task InputDataAreOk_Isert_Success_Moq()
        {
            // Arrange
            const int ID = 1;

            // Outro jeito de fazer
            //var mock = new Mock<IProjectRepository>();
            //mock.Setup(r => r.Add(It.IsAny<Project>())).ReturnsAsync(ID);

            var repository =
                Mock.Of<IProjectRepository>(r => r.Add(It.IsAny<Project>()) == Task.FromResult(ID));

            var command = new InsertProjectCommand
            {
                Title = "Projeto A",
                Description = "Descricao do Projeto",
                TotalCost = 20000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var handler = new InsertProjectHandler(repository);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);

            //mock.Verify(m => m.Add(It.IsAny<Project>()), Times.Once());

            Mock.Get(repository).Verify(m => m.Add(It.IsAny<Project>()), Times.Once());
        }
    }
}
