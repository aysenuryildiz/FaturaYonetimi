using DAL;
using System.Collections.Generic;
using Entities;

namespace BLL
{
    public class StokHareketleriBLL
    {
        StokHareketleriDAL StokHareketleriDAL;
        public StokHareketleriBLL()
        {
            StokHareketleriDAL = new StokHareketleriDAL();
        }
        public void StokHareketleriKaydet(ICollection<StokHareketleri> stokHareketleriListesi, FaturaYonetimiDbModel db)
        {
            foreach (var item in stokHareketleriListesi)
            {
                StokHareketleri stokHareketleri = new StokHareketleri();

                stokHareketleri.UrunID = item.UrunID;
                stokHareketleri.Miktar = item.Miktar;
                stokHareketleri.BirimFiyat = item.BirimFiyat;
                stokHareketleri.KdvMiktar = item.KdvMiktar;

                //StokHareketleriDAL.Add(stokHareketleri, db);
            }
        }
    }
}
