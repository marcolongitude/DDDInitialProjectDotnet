using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.UserGet
{
    public class UserGetBadRequestTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Get Bad Request Controller Test")]
        public async Task UserGetBadRequestTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();
            string name = Faker.Name.FullName();
            string email = Faker.Internet.Email();

            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow,
                }
            );

            _controller = new UsersController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Id com formato invalido");
            ActionResult result = await _controller.Get(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}