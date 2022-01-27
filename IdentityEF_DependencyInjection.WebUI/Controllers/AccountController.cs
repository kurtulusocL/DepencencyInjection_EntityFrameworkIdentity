using IdentityEF_DependencyInjection.Business.Abstract;
using IdentityEF_DependencyInjection.Core.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityEF_DependencyInjection.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                _authService.Login(model);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction(nameof(Login));
        }

        public ActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                _authService.Register(model);
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction(nameof(Register));
        }

        public ActionResult ChangeProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfile(ChangeProfile model)
        {
            if (ModelState.IsValid)
            {
                _authService.UpdateProfile(model);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction(nameof(ChangeProfile));
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                _authService.ChangePassword(model);
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
    }
}