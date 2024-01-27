using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    internal class SQLServerDbContext: DbContext
    {
        public SQLServerDbContext(DbContextOptions<SQLServerDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
