using System.ComponentModel.DataAnnotations;

namespace IISLibrarySystem.Dto.Model
{
    public class ISLib
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Grade { get; set; }
        public string? Category { get; set; }
        public string? Published_date { get; set; }
        public string? Quantity { get; set; }
        public int? Available_quantity { get; set; }
    }
}
