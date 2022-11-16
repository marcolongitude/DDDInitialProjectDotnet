using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Post;
using Moq;
using Xunit;

namespace Api.Service.Test.Post
{
    public class PutMethodTest : BasePostTests
    {
        private IPostService _service;
        private Mock<IPostService> _serviceMock;

        [Fact(DisplayName = "Post Put")]
        public async Task PutMethodTestUnity()
        {
            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Post(postDtoCreate)).ReturnsAsync(postDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(postDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(PostName, result.Name);
            Assert.Equal(PostDescription, result.Description);

            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.Put(postDtoUpdate)).ReturnsAsync(postDtoUpdateResult);
            _service = _serviceMock.Object;

            var updateResult = await _service.Put(postDtoUpdate);
            Assert.NotNull(updateResult);
            Assert.Equal(PostNameUpdate, updateResult.Name);
            Assert.Equal(PostDescriptionUpdate, updateResult.Description);
        }
    }
}