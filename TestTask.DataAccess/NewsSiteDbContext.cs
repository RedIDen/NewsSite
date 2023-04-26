using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TestTask.DataAccess.DataModels;

namespace TestTask.DataAccess
{
    public class NewsSiteDbContext : DbContext
    {
        public DbSet<ArticleDataModel> Articles { get; set; }

        public DbSet<UserDataModel> Users { get; set; }

        public NewsSiteDbContext(DbContextOptions<NewsSiteDbContext> options) 
            : base(options)
        {
        }
    }

    public class NewsSiteDbContextFactory : IDesignTimeDbContextFactory<NewsSiteDbContext>
    {
        public NewsSiteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NewsSiteDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FGTJ8N2\\SQLEXPRESS;Initial Catalog=NewsSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False", b => b.MigrationsAssembly("TestTask.DataAccess"));

            return new NewsSiteDbContext(optionsBuilder.Options);
        }
    }
}
