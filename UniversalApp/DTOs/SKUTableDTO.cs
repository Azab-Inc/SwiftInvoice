namespace UniversalApp.DTOs
{
    public record SKUTableDTO(
        int Id,
        string SKUName,
        int numInvoices,
        int UserId);
}
