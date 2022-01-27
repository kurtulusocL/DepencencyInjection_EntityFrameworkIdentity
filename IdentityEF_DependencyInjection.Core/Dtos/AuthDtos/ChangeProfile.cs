using IdentityEF_DependencyInjection.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityEF_DependencyInjection.Core.Dtos.AuthDtos
{
    public class ChangeProfile : IDto
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Your Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Your City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Your Province")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Your Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your E-Mail Address")]
        public string Email { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ChangeProfile()
        {
            UpdatedDate = DateTime.Now.ToLocalTime();
        }
    }
}
