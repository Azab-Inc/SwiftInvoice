using UniversalApp.DTOs;
using UniversalApp.Interfaces;
using UniversalApp.Models;

namespace UniversalApp.Services
{
    public class SKUService : GenericService<SKU, SKUTableDTO>, ISearchable<SKU>, IPreventDuplicate<SKU>
    {

        private InvoiceService invoiceService = new InvoiceService();
        public bool alreadyExists(int userId, string search)
        {
            search = search.ToLower();
            using (var connection = dbService.GetConnection()) { 
                return connection.Table<SKU>()
                                 .Where(s => s.SKUName.ToLower() == search.ToLower())
                                 .Any();
                
            }
        }

        public List<SKU> dbSearch(int userId, string search)
        {
            using (var connection = dbService.GetConnection()) {
                search = search.ToLower();
                return connection.Table<SKU>()
                    .Where(c => c.UserId == userId)
                    .Where(c => c.SKUName.ToLower().Contains(search))                    
                    .ToList();
            }
        }

        public int newestNum(int userId, int skuId)
        {
            using (var connection = dbService.GetConnection())
            {
                int linkedInvoices = invoiceService.dbGetNumSkuInvoices(userId, skuId);
                return linkedInvoices;
            }

            
        }
    }
}
