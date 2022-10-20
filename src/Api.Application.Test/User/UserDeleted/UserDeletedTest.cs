using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.UserDeleted
{
    public class UserDeletedTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Delete Controller Test")]
        public async Task UserDeletedTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();

            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(_serviceMock.Object);

            ActionResult result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}