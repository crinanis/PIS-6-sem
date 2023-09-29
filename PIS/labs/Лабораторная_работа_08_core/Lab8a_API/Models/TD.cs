using Lab8a_API.Interfaces;
using Lab8a_API.Models.Db;

namespace Lab8a_API.Models
{
    public class TD : ITD
    {
        private IDbContext _db;

        public TD(IDbContext db)
        {
            _db = db;
        }

        public void Add(string phoneNumber, string ownerName)
        {
            _db.Phone.Add(new Phone { PhoneNumber = phoneNumber, OwnerName = ownerName });
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var phone = _db.Phone.FirstOrDefault(x => x.Id == id);
            if (phone == null)
                return;

            _db.Phone.Remove(phone);
            _db.SaveChanges();
        }

        public Phone Get(int id)
        {
            var phone = _db.Phone.FirstOrDefault(x => x.Id == id);
            return phone;
        }

        public IEnumerable<Phone> GetAll()
        {
            var data = _db.Phone.Select(x => x).ToList();
            return data;
        }

        public void Update(Phone phone)
        {
            var entity = _db.Phone.FirstOrDefault(x => x.Id == phone.Id);
            entity.OwnerName = phone.OwnerName ?? entity.OwnerName;
            entity.PhoneNumber = phone.PhoneNumber ?? entity.PhoneNumber;
            _db.SaveChanges();
        }
    }
}
