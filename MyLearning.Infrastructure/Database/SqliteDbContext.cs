using Microsoft.EntityFrameworkCore;
using MyLearning.Domain.CopyBook;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Infrastructure.Database;

public class SqliteDbContext(DbContextOptions<SqliteDbContext> options) : DbContext(options)

{

    public DbSet<CopyBook> CopyBooks => Set<CopyBook>();
    public DbSet<Asset> Assets => Set<Asset>();
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        mb.ApplyConfigurationsFromAssembly(typeof(SqliteDbContext).Assembly);
    }
}
