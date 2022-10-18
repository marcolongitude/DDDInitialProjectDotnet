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
            string stringConnectionTest = $"Persist Security Info=True;Server=127.0.0.1,1433;Initial Catalog={dataBaseName};MultipleActiveResultSets=true; User Id=sa;Password=Adminmagti*1981";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o =>
                o.UseSqlServer(stringConnectionTest),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();

            using MyContext? context = ServiceProvider.GetService<MyContext>();
            if(context is not null) context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            using MyContext? context = ServiceProvider.GetService<MyContext>();
            if(context is not null) context.Database.EnsureDeleted();
        }
    }
}