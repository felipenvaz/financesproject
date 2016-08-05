using FinancesProject.DAL;
using FinancesProject.Models;
using FinancesProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinancesProject.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                if (Session[Constants.CurrentUser] == null) {
                    using (var context = new FinancesManagerContext())
                    {
                        Session[Constants.CurrentUser] = context.Users.FirstOrDefault(u => u.Name == this.User.Identity.Name);
                    }
                }
                return new RedirectResult(FormsAuthentication.DefaultUrl);
            }
            return new RedirectResult(FormsAuthentication.LoginUrl);
        }

        [HttpGet]
        public ActionResult MakeLogin()
        {
            ViewBag.Warning = TempData["Warning"];
            return View();
        }

        [HttpPost]
        public ActionResult MakeLogin(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = PasswordUtil.HashPassword(loginModel.Password);
                using (var context = new FinancesManagerContext())
                {
                    User user = context.Users.First(u => u.Name == loginModel.UserName && u.Password == hashedPassword);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.Name, false);
                        Session[Constants.CurrentUser] = user;

                        return RedirectToAction("Index", "Finances");
                    }
                }
            }
            return View(loginModel);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("MakeLogin");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = PasswordUtil.HashPassword(model.Password);
                using (var context = new FinancesManagerContext())
                {
                    context.Users.Add(new User()
                    {
                        Name = model.UserName,
                        Password = model.Password
                    });
                    context.SaveChanges();
                }
                TempData["Warning"] = "Account successfully created";
                return RedirectToAction("MakeLogin");
            }
            return View(model);
        }
    }
}
