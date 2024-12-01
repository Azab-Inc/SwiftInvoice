namespace UniversalApp.DTOs
{
    public record InvoicePreviewDTO(
        int InvoiceId,
        int skuTypeId,
        string ClientName,
        string JobName,
        string InvoiceNum
        );
    
}
