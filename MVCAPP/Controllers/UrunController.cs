using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVCAPP.Controllers
{
    public class UrunController : Controller
    {
        [Authorize]
        public ActionResult UrunOlustur()
        {
            FaturaYonetimiDbModel db = new FaturaYonetimiDbModel();
            Kategori kategoriID = new Kategori();
            List<SelectListItem> KategoriListesi = new List<SelectListItem>();
            //Urun_BLL urun_BLL = new Urun_BLL();
            //urun_BLL.UrunListesi();
            var kategoriLis = db.Kategori.ToList();
            foreach (var item in kategoriLis)
            {
                if (kategoriID.ID == item.ID)
                {
                    KategoriListesi.Add(new SelectListItem { Text = item.KategoriAd, Value = item.ID.ToString(), Selected = true });
                }
                else
                {
                    KategoriListesi.Add(new SelectListItem { Text = item.KategoriAd, Value = item.ID.ToString() });
                }
            }
            ViewBag.KategoriListesi = KategoriListesi;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult UrunOlustur(Urun urun)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    UrunBLL urunBLL = new UrunBLL();
                    if (urunBLL.UrunKayitVarMi(urun))
                    {
                        urunBLL.UrunKaydet(urun);
                    }
                    else
                    {
                        return RedirectToAction("UrunOlustur");
                    }
                   
                }
                catch
                {
                    throw;
                }

            }

            return RedirectToAction("UrunListesi");
        }

        [Authorize]
        public ActionResult UrunListesi()
        {
            return View();
        }

        public bool UrunSil(int id)
        {
            UrunBLL urunBLL = new UrunBLL();
            if (urunBLL.UrunSil(id))
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
            bool silindiMi = UrunSil(ID);
            var data=0;
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