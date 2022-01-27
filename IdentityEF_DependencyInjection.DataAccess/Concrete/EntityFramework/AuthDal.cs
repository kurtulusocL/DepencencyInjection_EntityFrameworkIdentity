using IdentityEF_DependencyInjection.Core.CrossCuttingConcert.Identities.Microsoft.Roles;
using IdentityEF_DependencyInjection.Core.CrossCuttingConcert.Identities.Microsoft.Users;
using IdentityEF_DependencyInjection.Core.DataAccess.EntityFramework;
using IdentityEF_DependencyInjection.Core.Dtos.AuthDtos;
using IdentityEF_DependencyInjection.DataAccess.Abstract;
using IdentityEF_DependencyInjection.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IdentityEF_DependencyInjection.DataAccess.Concrete.EntityFramework
{
    public class AuthDal : EntityRepositoryBase<ApplicationUser, ApplicationDbContext>, IAuthDal
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AuthDal()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
        }

        public void ChangePassword(ChangePassword model)
        {
            IdentityUser user = userManager.FindByName(HttpContext.Current.User.Identity.Name);
            IdentityResult result = userManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut();
            }
        }

        public void Login(Login model)
        {
            ApplicationUser user = userManager.Find(model.Username, model.Password);
            if (user != null)
            {
                var username = user.UserName;
                IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;
                ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                AuthenticationProperties authProps = new AuthenticationProperties();
                authProps.IsPersistent = model.RememberMe;
                authManager.SignIn(authProps, identity);
            }
        }

        public void Logout()
        {
            IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
        }

        public void Register(Register model)
        {
            ApplicationUser user = new ApplicationUser();

            user.UserName = model.Username;
            user.NameLastname = model.NameSurname;
            user.Email = model.Email;
            user.Birthdate = model.Birthdate;
            user.City = model.City;
            user.Country = model.Country;
            user.Gender = model.Gender;
            user.PhoneNumber = model.PhoneNumber;
            user.CreatedDate = model.CreatedDate.ToLocalTime();
            user.Province = model.Province;

            IdentityResult iResult = userManager.Create(user, model.Password);
            if (iResult.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");             
            }
        }

        public void UpdateProfile(ChangeProfile model)
        {
            ApplicationUser user = userManager.FindByName(HttpContext.Current.User.Identity.Name);

            user.UserName = model.Username;
            user.Country = model.Country;
            user.Province = model.Province;
            user.City = model.City;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;

            userManager.Update(user);
        }
    }
}
