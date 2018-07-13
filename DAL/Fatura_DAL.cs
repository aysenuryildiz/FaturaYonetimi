using DataEntities;
namespace DAL
{
    public class Fatura_DAL
    {
        public void GetList()
        {

        }
        public void Add(Fatura model, FaturaYonetimiDbModel db)
        {
            var ent = db.Entry(model);
            ent.State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }
        public void Update(Fatura model, FaturaYonetimiDbModel db)
        {
            var ent = db.Entry(model);
            ent.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete()
        {

        }
        public void GetById()
        {

        }
    }
}

