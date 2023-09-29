using Microsoft.EntityFrameworkCore;

namespace Lab8a_API.Models.Db
{
    public interface IDbContext
    {
        DbSet<Phone> Phone { get; set; }
        void SaveChanges();
    }
}
