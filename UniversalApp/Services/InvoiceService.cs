
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
            try
            {
                using (var connection = dbService.GetConnection())
                {
                    // Retrieve existing invoice by its ID
                    var existingInvoice = connection.Table<Invoice>().FirstOrDefault(i => i.InvoiceId == invoice.InvoiceId);

                    if (existingInvoice != null)
                    {
                        // Update invoice details
                        existingInvoice.ClientName = invoice.ClientName;
                        existingInvoice.JobName = invoice.JobName;
                        existingInvoice.JobDescription = invoice.JobDescription;
                        existingInvoice.StartDate = invoice.StartDate;
                        existingInvoice.EndDate = invoice.EndDate;
                        existingInvoice.PaymentDate = invoice.PaymentDate;
                        existingInvoice.Total = invoice.Total;

                        // Update the invoice in the database
                        connection.Update(existingInvoice);

                        // Get existing items associated with the invoice
                        var existingItems = connection.Table<Item>().Where(i => i.InvoiceId == invoice.InvoiceId).ToList();

                        // Loop over items and make updates
                        foreach (var newItem in items)
                        {
                            var existingItem = existingItems.FirstOrDefault(e => e.ItemId == newItem.ItemId);

                            if (existingItem != null)
                            {
                                existingItem.Name = newItem.Name;
                                existingItem.Description = newItem.Description;
                                existingItem.Price = newItem.Price;

                                // Update the item in the database
                                connection.Update(existingItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        public Invoice dbGetInvoice(int invoiceId)
        {
            try
            {
                using (var connection = dbService.GetConnection())
                {
                    // Retrieve invoice by its ID
                    var invoice = connection.Table<Invoice>().FirstOrDefault(i => i.InvoiceId == invoiceId);

                    return invoice;
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
            try
            {
                using (var connection = dbService.GetConnection())
                {
                    // Retrieve items associated with the invoice ID
                    var items = connection.Table<Item>().Where(i => i.InvoiceId == invoiceId).ToList();

                    return items;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

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

        public void dbDeleteInvoice(int invoiceId)
        {
            dbService.RunQuery();

            try
            {
                using (var connection = dbService.GetConnection())
                {
                    // Delete invoice items
                    connection.Table<Item>().Delete(i => i.InvoiceId == invoiceId);

                    // Delete invoice
                    connection.Table<Invoice>().Delete(i => i.InvoiceId == invoiceId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
