using Lab8a_API.Models;

namespace Lab8a_API.Interfaces
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
