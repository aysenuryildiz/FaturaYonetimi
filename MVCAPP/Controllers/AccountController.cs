using BLL;
using Entities;
using Microsoft.Owin.Security;
using MVCAPP.BLL;
using System;
using System.Web;
using System.Web.Mvc;

namespace MVCAPP.Controllers
{
    public class AccountController : Controller
    {
        public IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    KullaniciBLL kullanici_BLL = new KullaniciBLL();

                    if (kullanici_BLL.KullaniciKontrolü(model))
                    {
                        new UserAuth().SignIn(model, Authentication);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Hatalı Giriş";
                        return View(model);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            Authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}