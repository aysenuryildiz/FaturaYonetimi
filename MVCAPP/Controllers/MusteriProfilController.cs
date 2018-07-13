using BLL;
using DataEntities;
using System.Web.Mvc;
namespace MVCAPP.Controllers
{
    public class MusteriProfilController : Controller
    {
        [Authorize]
        public ActionResult MusteriOlustur()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult MusteriOlustur(MusteriProfil musteri)
        {
            Musteri_BLL musteri_BLL = new Musteri_BLL();
            //var resultCustomValidation = obj.Dogrula(musteri);
            //if(resultCustomValidation != null)
            //{
            //    foreach
            //        ModelState.AddModelError("sfafs", "Seçmiş olduğunuz stok depoda yeterli sayıda değildir. İşlemşniz iptal edildi.");
            //}
            if (ModelState.IsValid)
            {
                try
                {
                    if (musteri_BLL.KayitVarMi(musteri))
                    {
                        musteri_BLL.MusteriKaydet(musteri);
                    }
                    else
                    {
                    }
                }
                catch
                {
                    throw;
                }
            }
            return RedirectToAction("MusteriListesi");
        }

        [Authorize]
        public ActionResult MusteriListesi(MusteriProfil musteri)
        {
            return View();
        }

        public ActionResult MusteriSil(int id)
        {
            Musteri_BLL musteri_BLL = new Musteri_BLL();
            if (musteri_BLL.MusteriSil(id))
            {
                return RedirectToAction("MusteriListesi");
            }
            else
            {
                return RedirectToAction("MusteriListesi");
            }
        }
    }
}