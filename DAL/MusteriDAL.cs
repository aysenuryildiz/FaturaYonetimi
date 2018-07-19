using System;
using System.Linq;
using Entities;

namespace DAL
{
    public class MusteriDAL
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
        public void Delete(MusteriProfil model, FaturaYonetimiDbModel db)
        {
            var ent = db.Entry(model);
            ent.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

        }
        public MusteriProfil GetByID(int id, FaturaYonetimiDbModel db)
        {
            var musteriModel = db.MusteriProfil.Where(x => x.ID == id).FirstOrDefault();
            return musteriModel;

        }
        public void Update(MusteriProfil model, FaturaYonetimiDbModel db)
        {
            try
            {
                var ent = db.Entry(model);
                ent.State = System.Data.Entity.EntityState.Modified;

            }

            catch (Exception ex)
            {
                throw;

            }

        }

        public object GetList()
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                var musteri = db.MusteriProfil.ToList();
                return musteri;
            }

            
        }
    }
}


