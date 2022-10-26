using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Security;
using Domain.Interfaces.Services.User;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Service.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserRepository _repository;
        private readonly SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration { get; }

        public LoginService(
            IUserRepository repository,
            SigningConfigurations signingConfigurations,
            IConfiguration configuration
        )
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao atenticar"
                };
            };

            UserEntity baseUser = new UserEntity();

            baseUser = await _repository.FindByLogin(user.Email, user.Password);
            if (baseUser == null)
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao atenticar"
                };
            }
            else if(baseUser.Password == user.Password)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(baseUser.Email),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                    }
                );

                DateTime createDate = DateTime.Now;
                var envDays = Environment.GetEnvironmentVariable("Days");
                var expirationDateConvert = Convert.ToInt32(envDays);
                DateTime expirationDate = createDate + TimeSpan.FromDays(expirationDateConvert);
                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(createDate, expirationDate, token, baseUser);
            }

            return new
            {
                authenticated = false,
                message = "Falha ao atenticar"
            };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userEmail = user.Email,
                userName = user.Name,
                message = "Usuário logado com sucesso",
            };
        }
    }
}

