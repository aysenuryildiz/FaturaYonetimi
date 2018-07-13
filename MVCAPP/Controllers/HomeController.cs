using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
namespace MVCAPP.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {

            int userID = User.Identity.GetUserId<int>();
            string name = User.Identity.GetUserName();

            var user = new UserModel { UserID = userID, Name = name };
            return View(user);
        }

      

    }
}