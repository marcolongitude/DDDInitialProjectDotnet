using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Post;
using Api.Domain.Interfaces.Services.Post;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Post.PostCreate
{
    public class PostCreateTest
    {
        private PostController _controller;

        [Fact(DisplayName = "`Post Create Controller")]
        public async Task UserPostTestUnity()
        {
            Mock<IPostService> _serviceMock = new Mock<IPostService>();
            string name = Faker.Lorem.Sentences(1).ToString();
            string description = Faker.Lorem.Sentences(3).ToString();
            Guid userId = Guid.NewGuid();

            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new PostDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Description = description,
                    UserId = userId,
                    CreateAt = DateTime.UtcNow,
                }
            );

            _controller = new PostController(_serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            PostDtoCreate postDtoCreate = new PostDtoCreate
            {
                Name = name,
                Description = description,
                UserId = userId
            };

            ActionResult result = await _controller.Post(postDtoCreate);
            Assert.True(result is CreatedResult);

            PostDtoCreateResult resultValue = ((CreatedResult)result).Value as PostDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(postDtoCreate.Name, resultValue.Name);
            Assert.Equal(postDtoCreate.Description, resultValue.Description);
        }
    }
}