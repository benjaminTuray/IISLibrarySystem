namespace IISLibrarySystem.Dto.Model
{
    public record struct ISLibDto
    (
        int Id,
        string Title, 
        string Author, 
        string Grade,
        string Category,
        string Published_date,
        string Quantity,
        int Available_quantity
    );
   
}
