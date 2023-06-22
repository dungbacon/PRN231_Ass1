using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int PubId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Advance { get; set; }
        [Required]
        public double Royalty { get; set; }
        [Required]
        public decimal YTDSales { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
    }
}
