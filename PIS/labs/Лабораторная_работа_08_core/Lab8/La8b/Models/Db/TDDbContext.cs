using Lab8.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8.Models.Db
{
    public class TDDbContext : DbContext, IDbContext
    {
        public DbSet<Lera> Lera { get; set; }

        public TDDbContext(DbContextOptions<TDDbContext> options) : base(options)
        {
        }

        void IDbContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}
