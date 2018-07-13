using DataEntities;
using System.Linq;

namespace DAL
{
    public class StokTakibi_DAL
    {
        public StokTakibi GetByID(int id, FaturaYonetimiDbModel db)
        {
            var stokTakibiModel = db.StokTakibi.Where(x => x.UrunID == id).FirstOrDefault();
            return stokTakibiModel;
        }
        public void Update(StokTakibi model, FaturaYonetimiDbModel db)
        {
            var ent = db.Entry(model);
            ent.State = System.Data.Entity.EntityState.Modified;
        }

    }
}
