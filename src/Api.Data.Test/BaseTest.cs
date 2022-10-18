using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTest : IDisposable
    {

        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o =>
                o.UseSqlServer($"Server=127.0.0.1,1433;Initial Catalog={dataBaseName};MultipleActiveResultSets=true; User Id=sa;Password=Adminmagti*1981"),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using var context = ServiceProvider.GetService<MyContext>();
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            using var context = ServiceProvider.GetService<MyContext>();
            context.Database.EnsureDeleted();
        }
    }
}