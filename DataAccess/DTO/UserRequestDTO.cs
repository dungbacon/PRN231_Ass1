using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.DTO
{
    public class UserRequestDTO
    {
        [Required]
        [EmailAddress]
        [NotNull]
        public string Email { get; set; }
        [Required]
        [NotNull]
        public string Password { get; set; }
    }
}
