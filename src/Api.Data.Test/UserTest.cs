using System;
using System.Linq;
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
                Password = Faker.RandomNumber.Next(100000, 100100).ToString(),
                Cel = Faker.Phone.Number(),
                Permission = Roles.admin,
            };

            var createUser = await _repository.InsertAsync(_entity);
            Assert.NotNull(createUser);
            Assert.Equal(_entity.Email, createUser.Email);
            Assert.Equal(_entity.Name, createUser.Name);
            Assert.Equal(_entity.Cel, createUser.Cel);
            Assert.Equal(_entity.Password, createUser.Password);
            Assert.Equal(_entity.Permission, createUser.Permission);
            Assert.False(createUser.Id == Guid.Empty);

            _entity.Name = Faker.Name.First();
            var updateUser = await _repository.UpdateAsync(_entity);
            Assert.NotNull(updateUser);
            Assert.Equal(_entity.Email, updateUser.Email);
            Assert.Equal(_entity.Name, updateUser.Name);
            Assert.Equal(_entity.Cel, updateUser.Cel);
            Assert.Equal(_entity.Password, updateUser.Password);
            Assert.Equal(_entity.Permission, updateUser.Permission);

            var existsUser = await _repository.ExistAsync(updateUser.Id);
            Assert.True(existsUser);

            var selectedUser = await _repository.SelectAsync(updateUser.Id);
            Assert.NotNull(selectedUser);
            Assert.Equal(selectedUser.Email, updateUser.Email);
            Assert.Equal(selectedUser.Name, updateUser.Name);
            Assert.Equal(selectedUser.Cel, updateUser.Cel);
            Assert.Equal(selectedUser.Password, updateUser.Password);
            Assert.Equal(_entity.Permission, updateUser.Permission);

            var allUsers = await _repository.SelectAsync();
            Assert.NotNull(allUsers);
            Assert.True(allUsers.Count() > 0);

            var removeUser = await _repository.DeleteAsync(updateUser.Id);
            Assert.True(removeUser);

            var loginUser = await _repository.FindByLogin("adm@gmail.com");
            Assert.NotNull(loginUser);
            Assert.Equal("adm@gmail.com", loginUser.Email);
            Assert.Equal("Administrador", loginUser.Name);
        }
    }
}