using DAL;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace MVCAPP.Controllers
{
    public class StokHareketleriController : Controller
    {
        Urun urunid = new Urun();
        StokHareketleri_BLL obj = new StokHareketleri_BLL();
        [Authorize]
        public ActionResult StokHareketi()
        {
            List<SelectListItem> Urunler = new List<SelectListItem>();
            List<SelectListItem> Saticilar = new List<SelectListItem>();
            FaturaYonetimiDbModel _entity = new FaturaYonetimiDbModel();
            var urun_list = _entity.Urun.ToList();

            foreach (var item in urun_list)

            {
                if (urunid.ID == item.ID)
                {

                    Urunler.Add(new SelectListItem { Text = item.UrunAdi, Value = item.ID.ToString(), Selected = true });

                }

                else

                {

                    Urunler.Add(new SelectListItem { Text = item.UrunAdi, Value = item.ID.ToString() });

                }
            }







            ViewBag.UrunlerListesi = Urunler;
            return View();

        }
        //public ActionResult StokHareketiKaydet(StokHareketleri stokHareket)
        //{
        //    //select list item

        //    obj.StokHareketKaydet(stokHareket);
        //    return RedirectToAction("StokHareketListesi");



        //}
        [Authorize]
        public ActionResult StokHareketListesi(StokHareketleri stokHareket)
        {

            return View();

        }
    }
}