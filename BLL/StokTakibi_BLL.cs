using DAL;
using System.Collections.Generic;
using DataEntities;
namespace BLL
{
    public class StokTakibi_BLL
    {
        StokTakibi_DAL stokTakipDal;
        public StokTakibi_BLL()
        {
            stokTakipDal = new StokTakibi_DAL();
        }
        public StokTakibi StokTakibiIdGetir(int id, FaturaYonetimiDbModel _entity)
        {
            StokTakibi stokTakibi = stokTakipDal.GetByID(id, _entity);
            return stokTakibi;
        }
        public bool StokDurumuGuncelle(Fatura model, ICollection<StokHareketleri> stokHareketleriListesi, FaturaYonetimiDbModel _entity)
        {
            StokTakibi stokTakibi = new StokTakibi();
            if (model.FaturaTip == "ALIS")
            {
                foreach (var item in stokHareketleriListesi)
                {
                    stokTakibi = StokTakibiIdGetir(item.UrunID, _entity);
                    stokTakibi.StokDurumu = stokTakibi.StokDurumu + item.Miktar;
                    stokTakipDal.Update(stokTakibi, _entity);
                }

            }
            else if (model.FaturaTip == "SATIS")
            {
                foreach (var item in stokHareketleriListesi)
                {
                    StokTakibiIdGetir(item.UrunID, _entity);
                    stokTakibi.StokDurumu = stokTakibi.StokDurumu - item.Miktar;
                    stokTakipDal.Update(stokTakibi, _entity);
                }

            }
            return true;
        }
    }
}
