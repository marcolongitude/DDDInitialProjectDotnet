using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.User
{
    public class UserCrudIntegration : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }
        private string _cel { get; set; }
        private string _permission { get; set; }

        [Fact(DisplayName = "User Crud Test Integration")]
        public async Task UserCrudIntegrationTest()
        {
            await AddToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();
            _cel = Faker.Phone.Number();
            _permission = "admin";

            var userDtoCreate = new UserDtoCreate()
            {
                Name = _name,
                Email = _email,
                Cel = _cel,
                Permission = _permission,
                Password = "123456"
            };

            //Post
            var response = await PostJsonAsync(userDtoCreate, $"{hostApi}/v1/users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_email, registroPost.Email);
            Assert.Equal(_cel, registroPost.Cel);
            Assert.Equal(_permission, registroPost.Permission);
            Assert.True(registroPost.Id != default(Guid));
        }
    }
}