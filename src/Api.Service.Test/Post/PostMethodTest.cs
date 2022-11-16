using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Post;
using Moq;
using Xunit;

namespace Api.Service.Test.Post
{
    public class PostMethodTest : BasePostTests
    {
        private IPostService _service;
        private Mock<IPostService> _serviceMock;

        [Fact(DisplayName = "Post Create")]
        public async Task PostMethodTestUnity()
        {
            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Post(postDtoCreate)).ReturnsAsync(postDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(postDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(PostName, result.Name);
            Assert.Equal(PostDescription, result.Description);
        }
    }
}