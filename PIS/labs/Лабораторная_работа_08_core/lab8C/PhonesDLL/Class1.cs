using Microsoft.EntityFrameworkCore;

namespace DLLEntity
{
    public interface IPhoneDictionary
    {
        IEnumerable<PhoneBook> GetAll();
        bool Add(PhoneBook dictObject);
        bool Update(PhoneBook dictObject);
        bool Delete(int id);
        PhoneBook Find(int id);
    }
    public class PhoneBook : IComparable<PhoneBook>
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public int CompareTo(PhoneBook p)
        {
            return this.surname.CompareTo(p.surname);
        }
    }
    public class PhoneDictionary : IPhoneDictionary
    {
        PhoneContext db; 
        public PhoneDictionary(DbContextOptions<PhoneContext> options)
        {
            this.db = new PhoneContext(options);
        }
        public IEnumerable<PhoneBook> GetAll()
        {
            return db.Phones.OrderBy(i => i.surname);
        }
        public bool Add(PhoneBook dictObject)
        {
            try
            {
                db.Phones.Add(dictObject);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(PhoneBook dictObject)
        {
            try
            {
                PhoneBook s = db.Phones.Find(dictObject.id);
                s.surname = dictObject.surname;
                s.phoneNumber = dictObject.phoneNumber;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                db.Phones.Remove(db.Phones.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PhoneBook Find(int id)
        {
            return db.Phones.Find(id);
        }
    }
    public class PhoneContext : DbContext
    {
        public DbSet<PhoneBook> Phones { get; set; }
        public PhoneContext(DbContextOptions<PhoneContext> options)
            : base(options)
        {

        }
    }
}
