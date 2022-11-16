using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class PostTest : BaseTest, IClassFixture<DbTest>
    {
        private readonly ServiceProvider _serviceProvider;

        public PostTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }


        [Fact(DisplayName = "Crud Post Test")]
        [Trait("CRUD", "PostEntity")]
        public async Task PostCreate()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            PostImplementation _repositoryPost = new PostImplementation(context);

            UserImplementation _repositoryUser = new UserImplementation(context);
            UserEntity _entityUser = new UserEntity
            {
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName(),
                Password = Faker.RandomNumber.Next(100000, 100100).ToString(),
                Cel = Faker.Phone.Number(),
                Permission = Roles.admin,
            };
            UserEntity createUser = await _repositoryUser.InsertAsync(_entityUser);

            PostEntity _entityPost = new PostEntity
            {
                Name = Faker.Lorem.Sentences(1).ToString(),
                Description = Faker.Lorem.Sentences(4).ToString(),
                UserId = createUser.Id
            };

            PostEntity createPost = await _repositoryPost.InsertAsync(_entityPost);
            Assert.NotNull(createPost);
            Assert.Equal(_entityPost.Name, createPost.Name);
            Assert.Equal(_entityPost.Description, createPost.Description);
            Assert.False(createUser.Id == Guid.Empty);

            _entityPost.Name = Faker.Lorem.Sentences(1).ToString();
            PostEntity updatePost = await _repositoryPost.UpdateAsync(_entityPost);
            Assert.NotNull(updatePost);
            Assert.Equal(_entityPost.Name, updatePost.Name);
            Assert.Equal(_entityPost.Description, createPost.Description);
            Assert.False(createUser.Id == Guid.Empty);

            bool existsPost = await _repositoryPost.ExistAsync(_entityPost.Id);
            Assert.True(existsPost);

            var allPosts = await _repositoryPost.SelectAsync();
            Assert.NotNull(allPosts);
            Assert.True(allPosts.Count() > 0);

            bool removePost = await _repositoryPost.DeleteAsync(_entityPost.Id);
            Assert.True(removePost);
        }
    }
}