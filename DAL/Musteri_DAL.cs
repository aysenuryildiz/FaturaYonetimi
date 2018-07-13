using System;
using System.Linq;
using DataEntities;

namespace DAL
{
    public class Musteri_DAL
    {
        public void Add(MusteriProfil musteri)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    db.MusteriProfil.Add(musteri);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
                

        }
        public void Delete(MusteriProfil model, FaturaYonetimiDbModel _entity)
        {
            var ent = _entity.Entry(model);
            ent.State = System.Data.Entity.EntityState.Deleted;
            _entity.SaveChanges();

        }
        public MusteriProfil GetByID(int id, FaturaYonetimiDbModel _entity)
        {
            var musteriModel = _entity.MusteriProfil.Where(x => x.ID == id).FirstOrDefault();
            return musteriModel;

        }
        public void Update(MusteriProfil model, FaturaYonetimiDbModel entity)
        {
            try
            {
                var ent = entity.Entry(model);
                ent.State = System.Data.Entity.EntityState.Modified;

            }

            catch (Exception ex)
            {
                throw;

            }

        }
        public bool MusteriKontrolü(int id)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (db.Fatura.Any(x => x.MusteriD == id))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }


    }
}


