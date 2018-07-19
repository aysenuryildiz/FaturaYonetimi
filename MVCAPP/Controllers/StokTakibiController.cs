using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAPP.Controllers
{
    public class StokTakibiController : Controller
    {
      
        public ActionResult StokDurumListesi()
        {
            return View();
        }
    }
}