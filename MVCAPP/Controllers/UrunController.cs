using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using DataEntities;


namespace MVCAPP.Controllers
{
    public class UrunController : Controller
    {
        //fatura olustur view
        [Authorize]
        public ActionResult UrunOlustur()
        {
            FaturaYonetimiDbModel db = new FaturaYonetimiDbModel();

            Kategori kategoriID = new Kategori();
            List<SelectListItem> KategoriListesi = new List<SelectListItem>();
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
            Urun_BLL obj = new Urun_BLL();
            string result = "";
            if (ModelState.IsValid)
            {
                try
                {
                    if (obj.KayitVarMi(urun))
                    {
                        obj.UrunKaydet(urun);
                        result = "Urun KAYDETME BAŞARILI";
                    }
                    else
                    {
                        result = "Urun KAYDETME BAŞARISIZ";
                    }
                }
                catch (Exception e)
                {
                    result = "Urun KAYDETME BAŞARISIZ";
                }

            }
            //bunu faturadaki gibi mesaj göster

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        //fatura listele view
        [Authorize]
        public ActionResult UrunListesi(/*string searching*/)
        {

            //using (FaturaYonetimiDbModel db = new FaturaYonetimiDbModel())
            //{
            //    return View(db.Urun.Where(x => x.UrunAdi.Contains(searching) || searching == null).ToList());
            //}
            return View();


        }

        public ActionResult UrunSil(int id)
        {
            Urun_BLL obj = new Urun_BLL();
            if (obj.UrunSil(id))
            {
                return RedirectToAction("UrunListesi");
            }
            else
            {
                return RedirectToAction("UrunListesi");
            }
        }

    }
}