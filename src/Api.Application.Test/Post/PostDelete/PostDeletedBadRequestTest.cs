using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Post;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Post.PostDelete
{
    public class PostDeletedBadRequestTest
    {
        private PostController _controller;

        [Fact(DisplayName = "Post Delete Bad Request Controller Test")]
        public async Task PostDeletedBadRequestTestUnity()
        {
            Mock<IPostService> _serviceMock = new Mock<IPostService>();

            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new PostController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato invalido");

            ActionResult result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}