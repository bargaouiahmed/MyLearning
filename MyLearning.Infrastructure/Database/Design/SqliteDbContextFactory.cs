using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyLearning.Infrastructure.Database.Design
{
    public sealed class SqliteDbContextFactory : IDesignTimeDbContextFactory<SqliteDbContext>
    {
        public SqliteDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<SqliteDbContext>()
            .UseSqlite("Data Source=MyLearning.db")
            .Options;
            return new SqliteDbContext(options);
        }

    }
}