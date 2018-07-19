using BLL;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace MVCAPP.Controllers
{
    public class FaturaController : Controller
    {
        #region CTor
        [Authorize]

        public ActionResult FaturaOlustur()
        {
            FaturaBLL fatura_BLL = new FaturaBLL();
            FaturaYonetimiDbModel db = new FaturaYonetimiDbModel();
            Fatura musteriid = new Fatura();
            Fatura saticiid = new Fatura();
            List<SelectListItem> Musteriler = new List<SelectListItem>();
            List<SelectListItem> Saticilar = new List<SelectListItem>();
            var musteri_list = db.MusteriProfil.ToList();
            var satici_list = db.SaticiProfil.ToList();
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
        #endregion
        #region Public Fatura Listesi Action
        [HttpGet]
        [Authorize]

        public ActionResult FaturaListele()
        {
            return View();
        }
        #endregion
        #region Public Fatura Kaydet Action
        [Authorize]

        public ActionResult SaveOrder(int MusteriD, int SaticiID, string FaturaTip, string FaturaTarihi, ICollection<StokHareketleri> order)
        {

            if (ModelState.IsValid)
            {

                FaturaArguman faturaArguman = new FaturaArguman();
                FaturaBLL fatura_BLL = new FaturaBLL();
                faturaArguman.musteriD = MusteriD;
                faturaArguman.saticiID = SaticiID;
                faturaArguman.faturaTip = FaturaTip;
                faturaArguman.faturaTarihi = FaturaTarihi;
                faturaArguman.stokHareketleriListesi = order;
                string result = fatura_BLL.FaturaKaydet(faturaArguman);
                return Json(new { code = 1 }, result, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("FaturaListele");
        }
        #endregion
        #region Public Fatura Detay View
        [Authorize]
        public ActionResult Details(int id)
        {
            FaturaBLL fatura_BLL = new FaturaBLL();
            var fatura = fatura_BLL.GetFatura(id);
            if (fatura == null)
                return View("NotFound");
            else
                return View("Details", fatura);
        }
        #endregion


      
    }
}