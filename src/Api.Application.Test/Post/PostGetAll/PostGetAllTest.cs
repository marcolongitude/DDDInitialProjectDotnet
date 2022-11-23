using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Post;
using Api.Domain.Interfaces.Services.Post;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Post.PostGetAll
{
    public class PostGetAllTest
    {
        private PostController _controller;

        [Fact(DisplayName = "Post Get All Controller Test")]
        public async Task PostGetAllTestUnity()
        {
            Mock<IPostService> _serviceMock = new Mock<IPostService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<PostDto>{
                    new PostDto {
                        Id = Guid.NewGuid(),
                        Name = Faker.Lorem.Sentences(1).ToString(),
                        Description = Faker.Lorem.Sentences(3).ToString(),
                        UserId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow
                    },
                    new PostDto {
                        Id = Guid.NewGuid(),
                        Name = Faker.Lorem.Sentences(1).ToString(),
                        Description = Faker.Lorem.Sentences(3).ToString(),
                        UserId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow
                    },
                }
            );

            _controller = new PostController(_serviceMock.Object);
            ActionResult result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);
            IEnumerable<PostDto> resultValue = ((OkObjectResult)result).Value as IEnumerable<PostDto>;
            Assert.True(resultValue.Count() == 2);
            Assert.False(resultValue.Count() != 2);
        }
    }
}