using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Domain.Dtos.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class GetAllMethodTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "User Get All")]
        public async Task GetAllMethodTestUnity()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var listResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var listResultEmpty = await _service.GetAll();
            Assert.Empty(listResultEmpty);
            Assert.True(listResultEmpty.Count() == 0);
        }
    }
}