using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UniversalApp.DTOs;
using UniversalApp.Services;

namespace UniversalApp.Models
{
    public class Client : IHasUserId
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [DisplayName("First Name")]
        
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
        
        public string ProfileImg { get; set; }

        public string? BusinessNumber { get; set; }

        public string? BusinessName { get; set; }

        [Url]
        public string? Website { get; set; }

        public int UserId { get; set; }
    }

    // Move static method outside the class but still in the same file
    public static class ClientMapper
    {
        
        public static ClientPreviewDTO MapClientToDTO(Client client, int numInvoices)
        {
            return new ClientPreviewDTO(
                client.Id,
                client.FirstName,
                client.LastName,
                client.Email,
                client.Phone,
                client.ProfileImg,
                numInvoices
            );
        }
    }
}
