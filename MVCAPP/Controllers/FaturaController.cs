using System.Collections.Generic;
using System.Linq;
using DataEntities;
using System.Web.Mvc;
using BLL;
using System.Web.UI.WebControls;

namespace MVCAPP.Controllers
{
    public class FaturaController : Controller
    {
        Fatura_BLL obj = new Fatura_BLL();

        [Authorize]
        public ActionResult FaturaOlustur()
        {

            FaturaYonetimiDbModel _entity = new FaturaYonetimiDbModel();
            Fatura musteriid = new Fatura();
            Fatura saticiid = new Fatura();
            List<SelectListItem> Musteriler = new List<SelectListItem>();
            List<SelectListItem> Saticilar = new List<SelectListItem>();
           var musteri_list = _entity.MusteriProfil.ToList();
            var satici_list = _entity.SaticiProfil.ToList();
        
        
            foreach (var item in musteri_list)

            {
                if (musteriid.MusteriD == item.ID)
                {
                    Musteriler.Add(new SelectListItem { Text = item.Ad, Value = item.ID.ToString(), Selected = true });
                }
                else

                {
                    Musteriler.Add(new SelectListItem { Text = item.Ad + " " + item.Soyad, Value = item.ID.ToString() });
                }
            }
            foreach (var item in satici_list)
            {
                if (saticiid.SaticiID == item.ID)
                {
                    Saticilar.Add(new SelectListItem { Text = item.Departman, Value = item.ID.ToString(), Selected = true });
                }
                else
                {
                    Saticilar.Add(new SelectListItem { Text = item.Departman, Value = item.ID.ToString() });
                }
            }

            ViewBag.MusteriListesi = Musteriler;
            ViewBag.SaticiListesi = Saticilar;
            
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult FaturaListele(string searching)
        {
            return View();
        }

        //public ActionResult EditFatura(int id)
        //{
        //    using (FaturaYonetimiDbModel db = new FaturaYonetimiDbModel())
        //    {
        //        Fatura musteriid = new Fatura();
        //        Fatura saticiid = new Fatura();

        //        List<SelectListItem> Musteriler = new List<SelectListItem>();
        //        List<SelectListItem> Saticilar = new List<SelectListItem>();

        //        var musteri_list = db.MusteriProfil.ToList();
        //        var satici_list = db.SaticiProfil.ToList();

        //        foreach (var item in musteri_list)

        //        {
        //            if (musteriid.MusteriD == item.ID)
        //            {
        //                Musteriler.Add(new SelectListItem { Text = item.Ad, Value = item.ID.ToString(), Selected = true });
        //            }
        //            else

        //            {
        //                Musteriler.Add(new SelectListItem { Text = item.Ad + " " + item.Soyad, Value = item.ID.ToString() });
        //            }
        //        }
        //        foreach (var item in satici_list)
        //        {
        //            if (saticiid.SaticiID == item.ID)
        //            {
        //                Saticilar.Add(new SelectListItem { Text = item.Departman, Value = item.ID.ToString(), Selected = true });
        //            }
        //            else
        //            {
        //                Saticilar.Add(new SelectListItem { Text = item.Departman, Value = item.ID.ToString() });
        //            }
        //        }

        //        ViewBag.MusteriListesi = Musteriler;
        //        ViewBag.SaticiListesi = Saticilar;
        //        var fatura = db.Fatura.Where(x => x.ID == id).FirstOrDefault();
        //        return View(fatura);

        //    }


        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Fatura fatura)
        //{
        //    using (FaturaYonetimiDbModel db = new FaturaYonetimiDbModel())
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(fatura).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(fatura);
        //    }

        //}


        [Authorize]
        public ActionResult SaveOrder(int MusteriD, int SaticiID, string FaturaTip, string FaturaTarihi,ICollection<StokHareketleri> order)
        {
            FaturaArguman faturaArguman = new FaturaArguman();

            faturaArguman.musteriD = MusteriD;
            faturaArguman.saticiID = SaticiID;
            faturaArguman.faturaTip = FaturaTip;
            faturaArguman.faturaTarihi = FaturaTarihi;
            faturaArguman.stokHareketleriListesi = order;
            string result = obj.FaturaKaydet(faturaArguman);

            return Json(new { code = 1 }, result, JsonRequestBehavior.AllowGet);

        }

        //public ActionResult Print()
        //{
        //    FaturaYonetimiDbModel entity = new FaturaYonetimiDbModel();

        //    FaturaDTOtoMain saticiid = new FaturaDTOtoMain();
        //    List<SelectListItem> Saticilar = new List<SelectListItem>();
        //    var satici_list = entity.SaticiProfil.ToList();
        //    foreach (var item in satici_list)

        //    {
        //        if (saticiid.SaticiID == item.ID)
        //        {

        //            Saticilar.Add(new SelectListItem { Text = item.Departman, Value = item.ID.ToString(), Selected = true });

        //        }

        //        else

        //        {

        //            Saticilar.Add(new SelectListItem { Text = item.Departman, Value = item.ID.ToString() });

        //        }
        //    }
        //    ViewBag.SaticiListesi = Saticilar;

        //    return View();
        //}











    }
}