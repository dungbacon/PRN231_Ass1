using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserRegisterRequestDTO
    {
        [Required]
        [EmailAddress]
        [NotNull]
        public string Email { get; set; }
        [Required]
        [NotNull]
        public string Password { get; set; }
        [Required]
        [NotNull]
        public string ConfirmPassword { get; set; }
    }
}
