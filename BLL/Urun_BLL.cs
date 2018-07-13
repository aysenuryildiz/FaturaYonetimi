using DAL;
using System;
using DataEntities;
using System.Linq;

namespace BLL
{
    public class Urun_BLL
    {
        Urun_DAL urunDAL;
        public Urun_BLL()
        {
            urunDAL = new Urun_DAL();
        }
        public void UrunKaydet(Urun urunModel)
        {
            urunDAL.Add(urunModel);
        }
        public bool UrunSil(int ID)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                var urun = urunDAL.GetByID(ID, db);
                var stok_urunID = urun.ID;

                try
                {
                    if (UrunSatisKontrolü(stok_urunID, db))
                    {
                        urunDAL.Delete(urun, db);
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
        public bool UrunKayitVarMi(Urun urunModel)
        {
            var kategoriID = urunModel.KategoriID;
            var urunAdi = urunModel.UrunAdi;
            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (db.Urun.Any(x => x.KategoriID == kategoriID && x.UrunAdi == urunAdi))
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
        public bool UrunSatisKontrolü(int stok_urunID, FaturaYonetimiDbModel db)
        {
            if (db.StokHareketleri.Any(x => x.UrunID == stok_urunID))
            {
                return false;
            }
            return true;
        }
        public void UrunListesi()
        {
            Kategori kategoriID = new Kategori();
            using (var db = new FaturaYonetimiDbModel())
            {
            }

            urunDAL.GetList();
        }
    }
}
