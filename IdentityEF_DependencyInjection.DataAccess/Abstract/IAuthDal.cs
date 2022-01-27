using IdentityEF_DependencyInjection.Core.CrossCuttingConcert.Identities.Microsoft.Users;
using IdentityEF_DependencyInjection.Core.DataAccess;
using IdentityEF_DependencyInjection.Core.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityEF_DependencyInjection.DataAccess.Abstract
{
    public interface IAuthDal : IEntityRepository<ApplicationUser>
    {
        void Login(Login model);
        void Register(Register model);
        void ChangePassword(ChangePassword model);
        void UpdateProfile(ChangeProfile model);
        void Logout();
    }
}
