using Microsoft.EntityFrameworkCore;

namespace Lab8a_MVC.Models.Db
{
    public class TDDbContext : DbContext, IDbContext
    {

        public DbSet<Phone> Phone { get; set; }

        public TDDbContext(DbContextOptions<TDDbContext> options) : base(options)
        {
        }

        void IDbContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}
