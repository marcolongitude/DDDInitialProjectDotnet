using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.UserGetAll
{
    public class UserGetAllBadRequestTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Get All Controller Test")]
        public async Task UserGetAllBadRequestTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();

            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>{
                    new UserDto{
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        Cel = Faker.Identification.UKNationalInsuranceNumber(),
                        CreateAt = DateTime.UtcNow,
                    }
                }
            );

            _controller = new UsersController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "O campo nome é obrigatório");
            ActionResult result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);

        }
    }
}