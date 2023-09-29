using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.Models
{
    [Table("PhoneBook")]
    public class PhoneBook
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("surname")]
        public string surname { get; set; }

        [Required]
        [MaxLength(13)]
        [Column("phoneNumber")]
        public string phoneNumber { get; set; }

        public PhoneBook(string surname, string phoneNumber)
        {
            this.surname = surname;
            this.phoneNumber = phoneNumber;
        }

        public PhoneBook() { }
    }
}