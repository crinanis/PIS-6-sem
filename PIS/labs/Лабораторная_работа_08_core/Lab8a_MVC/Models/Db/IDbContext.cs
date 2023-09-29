using Microsoft.EntityFrameworkCore;

namespace Lab8a_MVC.Models.Db
{
    public interface IDbContext
    {
        DbSet<Phone> Phone { get; set; }
        void SaveChanges();
    }
}
