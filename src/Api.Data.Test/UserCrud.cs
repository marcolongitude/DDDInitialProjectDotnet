using Api.Data.Context;
using Api.Domain.Entities;
using Data.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class UserCrud : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UserCrud(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD USER")]
        [Trait("CRUD", "UserEntity")]
        public async Task Must_Perform_The_User_Crud()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = "test@email.com",
                    Name = "Test",
                };

                var response = await _repository.InsertAsync(_entity);
                Assert.NotNull(response);
                Assert.Equal("test@email.com", response.Email);
                Assert.Equal("Test", response.Name);
                Assert.False(response.Id == Guid.Empty);
            };

        }
    }
}
