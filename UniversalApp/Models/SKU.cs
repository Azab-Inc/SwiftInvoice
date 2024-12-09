using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversalApp.Models
{
    [Table("skus")]
    public class SKU : IHasUserId
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string SKUName { get; set; }

        public int UserId { get; set; }
    }
}
