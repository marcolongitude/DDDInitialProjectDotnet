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
    public class UserPostBadRequestTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Post Bad Request Controller")]
        public async Task UserPostTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();
            string name = Faker.Name.FullName();
            string email = Faker.Internet.Email();
            string cel = Faker.Phone.Number();
            string password = Faker.RandomNumber.Next(100000, 100100).ToString();

            _serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(new UserDtoCreateResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Cel = cel,
                CreateAt = DateTime.UtcNow,
            });

            _controller = new UsersController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = name,
                Email = email,
                Cel = cel,
                Password = password
            };

            ActionResult result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}