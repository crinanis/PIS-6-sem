using Lab8.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8.Models.Db
{
    public interface IDbContext
    {
        DbSet<Lera> Lera { get; set; }
        void SaveChanges();
    }
}
