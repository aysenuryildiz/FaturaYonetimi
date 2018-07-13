using DAL;
using System.Collections.Generic;
using DataEntities;

namespace BLL
{
    public class StokHareketleri_BLL
    {
        StokHareketleri_DAL StokHareketleriDAL;
        public StokHareketleri_BLL()
        {
            StokHareketleriDAL = new StokHareketleri_DAL();
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

                StokHareketleriDAL.Add(stokHareketleri, db);
            }
        }
    }
}
