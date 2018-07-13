using DataEntities;
using System.Linq;

namespace DAL
{
    public class Fatura_DAL
    {
        
        public void GetList()
        {

        }
        //modeli ekleme
        public void Add(Fatura model, FaturaYonetimiDbModel entity)
        {

            var ent = entity.Entry(model);
            ent.State = System.Data.Entity.EntityState.Added;
            entity.SaveChanges();
        }
        //fatura modelini güncelleme
        public void Update(Fatura model, FaturaYonetimiDbModel entity)
        {
                var ent = entity.Entry(model);
                ent.State = System.Data.Entity.EntityState.Modified;
                entity.SaveChanges();

        }
        public void Delete()
        {

        }
        public void GetById()
        {

        }

        






     



    


    }




}

