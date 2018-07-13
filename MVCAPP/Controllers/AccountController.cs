﻿using BLL;
using DataEntities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MVCAPP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            Kullanici_BLL kullanici_BLL = new Kullanici_BLL();

         
            if (ModelState.IsValid)
            {
                try
                {
                    if (kullanici_BLL.KullaniciKontrolü(model))
                    {
                        new UserAuth().SignIn(model, Authentication);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Lütfen email ve şifreyi doğru bir şekilde giriniz";
                        return View(model);
                    }
                }
                catch (Exception e)
                {

                }
                //new UserAuth().SignIn(model, Authentication);
                //SignIn(model);
                //checkuser authentication method
                //send model
                //bll e gidecek 
                //

            }
            //ViewBag.Message = "Kullanıcı Adı veya Şifre  Hatalı";
            return View(model);
        }


        public ActionResult LogOut()
        {
            Authentication.SignOut();
            return RedirectToAction("Login");

        }
        //public void ggg() { }
    }
}