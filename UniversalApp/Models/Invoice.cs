using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalApp.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string ClientName { get; set; }

        public int BusinessNumber { get; set; }

        public string WebsiteLink { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public int[] ItemIds { get; set; }


    }
}
