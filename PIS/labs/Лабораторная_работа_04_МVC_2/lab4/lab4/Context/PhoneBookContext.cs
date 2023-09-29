using lab4.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab4.Context
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<PhoneBook> Books { get; set; }

        public PhoneBookContext() : base("conn")
        {
        }

        public List<PhoneBook> GetAll()
        {
            return Books.OrderBy(tr => tr.surname).ToList();
        }

        public bool AddRow(string surname, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(phoneNumber) && IsValidPhoneNumber(phoneNumber))
            {
                bool phoneNumberExists = Books.Any(row => row.phoneNumber == phoneNumber);
                if (phoneNumberExists)
                {
                    return false;
                }

                Books.Add(new PhoneBook(surname, phoneNumber));
                SaveChanges();

                return true;
            }

            return false;
        }

        public bool Update(int id, string surname, string phoneNumber)
        {
            var changedRow = Books.FirstOrDefault(tr => tr.id == id);

            if (changedRow != null)
            {
                bool phoneNumberExists = Books.Any(row => row.phoneNumber == phoneNumber && row.id != id);
                if (phoneNumberExists || !IsValidPhoneNumber(phoneNumber))
                {
                    return false;
                }

                if (surname != "")
                {
                    changedRow.surname = surname;
                }

                if (phoneNumber != "")
                {
                    changedRow.phoneNumber = phoneNumber;
                }

                SaveChanges();

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deletedRow = Books.FirstOrDefault(tr => tr.id == id);
            if (deletedRow == null)
            {
                return false;
            }

            Books.Remove(deletedRow);

            SaveChanges();
            return true;
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+375\d{9}$";

            bool isMatch = Regex.IsMatch(phoneNumber, pattern);

            return isMatch;
        }
    }
}