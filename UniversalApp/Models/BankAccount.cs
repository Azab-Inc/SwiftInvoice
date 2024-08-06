using SQLite;

namespace UniversalApp.Models
{
    [Table("bank-accounts")]
    public class BankAccount
    {
        [PrimaryKey, AutoIncrement]
        public int AccountId { get; set; }

        public string BankName { get; set; }

        public string Country { get; set; }

        public string AccountNumber { get; set; }

        public string BranchIdentifier { get; set; }

        public string Currency { get; set; }

        public int UserId { get; set; }
    }
}
