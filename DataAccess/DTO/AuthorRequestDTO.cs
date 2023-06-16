using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.DTO
{
    public class AuthorRequestDTO
    {
        [Required]
        [NotNull]
        public string LastName { get; set; }

        [Required]
        [NotNull]
        public string FirstName { get; set; }

        [Required]
        [NotNull]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [NotNull]
        public string Address { get; set; }

        [Required]
        [NotNull]
        public string City { get; set; }

        [Required]
        [NotNull]
        public string State { get; set; }

        [Required]
        [NotNull]
        public string Zip { get; set; }

        [Required]
        [NotNull]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
