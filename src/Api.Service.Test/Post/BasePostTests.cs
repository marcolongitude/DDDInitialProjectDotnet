using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Post;

namespace Api.Service.Test.Post
{
    public class BasePostTests
    {
        public Guid PostId { get; set; }
        public string PostName { get; set; }
        public string PostNameUpdate { get; set; }
        public string PostDescription { get; set; }
        public string PostDescriptionUpdate { get; set; }
        public Guid PostUserId { get; set; }

        public List<PostDto> listPostsDto = new List<PostDto>();

        public PostDto postDto;

        public PostDtoCreate postDtoCreate;

        public PostDtoCreateResult postDtoCreateResult;

        public PostDtoUpdate postDtoUpdate;

        public PostDtoUpdateResult postDtoUpdateResult;


        public BasePostTests()
        {
            PostId = Guid.NewGuid();
            PostName = Faker.Lorem.Sentences(1).ToString();
            PostNameUpdate = Faker.Lorem.Sentences(1).ToString();
            PostDescription = Faker.Lorem.Sentences(3).ToString();
            PostDescriptionUpdate = Faker.Lorem.Sentences(3).ToString();
            PostUserId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new PostDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Lorem.Sentences(1).ToString(),
                    Description = Faker.Lorem.Sentences(3).ToString(),
                    UserId = Guid.NewGuid(),
                };
                listPostsDto.Add(dto);
            }

            postDto = new PostDto
            {
                Id = PostId,
                Name = PostName,
                Description = PostDescription,
                UserId = PostUserId
            };

            postDtoCreate = new PostDtoCreate
            {
                Name = PostName,
                Description = PostDescription,
                UserId = PostUserId,
            };

            postDtoCreateResult = new PostDtoCreateResult
            {
                Id = PostId,
                Name = PostName,
                Description = PostDescription,
                CreateAt = DateTime.UtcNow,
            };

            postDtoUpdate = new PostDtoUpdate
            {
                Id = PostId,
                Name = PostNameUpdate,
                Description = PostDescriptionUpdate,
            };

            postDtoUpdateResult = new PostDtoUpdateResult
            {
                Id = PostId,
                Name = PostNameUpdate,
                Description = PostDescriptionUpdate,
                UpdateAt = DateTime.UtcNow,
            };
        }
    }
}