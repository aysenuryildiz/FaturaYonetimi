using System;
using System.Linq;
using DataEntities;

namespace DAL
{
    public class StokHareketleri_DAL
    {

    
        //public void StokHareketSil(int ID)
        //{
        //    using (FaturaYonetimiDbModel _entity = new FaturaYonetimiDbModel())
        //    {

        //        try
        //        {
        //            //her seferinde Id yi böyle get yapacağına ayrı bir fonksiyon yaz GetID()
        //            var model = _entity.StokHareketleri.Where(x => x.ID == ID).FirstOrDefault();
        //            _entity.StokHareketleri.Remove(model);
        //            _entity.SaveChanges();



        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}
        //stokhareketlerine modeli kaydetme
        public void Add(StokHareketleri model, FaturaYonetimiDbModel entity)
        {
            var ent = entity.Entry(model);
            ent.State = System.Data.Entity.EntityState.Added;
            entity.StokHareketleri.Add(model);
           
        }
    }
}