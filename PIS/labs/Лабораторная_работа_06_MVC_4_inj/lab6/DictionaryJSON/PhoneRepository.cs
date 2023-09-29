using IPhoneDictionary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DictionaryJSON
{
    public class PhoneRepository : IPhoneDictionary.IPhoneDictionary
    {

        private List<PhoneBook> phones;
        private string dataFilePath;

        public PhoneRepository(string dataFilePath)
        {
            this.phones = new List<PhoneBook>();
            this.dataFilePath = dataFilePath;
        }

        public PhoneBook Create(PhoneBook phone)
        {
            phones = FindAll();
            int lastID = phones.Count;
            phone.id = lastID + 1;
            phones.Add(phone);
            Save();
            return phone;
        }

        public PhoneBook Delete(string surname)
        {
            phones = FindAll();
            PhoneBook phone = phones.Find(item => item.surname == surname);
            phones.Remove(phone);
            Save();
            return phone;
        }

        public List<PhoneBook> FindAll()
        {
            using (FileStream fs = new FileStream(dataFilePath, FileMode.OpenOrCreate))
            {
                this.phones = JsonSerializer.Deserialize<List<PhoneBook>>(fs);
            }
            return this.phones;
        }

        public void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using (FileStream fs = new FileStream(dataFilePath, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                JsonSerializer.Serialize(fs, phones, options);
            }
        }

        public PhoneBook Update(string surname, string phoneNumber)
        {
            phones = FindAll();
            PhoneBook phone = phones.Find(item => item.surname == surname);
            phone.phoneNumber = phoneNumber;
            Save();
            return phone;
        }
    }
}
