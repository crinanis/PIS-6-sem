using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IPhoneDictionary
{
    public interface IPhoneDictionary
    {
        List<PhoneBook> FindAll();
        PhoneBook Create(PhoneBook phone);
        PhoneBook Delete(string surname);
        PhoneBook Update(string surname, string phoneNumber);
        void Save();
    }
}

