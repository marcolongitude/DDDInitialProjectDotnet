using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Post;
using Api.Domain.Interfaces.Services.Post;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Post.PostGet
{
    public class PostGetTest
    {
        private PostController _controller;

        [Fact(DisplayName = "User Get Controller")]
        public async Task UserGetTestUnity()
        {
            Mock<IPostService> _serviceMock = new Mock<IPostService>();
            string name = Faker.Lorem.Sentences(1).ToString();
            string description = Faker.Lorem.Sentences(3).ToString();

            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new PostDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Description = description,
                    UserId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                }
            );

            _controller = new PostController(_serviceMock.Object);
            ActionResult result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            PostDto resultValue = ((OkObjectResult)result).Value as PostDto;
            Assert.NotNull(resultValue);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(description, resultValue.Description);
        }
    }
}