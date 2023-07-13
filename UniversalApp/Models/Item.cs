
using SQLite;

namespace UniversalApp.Models
{
    [Table("items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int InvoiceId { get; set; }
    }
}
