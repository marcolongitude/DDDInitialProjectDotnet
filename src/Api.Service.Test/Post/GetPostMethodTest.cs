using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Post;
using Api.Domain.Interfaces.Services.Post;
using Moq;
using Xunit;

namespace Api.Service.Test.Post
{
    public class GetPostMethodTest : BasePostTests
    {
        private IPostService _service;
        private Mock<IPostService> _serviceMock;

        [Fact(DisplayName = "Post Get")]
        public async Task GetMethodTestUnity()
        {
            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Get(PostId)).ReturnsAsync(postDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(PostId);
            Assert.NotNull(result);
            Assert.True(result.Id == PostId);
            Assert.Equal(PostName, result.Name);
            Assert.Equal(PostDescription, result.Description);
            Assert.Equal(PostUserId, result.UserId);

            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((PostDto)null));
            _service = _serviceMock.Object;

            PostDto _record = await _service.Get(PostId);
            Assert.Null(_record);
        }
    }
}