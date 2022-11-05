using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class LoginTest
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Login Test Unity")]
        public async Task LoginTestUnity()
        {
            string email = Faker.Internet.Email();

            object objectResult = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userEmail = email,
                userName = Faker.Name.FullName(),
                message = "Usuário logado com sucesso",
            };

            LoginDto loginDto = new LoginDto
            {
                Email = email,
                Password = "123456"
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectResult);
            _service = _serviceMock.Object;

            object result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}