
namespace UniversalApp.DTOs
{
    public record ClientPreviewDTO(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string ProfileImg,
    int Invoices
        );
    
}
