using IdentityEF_DependencyInjection.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityEF_DependencyInjection.Core.CrossCuttingConcert.Identities.Microsoft.Users
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public async Task<ClaimsIdentity> GenereteUserIdentityIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public string NameLastname { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }       
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }        
        public bool IsConfirm { get; set; }
        public bool IsDeleted { get; set; }
        public void SetConfirmed()
        {
            IsConfirm = true;
        }

        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }

        public void SetNotDeleted()
        {
            IsDeleted = false;
        }
        public ApplicationUser()
        {
            SetConfirmed();
            SetCreatedDate();
            SetNotDeleted();
            EmailConfirmed = true;
            PhoneNumberConfirmed = true;
        }
    }
}
