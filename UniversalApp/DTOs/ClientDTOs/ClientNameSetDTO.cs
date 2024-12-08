namespace UniversalApp.DTOs
{
    public record ClientNameSetDTO(
        int Id,
        string FirstName,
        string LastName,
        string? BusinessName,
        bool isB2B);
}
