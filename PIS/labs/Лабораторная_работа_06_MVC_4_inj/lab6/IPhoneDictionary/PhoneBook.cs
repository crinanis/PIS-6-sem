using System.ComponentModel.DataAnnotations.Schema;

namespace IPhoneDictionary
{
    [Table("PhoneBook")]
    public class PhoneBook
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public PhoneBook() { }
    }
}