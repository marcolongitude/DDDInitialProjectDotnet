using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.UserUpdate
{
    public class UserUpdateTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Update Controller")]
        public async Task UserUpdateTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();
            string name = Faker.Name.FullName();
            string email = Faker.Internet.Email();

            _serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    UpdateAt = DateTime.UtcNow,
                }
            );

            _controller = new UsersController(_serviceMock.Object);

            UserDtoUpdate userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            ActionResult result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            UserDtoUpdateResult resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Name, resultValue.Name);
            Assert.Equal(userDtoUpdate.Email, resultValue.Email);
        }
    }
}