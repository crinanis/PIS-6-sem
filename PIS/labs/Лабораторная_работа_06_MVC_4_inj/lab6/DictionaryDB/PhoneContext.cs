using System.Data.Entity;
using IPhoneDictionary;

namespace DictionaryDB
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("conn") { }

        public DbSet<PhoneBook> Phones { get; set; }
    }
}
