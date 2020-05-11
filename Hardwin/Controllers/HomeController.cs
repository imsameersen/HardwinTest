using Hardwin.BAL;
using HardWin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hardwin.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly LoginBL loginBL;
        public HomeController()
        {
            this.loginBL = new LoginBL();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                if (this.loginBL.Login(model))
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now,
DateTime.Now.AddMinutes(15), false, model.UserId.ToString());

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("IncorrectPassword", "Email  or password is incorrect.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
      [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index");
        }


        public ActionResult Error()
        {
            return View();
        }

    }
}