using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;

namespace BLL
{
    public class Urun_BLL
    {
        Urun_DAL urunDAL;
        public Urun_BLL()
        {
            urunDAL = new Urun_DAL();
        }

        public bool UrunKaydet(Urun _objurun)
        {
            return urunDAL.UrunKaydet(_objurun);
        }
        public bool UrunSil(int ID)
        {



            using (var db = new FaturaYonetimiDbModel())
            {
                var urun = db.Urun.Where(x => x.ID == ID).FirstOrDefault();
                var stok_urunID = urun.ID;
                try
                {
                    if (db.StokHareketleri.Any(x => x.UrunID == stok_urunID))
                    {
                        return false;
                    }

                    urunDAL.Delete(urun, db);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception("There was a problem saving this record: " + e.Message);
                }
            }

        }
        public bool KayitVarMi(Urun output)
        {
            var katID = output.KategoriID;
            var urunAdi = output.UrunAdi;
           

            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (db.Urun.Any(x => x.KategoriID == katID && x.UrunAdi == urunAdi))
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



    }
}
