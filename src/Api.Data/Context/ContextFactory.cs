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
            var sqlServerConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_SQLSERVER");
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(sqlServerConnectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}