using DataEntities;
using System.Web.Mvc;
namespace MVCAPP.Controllers
{
    public class StokHareketleriController : Controller
    {
        [Authorize]
        public ActionResult StokHareketListesi(StokHareketleri stokHareket)
        {
            return View();
        }
    }
}