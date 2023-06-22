using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class AuthorDTO
    {
        public int? AuthorId { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Zip { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
