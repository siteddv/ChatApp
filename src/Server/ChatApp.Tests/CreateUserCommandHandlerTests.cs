using ChatApp.Application.Mediatr.Commands;
using ChatApp.Domain.Entities;
using Moq;

namespace ChatApp.Tests;

public class CreateUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateUser()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.AddAsync(It.IsAny<User>()))
            .Verifiable();

        var handler = new CreateUserCommandHandler(mockRepo.Object);
        var command = new CreateUserCommand { Nickname = "TestUser" };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepo.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once());
    }
}