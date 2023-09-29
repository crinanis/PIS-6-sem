using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    [Table("Lera")]
    public class Lera
    {
        /// <summary>
        /// lera id
        /// </summary>
        /// <example>104</example>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        /// <example>Ksusha</example>
        public string? FirstName{ get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        /// <example>Budanowa</example>
        public string? LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <example>email@gmail.com</example>
        public string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        /// <example>qwerty</example>
        public string Password { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <example>active</example>
        public string Status { get; set; } = "active";
        /// <summary>
        /// Role
        /// </summary>
        /// <example>user</example>
        public string Role { get; set; } = "user";

        public Lera(string first, string last, string email, string password)
        {
            FirstName = first; 
            LastName = last; 
            Email = email;
            Password = password;
        }

        public Lera(string email, string password) 
        {
            Email = email;
            Password = password;
        }

        public Lera() { }

    }
}
