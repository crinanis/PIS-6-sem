using Lab8.Models;

namespace Lab8.Interfaces
{
    public interface ITD
    {
        IEnumerable<Lera> GetAll();
        Lera Get(int id);
        void Add(Lera lera);
        void Delete(int id);
        void Update(int id, Lera phone);
    }
}
