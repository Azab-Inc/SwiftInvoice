using UniversalApp.Models;
using UniversalApp.DTOs;
using UniversalApp.DTOs.ClientDTOs;
using UniversalApp.Interfaces;

namespace UniversalApp.Services
{
    public class ClientService : GenericService<Client, ClientPreviewDTO>, ISearchable<ClientPreviewDTO>
    {
        public List<ClientNameSetDTO> dbGetClientNames(int userId)
        {
            using (var connection = dbService.GetConnection())
            {
                return connection.Table<Client>()
                                 .Where(c => c.UserId == userId)
                                 .Select(c => new ClientNameSetDTO(
                                     c.Id,
                                     c.FirstName,
                                     c.LastName,
                                     c.BusinessName,
                                     c.isB2B))
                                 .ToList();
            }
        }

        public List<ClientPreviewDTO> dbSearch(int userId, string search)
        {
            using (var connection = dbService.GetConnection())
            {
                search = search.ToLower();
                return connection.Table<Client>()
                    .Where(c => c.UserId == userId)
                    .Where(c => c.FirstName.ToLower().Contains(search) || c.LastName.ToLower().Contains(search))
                    .Select(c => new ClientPreviewDTO(
                        c.Id,
                        c.FirstName,
                        c.LastName,
                        c.Email,
                        c.Phone,
                        c.isB2B,
                        c.ProfileImg,
                        5))
                    .ToList();
            }
        }
    }
}
