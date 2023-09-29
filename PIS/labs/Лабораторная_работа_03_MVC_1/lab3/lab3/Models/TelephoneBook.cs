using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace lab3
{
    public class TelephoneBook
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }

        private const string jsonFilePath = @"d:\1POIT\3\PIS\labs\Лабораторная_работа_03_MVC_1\lab3\lab3\App_Data\telephoneBook.json";

        public List<TelephoneBook> GetAll()
        {
            string json = File.ReadAllText(jsonFilePath, Encoding.UTF8);
            var bookRows = JsonConvert.DeserializeObject<List<TelephoneBook>>(json);

            return bookRows.OrderBy(tr => tr.surname).ToList();
        }

        public bool AddBook(string surname, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(phoneNumber) && IsValidPhoneNumber(phoneNumber))
            {
                string json = File.ReadAllText(jsonFilePath, Encoding.UTF8);
                var bookRows = JsonConvert.DeserializeObject<List<TelephoneBook>>(json);

                bool phoneNumberExists = bookRows.Any(row => row.phoneNumber == phoneNumber);
                if (phoneNumberExists)
                {
                    return false;
                }

                int id = bookRows.Any() ? bookRows.Max(tr => tr.id) + 1 : 1;

                bookRows.Add(new TelephoneBook { id = id, surname = surname, phoneNumber = phoneNumber });

                string output = JsonConvert.SerializeObject(bookRows);
                File.WriteAllText(jsonFilePath, output, Encoding.UTF8);

                return true;
            }

            return false;
        }


        public bool Update(int id, string surname, string phoneNumber)
        {
            string json = File.ReadAllText(jsonFilePath, Encoding.UTF8);
            var bookRows = JsonConvert.DeserializeObject<List<TelephoneBook>>(json);

            TelephoneBook rowToUpdate = bookRows.FirstOrDefault(tr => tr.id == id);
            if (rowToUpdate != null)
            {
                if (!string.IsNullOrEmpty(surname))
                {
                    rowToUpdate.surname = surname;
                }

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    bool phoneNumberExists = bookRows.Any(row => row.phoneNumber == phoneNumber && row.id != id);
                    if (phoneNumberExists || !IsValidPhoneNumber(phoneNumber))
                    {
                        return false;
                    }

                    rowToUpdate.phoneNumber = phoneNumber;
                }

                string output = JsonConvert.SerializeObject(bookRows);
                File.WriteAllText(jsonFilePath, output, Encoding.UTF8);

                return true;
            }

            return false;
        }


        public bool Delete(int id)
        {
            string json = File.ReadAllText(jsonFilePath, Encoding.UTF8);
            var bookRows = JsonConvert.DeserializeObject<List<TelephoneBook>>(json);

            int initialCount = bookRows.Count;
            bookRows.RemoveAll(row => row.id == id);
            if (bookRows.Count != initialCount)
            {
                string output = JsonConvert.SerializeObject(bookRows);
                File.WriteAllText(jsonFilePath, output, Encoding.UTF8);

                return true;
            }

            return false;
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+375\d{9}$";

            bool isMatch = Regex.IsMatch(phoneNumber, pattern);

            return isMatch;
        }
    }
}
