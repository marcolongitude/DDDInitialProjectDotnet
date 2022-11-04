using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.UserGetAll
{
    public class UserGetAllTest
    {
        private UsersController _controller;
        private List<UserDto> listUserDto = new List<UserDto>();

        [Fact(DisplayName = "User Get All Controller Test")]
        public async Task UserGetAllTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();

            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>{
                    new UserDto {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        Cel = Faker.Identification.UKNationalInsuranceNumber(),
                        CreateAt = DateTime.UtcNow
                    },
                    new UserDto {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        Cel = Faker.Identification.UKNationalInsuranceNumber(),
                        CreateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new UsersController(_serviceMock.Object);
            ActionResult result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);
            IEnumerable<UserDto> resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.True(resultValue.Count() == 2);
            Assert.False(resultValue.Count() != 2);
        }
    }

}