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
    public class GetAllPostMethodTests : BasePostTests
    {
        private IPostService _service;
        private Mock<IPostService> _serviceMock;

        [Fact(DisplayName = "Post Get All")]
        public async Task GetAllMethodTestUnity()
        {
            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listPostsDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var listResult = new List<PostDto>();
            _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var listResultEmpty = await _service.GetAll();
            Assert.Empty(listResultEmpty);
            Assert.True(listResultEmpty.Count() == 0);
        }
    }
}