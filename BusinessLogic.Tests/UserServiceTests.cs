using Moq;
using Domain.Interfaces;
using Domain.Models;
using BusinessLogic.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLogic.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _mockRepo;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockRepo = new Mock<IRepositoryWrapper>();
            
            // Настройка моков для User репозитория через IRepositoryWrapper
            _mockRepo.Setup(x => x.User.FindAllAsync()).ReturnsAsync(new List<User>());
            _mockRepo.Setup(x => x.User.FindByConditionAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
                     .ReturnsAsync(new List<User>());
            _mockRepo.Setup(x => x.User.CreateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _mockRepo.Setup(x => x.User.UpdateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _mockRepo.Setup(x => x.User.DeleteAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _mockRepo.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);
            
            _userService = new UserService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnUsers_WhenUsersExist()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", PasswordHash = "hash1", Role = "admin" },
                new User { Id = 2, Username = "user2", PasswordHash = "hash2", Role = "user" }
            };
            
            _mockRepo.Setup(x => x.User.FindAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("user1", result[0].Username);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Id = 1, Username = "testuser", PasswordHash = "hash", Role = "user" };
            var users = new List<User> { user };
            
            _mockRepo.Setup(x => x.User.FindByConditionAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
                     .ReturnsAsync(users);

            // Act
            var result = await _userService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenUserNotExists()
        {
            // Arrange
            var users = new List<User>();
            
            _mockRepo.Setup(x => x.User.FindByConditionAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
                     .ReturnsAsync(users);

            // Act
            var result = await _userService.GetByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateUser_WhenValidData()
        {
            // Arrange
            var user = new User { Username = "newuser", PasswordHash = "validhash", Role = "user" };

            // Act
            await _userService.CreateAsync(user);

            // Assert
            _mockRepo.Verify(x => x.User.CreateAsync(It.IsAny<User>()), Times.Once);
            _mockRepo.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateUser_WhenValidData()
        {
            // Arrange
            var user = new User { Id = 1, Username = "updated", PasswordHash = "newhash", Role = "admin" };

            // Act
            await _userService.UpdateAsync(user);

            // Assert
            _mockRepo.Verify(x => x.User.UpdateAsync(It.IsAny<User>()), Times.Once);
            _mockRepo.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Id = 1, Username = "todelete", PasswordHash = "hash", Role = "user" };
            var users = new List<User> { user };
            
            _mockRepo.Setup(x => x.User.FindByConditionAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
                     .ReturnsAsync(users);

            // Act
            await _userService.DeleteAsync(1);

            // Assert
            _mockRepo.Verify(x => x.User.DeleteAsync(It.IsAny<User>()), Times.Once);
            _mockRepo.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldNotDelete_WhenUserNotExists()
        {
            // Arrange
            var users = new List<User>();
            
            _mockRepo.Setup(x => x.User.FindByConditionAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
                     .ReturnsAsync(users);

            // Act
            await _userService.DeleteAsync(999);

            // Assert
            _mockRepo.Verify(x => x.User.DeleteAsync(It.IsAny<User>()), Times.Never);
            _mockRepo.Verify(x => x.SaveAsync(), Times.Never);
        }
    }
}