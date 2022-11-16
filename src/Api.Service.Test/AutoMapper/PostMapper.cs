using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Post;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class PostMapper : BaseServiceTest
    {
        [Fact(DisplayName = "Post Mapper Test")]
        public void PostMapperTest()
        {
            PostModel model = new PostModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Description = Faker.Lorem.Sentences(3).ToString(),
                UserId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };

            List<PostEntity> listPostsEntity = new List<PostEntity>();

            for (int i = 0; i < 5; i++)
            {
                PostEntity item = new PostEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Description = Faker.Lorem.Sentences(3).ToString(),
                    UserId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                };

                listPostsEntity.Add(item);
            }

            //Model to Entity
            PostEntity entity = Mapper.Map<PostEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Description, model.Description);
            Assert.Equal(entity.UserId, model.UserId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity to DTO
            PostDto postDto = Mapper.Map<PostDto>(entity);
            Assert.Equal(postDto.Id, entity.Id);
            Assert.Equal(postDto.Name, entity.Name);
            Assert.Equal(postDto.Description, entity.Description);
            Assert.Equal(postDto.UserId, entity.UserId);
            Assert.Equal(postDto.CreateAt, entity.CreateAt);

            List<PostDto> listPostDto = Mapper.Map<List<PostDto>>(listPostsEntity);
            Assert.True(listPostDto.Count() == listPostsEntity.Count());
            for (int i = 0; i < listPostDto.Count(); i++)
            {
                Assert.Equal(listPostDto[i].Id, listPostsEntity[i].Id);
                Assert.Equal(listPostDto[i].Name, listPostsEntity[i].Name);
                Assert.Equal(listPostDto[i].Description, listPostsEntity[i].Description);
                Assert.Equal(listPostDto[i].UserId, listPostsEntity[i].UserId);
                Assert.Equal(listPostDto[i].CreateAt, listPostsEntity[i].CreateAt);
            }

            PostDtoCreateResult postDtoCreateResult = Mapper.Map<PostDtoCreateResult>(entity);
            Assert.Equal(postDtoCreateResult.Id, entity.Id);
            Assert.Equal(postDtoCreateResult.Name, entity.Name);
            Assert.Equal(postDtoCreateResult.Description, entity.Description);
            Assert.Equal(postDtoCreateResult.CreateAt, entity.CreateAt);

            PostDtoUpdateResult PostDtoUpdateResult = Mapper.Map<PostDtoUpdateResult>(entity);
            Assert.Equal(PostDtoUpdateResult.Id, entity.Id);
            Assert.Equal(PostDtoUpdateResult.Name, entity.Name);
            Assert.Equal(PostDtoUpdateResult.Description, entity.Description);
            Assert.Equal(PostDtoUpdateResult.UserId, entity.UserId);
            Assert.Equal(PostDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto to Model
            PostModel postModel = Mapper.Map<PostModel>(postDto);
            Assert.Equal(postModel.Id, postDto.Id);
            Assert.Equal(postModel.Name, postDto.Name);
            Assert.Equal(postModel.Description, postDto.Description);
            Assert.Equal(postModel.UserId, postDto.UserId);
            Assert.Equal(postModel.CreateAt, postDto.CreateAt);

            PostDtoCreate postDtoCreate = Mapper.Map<PostDtoCreate>(postModel);
            Assert.Equal(postDtoCreate.Name, postModel.Name);
            Assert.Equal(postDtoCreate.Description, postModel.Description);
            Assert.Equal(postDtoCreate.UserId, postModel.UserId);

            PostDtoUpdate postDtoUpdate = Mapper.Map<PostDtoUpdate>(postModel);
            Assert.Equal(postDtoUpdate.Id, postModel.Id);
            Assert.Equal(postDtoUpdate.Name, postModel.Name);
            Assert.Equal(postDtoUpdate.Description, postModel.Description);
        }
    }
}