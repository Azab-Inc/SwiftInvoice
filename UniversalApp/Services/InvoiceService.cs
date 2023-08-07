
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
                using (var connection = dbService.GetConnection())
                {
                    // Add invoice
                    connection.Insert(invoice);

                    // Get newest invoice id
                    int newInvoiceId = connection.Table<Invoice>().OrderByDescending(i => i.InvoiceId).First().InvoiceId;

                    // Add invoice items with the new invoice id
                    foreach (var item in items)
                    {
                        item.InvoiceId = newInvoiceId;
                        connection.Insert(item);
                    }
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

        public List<Invoice> dbGetInvoices(int userId)
        {
            dbService.RunQuery();

            try
            {
                using (var connection = dbService.GetConnection())
                {
                    // Retrieve invoices by user ID
                    List<Invoice> invoices = connection.Table<Invoice>().Where(i => i.UserId == userId).ToList();

                    return invoices;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public List<Item> dbGetItems(int invoiceId)
        {
            // Get items by invoice id

            return null;
        }

    }
}
