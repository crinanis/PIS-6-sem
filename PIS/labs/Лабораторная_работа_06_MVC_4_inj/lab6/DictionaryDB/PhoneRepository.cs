using IPhoneDictionary;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DictionaryDB
{
    public class PhoneRepository : IPhoneDictionary.IPhoneDictionary
    {
        private PhoneContext context;
        DbSet<PhoneBook> phones;

        public PhoneRepository(PhoneContext context)
        {
            this.context = context;
            phones = context.Set<PhoneBook>();
        }

        public PhoneBook Create(PhoneBook phone)
        {
            phones.Add(phone);
            Save();
            return phone;
        }

        public PhoneBook Delete(string surname)
        {
            PhoneBook phone = phones.FirstOrDefault(p => p.surname.Equals(surname));
            phones.Remove(phone);
            Save();
            return phone;
        }

        public List<PhoneBook> FindAll()
        {
            return phones.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public PhoneBook Update(string surname, string newNumber)
        {
            PhoneBook phone = phones.FirstOrDefault(p => p.surname == surname);
            if (phone != null)
            {
                phone.phoneNumber = newNumber;
                context.Entry(phone).State = EntityState.Modified;
                Save();
            }
            return phone;
        }
    }
}
