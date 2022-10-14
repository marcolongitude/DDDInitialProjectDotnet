using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletcion)
        {
            serviceColletcion.AddTransient<IUserService, UserService>();
            serviceColletcion.AddTransient<ILoginService, LoginService>();
        }
    }
}