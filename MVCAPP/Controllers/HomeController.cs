using Entities;
using System.Web.Mvc;
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