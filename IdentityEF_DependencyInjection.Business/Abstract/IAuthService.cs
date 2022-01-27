using IdentityEF_DependencyInjection.Core.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityEF_DependencyInjection.Business.Abstract
{
    public interface IAuthService
    {
        void Login(Login model);
        void Register(Register model);
        void ChangePassword(ChangePassword model);
        void UpdateProfile(ChangeProfile model);
        void Logout();
    }
}
