using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.DTO
{
    public class PublisherRequestDTO
    {
        [Required]
        [NotNull]
        public string PubName { get; set; }
        [Required]
        [NotNull]
        public string City { get; set; }
        [Required]
        [NotNull]
        public string State { get; set; }
        [Required]
        [NotNull]
        public string Country { get; set; }
    }
}
