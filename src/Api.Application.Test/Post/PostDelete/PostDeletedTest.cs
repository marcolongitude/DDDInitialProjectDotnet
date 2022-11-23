using System;
using System.Collections.Generic;
using Api.Application.Controllers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Api.Domain.Interfaces.Services.Post;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Test.Post.PostDelete
{
    public class PostDeletedTest
    {
        private PostController _controller;

        [Fact(DisplayName = "Post Delete Controller Test")]
        public async Task PostDeletedTestUnity()
        {
            Mock<IPostService> _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new PostController(_serviceMock.Object);

            ActionResult result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            object resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}