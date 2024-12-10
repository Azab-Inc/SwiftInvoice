using System.Diagnostics;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class InvoiceItemService : GenericService<Item, Item>
    {

        public void dbDeleteItems(int invoiceId)
        {
            dbService.RunQuery();

            try
            {
                using (var connection = dbService.GetConnection())
                {
                    
                    connection.Table<Item>().Delete(i => i.InvoiceId == invoiceId);
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
    }
}
