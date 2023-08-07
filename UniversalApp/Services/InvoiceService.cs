
using System.Diagnostics;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class InvoiceService
    {
        private DbService dbService = new DbService();
        public InvoiceService() { }

        public void dbCreateInvoice(Invoice invoice, List<Item> items)
        {
            dbService.RunQuery();
            
            try
            {

                // Add invoice
                dbService.GetConnection().Insert(invoice);

                // Get newest invoice id
                int newInvoiceId = dbService.GetConnection().Table<Invoice>().OrderByDescending(i => i.InvoiceId).First().InvoiceId;

                // Add invoice items with the new invoice id
                foreach (var item in items)
                {
                    item.InvoiceId = newInvoiceId;
                    dbService.GetConnection().Insert(item);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
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
            dbService.RunQuery();

            try 
            {
            
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public List<Item> dbGetItems(int id)
        {
            // Get items by invoice id

            return null;
        }

    }
}
