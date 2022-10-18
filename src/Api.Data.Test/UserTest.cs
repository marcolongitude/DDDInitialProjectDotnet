using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UserTest : BaseTest, IClassFixture<DbTest>
    {
        private readonly ServiceProvider _serviceProvider;

        public UserTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Crud User Test")]
        [Trait("CRUD", "UserEntity")]
        public async Task UserCreate()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            UserImplementation _repository = new UserImplementation(context);
            UserEntity _entity = new UserEntity
            {
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName(),
            };

            var result = await _repository.InsertAsync(_entity);
            Assert.NotNull(result);
            Assert.Equal(_entity.Email, result.Email);
            Assert.Equal(_entity.Name, result.Name);
            Assert.False(result.Id == Guid.Empty);

            _entity.Name = Faker.Name.First();
            var updatedResult = await _repository.UpdateAsync(_entity);
            Assert.NotNull(updatedResult);
            Assert.Equal(_entity.Email, updatedResult.Email);
            Assert.Equal(_entity.Name, updatedResult.Name);

        }
    }
}