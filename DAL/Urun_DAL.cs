using System.Linq;
using DataEntities;

namespace DAL
{
    public class Urun_DAL
    {
        public void Add(Urun urunModel)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    db.Urun.Add(urunModel);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }
        public void Delete(Urun model, FaturaYonetimiDbModel db)
        {
            var ent = db.Entry(model);
            ent.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

        }
        public Urun GetByID(int id, FaturaYonetimiDbModel db)
        {
            var urunModel = db.Urun.Where(x => x.ID == id).FirstOrDefault();
            return urunModel;
        }
        public void GetList()
        {
            using (var db = new FaturaYonetimiDbModel())
            {

            }
        }
    }
}
