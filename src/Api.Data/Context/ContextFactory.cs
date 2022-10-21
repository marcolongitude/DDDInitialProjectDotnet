using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //var sqlServerConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_SQLSERVER");
            var sqlServerConnectionString = "Persist Security Info=True;Server=127.0.0.1,1433;Initial Catalog=dbIntegration1;MultipleActiveResultSets=true; User Id=sa;Password=Adminmagti*1981";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(sqlServerConnectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}