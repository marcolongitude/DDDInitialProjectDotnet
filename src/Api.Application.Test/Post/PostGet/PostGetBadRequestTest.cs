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

namespace Api.Application.Test.Post.PostGet
{
    public class PostGetBadRequestTest
    {
        private PostController _controller;

        [Fact(DisplayName = "Post Get Bad Request Controller Test")]
        public async Task PostGetBadRequestTestUnity()
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
            _controller.ModelState.AddModelError("Id", "Id com formato invalido");
            ActionResult result = await _controller.Get(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}