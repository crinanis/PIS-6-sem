using Lab8a_MVC.Models;

namespace Lab8a_MVC.Interfaces
{
    public interface ITD
    {
        IEnumerable<Phone> GetAll();
        Phone Get(int id);
        void Add(string phoneNumber, string ownerName);
        void Delete(int id);
        void Update(Phone phone);
    }
}
