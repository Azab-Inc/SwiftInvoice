using System.IO;

namespace UniversalApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessNumber { get; set; }
        public string Email { get; set; }
        public string BankAccNumber { get; set; }
        public string BankName { get; set; }
        public FileImageSource Logo { get; set; }
        public int Phone { get; set; }
        public string Website { get; set; }
    }
}
