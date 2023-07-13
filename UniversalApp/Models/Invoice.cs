using SQLite;

namespace UniversalApp.Models
{
    [Table("invoices")]
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int InvoiceId { get; set; }

        public string ClientName { get; set; }

        public string JobName { get; set; } 

        public string JobDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Total { get; set; }

        public int UserId { get; set; }

    }
}
