
using System.Diagnostics;
using UniversalApp.DTOs;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class InvoiceService : GenericService<Invoice, InvoicePreviewDTO>
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
                    int newInvoiceId = connection.Table<Invoice>().OrderByDescending(i => i.Id).First().Id;

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
                    var existingInvoice = connection.Table<Invoice>().FirstOrDefault(i => i.Id == invoice.Id);

                    if (existingInvoice != null)
                    {
                        // Update invoice details
                        existingInvoice = invoice;

                        // Update the invoice in the database
                        connection.Update(existingInvoice);

                        // Delete existing items associated with the invoice
                        dbDeleteItems(existingInvoice.Id);

                        // Add the new items with the updated invoice id
                        foreach (var newItem in items)
                        {
                            newItem.InvoiceId = existingInvoice.Id;
                            connection.Insert(newItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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

        public void dbDeleteItems(int invoiceId)
        {
            dbService.RunQuery();

            try
            {
                using (var connection = dbService.GetConnection())
                {
                    // Delete invoice items associated with the given invoiceId
                    connection.Table<Item>().Delete(i => i.InvoiceId == invoiceId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
     
        public List<InvoicePreviewDTO> dbGetInvoicePreviews(int userId)
        {
            dbService.RunQuery();

            try
            {
                using (var connection = dbService.GetConnection())
                {
                    var invoicePreviews = connection.Table<Invoice>()
                        .Where(i => i.UserId == userId)
                        .Select(i => new InvoicePreviewDTO(
                            i.Id,
                            i.skuTypeId,
                            i.ClientName,
                            i.JobName,
                            i.InvoiceNum
                        )).ToList();

                    return invoicePreviews;
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
                    connection.Table<Invoice>().Delete(i => i.Id == invoiceId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
