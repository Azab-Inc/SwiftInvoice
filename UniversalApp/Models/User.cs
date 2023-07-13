using System.IO;
using SQLite;

namespace UniversalApp.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        public string AccString { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BusinessNumber { get; set; }

        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string BankAccNumber { get; set; }
        public string BankName { get; set; }
        public string LogoPath { get; set; }
        public int Phone { get; set; }
        public string Website { get; set; }
    }
}
