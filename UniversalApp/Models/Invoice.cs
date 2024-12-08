using SQLite;
using System.ComponentModel.DataAnnotations;

namespace UniversalApp.Models
{
    [Table("invoices")]
    public class Invoice : IHasUserId 
    {      

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int skuTypeId { get; set; }

        [Required]
        [MinLength(3)]
        public string ClientName { get; set; }

        public int ClientId { get; set; }

        [Required]
        [MinLength(4)]
        public string JobName { get; set; }

        [Required]
        [MinLength(10)]
        public string JobDescription { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string InvoiceNum { get; set; }

        public decimal Total { get; set; }

        public int BankAccountId { get; set; }

        public int UserId { get; set; }

    }
}
