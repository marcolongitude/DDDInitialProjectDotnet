using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Post;
using Moq;
using Xunit;

namespace Api.Service.Test.Post
{
    public class DeleteMethodTest : BasePostTests
    {
        private IPostService _service;
        private Mock<IPostService> _serviceMock;

        [Fact(DisplayName = "Post Delete")]
        public async Task DeleteMethodTestUnity()
        {
            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Delete(PostId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(PostId);
            Assert.True(result);

            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            result = await _service.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}