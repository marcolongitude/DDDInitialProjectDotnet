using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.UserDeleted
{
    public class UserDeletedBadRequestTest
    {
        private UsersController _controller;

        [Fact(DisplayName = "User Delete Bad Request Test")]
        public async Task UserDeletedBadRequestTestUnity()
        {
            Mock<IUserService> _serviceMock = new Mock<IUserService>();

            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato invalido");

            ActionResult result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}