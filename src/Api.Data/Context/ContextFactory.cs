using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var sqlServerConnectionString = "Server=127.0.0.1,1433;Initial Catalog=dbSFEContatos;MultipleActiveResultSets=true; User Id=sa;Password=Adminmagti*1981";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();          
            optionsBuilder.UseSqlServer(sqlServerConnectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}