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
    public class UserGetTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Get Controller")]
        public async Task UserGetTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();
            string name = Faker.Name.FullName();
            string email = Faker.Internet.Email();
            string cel = Faker.Identification.UKNationalInsuranceNumber();

            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    Cel = cel,
                    CreateAt = DateTime.UtcNow,
                }
            );

            _controller = new UsersController(_serviceMock.Object);
            ActionResult result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            UserDto resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
            Assert.Equal(cel, resultValue.Cel);
        }
    }
}