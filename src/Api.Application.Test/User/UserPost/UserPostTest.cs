using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.UserPost
{
    public class UserPostTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Post Controller")]
        public async Task UserPostTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();
            string name = Faker.Name.FullName();
            string email = Faker.Internet.Email();

            _serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(new UserDtoCreateResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreateAt = DateTime.UtcNow,
            });

            _controller = new UsersController(_serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = name,
                Email = email,
            };

            ActionResult result = await _controller.Post(userDtoCreate);
            Assert.True(result is CreatedResult);

            UserDtoCreateResult resultValue = ((CreatedResult)result).Value as UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoCreate.Name, resultValue.Name);
            Assert.Equal(userDtoCreate.Email, resultValue.Email);
        }
    }
}