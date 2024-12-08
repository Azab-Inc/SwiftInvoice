namespace UniversalApp.DTOs.ClientDTOs
{
    public record ClientPreviewDTO(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    bool isB2B,
    string ProfileImg,
    int Invoices
        );

}
