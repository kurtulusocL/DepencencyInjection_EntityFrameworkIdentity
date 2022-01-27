using IdentityEF_DependencyInjection.Business.Abstract;
using IdentityEF_DependencyInjection.Core.Dtos.AuthDtos;
using IdentityEF_DependencyInjection.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityEF_DependencyInjection.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IAuthDal _authDal;
        public AuthManager(IAuthDal authDal)
        {
            _authDal = authDal;
        }
        public void ChangePassword(ChangePassword model)
        {
            _authDal.ChangePassword(model);
        }

        public void Login(Login model)
        {
            _authDal.Login(model);
        }

        public void Logout()
        {
            _authDal.Logout();
        }

        public void Register(Register model)
        {
            _authDal.Register(model);
        }

        public void UpdateProfile(ChangeProfile model)
        {
            _authDal.UpdateProfile(model);
        }
    }
}
