using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Domain.Dtos.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class GetMethodTest : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "User Get")]
        public async Task GetMethodTestUnity()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserId);
            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserCel, result.Cel);
            Assert.Equal(UserPermission, result.Permission);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _service = _serviceMock.Object;

            UserDto _record = await _service.Get(UserId);
            Assert.Null(_record);
        }
    }
}