using DataEntities;

namespace DAL
{
    public class StokHareketleri_DAL
    {
        public void Add(StokHareketleri model, FaturaYonetimiDbModel db)
        {
            var ent = db.Entry(model);
            ent.State = System.Data.Entity.EntityState.Added;
            db.StokHareketleri.Add(model);

        }
    }
}