using System;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Post;
using Api.Domain.Interfaces.Services.User;
using Data.Implementations;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IPostRepository, PostImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION_MYSQL"))
            );
        }
    }
}