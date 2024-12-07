
using SQLite;

namespace UniversalApp.Models
{
    [Table("items")]
    public class Item : IHasUserId
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int InvoiceId { get; set; }
    }
}
