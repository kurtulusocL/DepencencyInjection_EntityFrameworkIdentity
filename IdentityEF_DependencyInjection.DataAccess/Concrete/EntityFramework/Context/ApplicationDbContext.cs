using IdentityEF_DependencyInjection.Core.CrossCuttingConcert.Identities.Microsoft.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityEF_DependencyInjection.DataAccess.Concrete.EntityFramework.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
    }
}
