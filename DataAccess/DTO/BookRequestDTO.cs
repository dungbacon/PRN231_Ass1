using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.DTO
{
    public class BookRequestDTO
    {
        [Required]
        [NotNull]
        public string Title { get; set; }
        [Required]
        [NotNull]
        public string Type { get; set; }
        [Required]
        [NotNull]
        public int PubId { get; set; }
        [Required]
        [NotNull]
        public decimal Price { get; set; }
        [Required]
        [NotNull]
        public decimal Advance { get; set; }
        [Required]
        [NotNull]
        public double Royalty { get; set; }
        [Required]
        [NotNull]
        public decimal YTDSales { get; set; }
        [Required]
        [NotNull]
        public string Notes { get; set; }
        [Required]
        [NotNull]
        public DateTime PublishedDate { get; set; }
    }
}
