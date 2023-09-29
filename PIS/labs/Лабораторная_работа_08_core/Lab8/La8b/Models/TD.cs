using Lab8.Interfaces;
using Lab8.Models.Db;

namespace Lab8.Models
{
    public class TD : ITD
    {
        private IDbContext _db;

        public TD(IDbContext db)
        {
            _db = db;
        }

        public void Add(Lera lera)
        {
            _db.Lera.Add(new Lera(lera.FirstName, lera.LastName, lera.Email, lera.Password));
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var phone = _db.Lera.FirstOrDefault(x => x.Id == id);
            if (phone == null)
                return;

            _db.Lera.Remove(phone);
            _db.SaveChanges();
        }

        public Lera Get(int id)
        {
            var phone = _db.Lera.FirstOrDefault(x => x.Id == id);
            return phone;
        }

        public IEnumerable<Lera> GetAll()
        {
            var data = _db.Lera.Select(x => x).ToList();
            return data;
        }

        public void Update(int id, Lera lera)
        {
            var entity = _db.Lera.FirstOrDefault(x => x.Id == id);
            entity.FirstName = lera.FirstName;
            entity.LastName= lera.LastName;
            entity.Password = lera.Password;
            entity.Email = lera.Email;

            _db.SaveChanges();
        }
    }
}
