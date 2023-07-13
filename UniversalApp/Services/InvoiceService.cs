
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class InvoiceService
    {
        private DbService dbService;
        public InvoiceService() { }

        public void dbCreateInvoice(Invoice invoice, List<Item> items)
        {
            // Add invoice

            // Get newest invoice id

            // Add invoice items with that invoice id
                // Loop over each invoice item and assign the invoice id
        }

        public void dbEditInvoice(Invoice invoice, List<Item> items) 
        { 
            // Get Invoice

            // Get items
            
            // Update invoice 

            // Loop over items and make updates to them
        }

        public Invoice dbGetInvoice(int id)
        {
            // Get Invoice by id

            return null;
        }

        public List<Invoice> dbShowInvoices()
        {
            // Return most recent invoices

            return null;
        }

        public List<Item> dbGetItems(int id)
        {
            // Get items by invoice id

            return null;
        }

    }
}
