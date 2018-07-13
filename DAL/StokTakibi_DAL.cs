using DataEntities;
using System.Linq;

namespace DAL
{
    public class StokTakibi_DAL
    {
        //seçilen ürüne ait stok durumunu getirme
        public StokTakibi GetByID(int id, FaturaYonetimiDbModel _entity)
        {
                var stokTakibiModel = _entity.StokTakibi.Where(x => x.UrunID == id).FirstOrDefault();
                return stokTakibiModel;
        }
        //stok durumunu güncelleme
        public void Update(StokTakibi model, FaturaYonetimiDbModel entity)
        {
                var ent = entity.Entry(model);
                ent.State = System.Data.Entity.EntityState.Modified;
        }

    }
}
