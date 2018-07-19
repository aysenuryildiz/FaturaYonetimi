using BLL;
using Entities;
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
            MusteriBLL musteri_BLL = new MusteriBLL();
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

        //public ActionResult MusteriSil(int id)
        //{
        //    MusteriBLL musteri_BLL = new MusteriBLL();
        //    if (musteri_BLL.MusteriSil(id))
        //    {
        //        return RedirectToAction("MusteriListesi");
        //    }
        //    else
        //    {
        //        return RedirectToAction("MusteriListesi");
        //    }
        //}




















        public bool MusteriSil(int id)
        {
            MusteriBLL musteri_BLL = new MusteriBLL();
            if (musteri_BLL.MusteriSil(id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public JsonResult Delete(int ID)
        {
            bool silindiMi = MusteriSil(ID);
            var data = 0;
            if (silindiMi)
            {
                //silindi
                data = 1;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                data = 0;
                return Json(data, JsonRequestBehavior.AllowGet);

            }
        }













    }
}