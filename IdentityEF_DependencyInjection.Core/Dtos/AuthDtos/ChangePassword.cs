using IdentityEF_DependencyInjection.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityEF_DependencyInjection.Core.Dtos.AuthDtos
{
    public class ChangePassword : IDto
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Passwords are not same. Please check them.")]
        public string ConfirmNewPassword { get; set; }
    }
}
