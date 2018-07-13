using DAL;
using System;
using System.Linq;
using DataEntities;
namespace BLL
{
    public class Musteri_BLL
    {
        Musteri_DAL musteriDAL;
        public Musteri_BLL()
        {
            musteriDAL = new Musteri_DAL();
        }
        public void MusteriKaydet(MusteriProfil musteriProfil)
        {
            musteriDAL.Add(musteriProfil);
        }
        public bool MusteriSil(int ID)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                var musteriModel = MusteriGetir(ID, db);
                var faturaModel_musteriID = musteriModel.ID;
                try
                {
                    if (FaturaMusteriKontrolü(faturaModel_musteriID))
                    {
                        musteriDAL.Delete(musteriModel, db);
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception("There was a problem saving this record: " + e.Message);
                }
            }
        }
        public MusteriProfil MusteriGetir(int id, FaturaYonetimiDbModel db)
        {
            MusteriProfil musteriProfil = musteriDAL.GetByID(id, db);
            return musteriProfil;

        }
        public void MusteriAlacakBorcDurumu(Fatura model, int musteri_id, FaturaYonetimiDbModel db)
        {
            MusteriProfil musteriProfil = new MusteriProfil();
            musteriProfil = MusteriGetir(musteri_id, db);

            if (model.FaturaTip == "ALIS")
            {
                musteriProfil.Alacak = musteriProfil.Alacak + model.GenelToplam;
            }
            else
            {
                musteriProfil.Borc = musteriProfil.Borc + model.GenelToplam;
            }
            musteriDAL.Update(musteriProfil, db);
        }
        public bool KayitVarMi(MusteriProfil output)
        {
            var ad = output.Ad;
            var soyad = output.Soyad;
            var adres = output.Adres;

            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (db.MusteriProfil.Any(x => x.Ad == ad && x.Soyad == soyad && x.Adres == adres))
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception("There was a problem saving this record: " + e.Message);
                }
            }
        }
        public bool FaturaMusteriKontrolü(int id)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (db.Fatura.Any(x => x.MusteriD == id))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        //public Dictionary<string, string> Dogrula(MusteriProfil musteri)
        //{
        //    var result = new Dictionary<string, string>();




        //    //var isExists = MusteriDAL.Get(x => x.Ad == musteri.Ad).Any();
        //    //if(isExists)
        //    //result.Add("musteriAd", "Bu müşteri adı daha önceden kayıt edşlmştir");

        //    //var isExists = MusteriDAL.Get(x => x.Ad == musteri.SoyAd).Any();
        //    //if(isExists)
        //    //result.Add("musteriSyoAd", "Bu müşteri soyad daha önceden kayıt edşlmştir");

        //    return result;
        //}

    }
}