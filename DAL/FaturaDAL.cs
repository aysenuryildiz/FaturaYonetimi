using Entities;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FaturaDAL
    {
        public void GetList()
        {

        }
        public void Add(Fatura model, FaturaYonetimiDbModel db)
        {
            try
            {
                var ent = db.Entry(model);
                ent.State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)

            {

                Exception raise = dbEx;

                foreach (var validationErrors in dbEx.EntityValidationErrors)

                {

                    foreach (var validationError in validationErrors.ValidationErrors)

                    {

                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);

                        //InnerException raise = new InvalidOperationException(message, raise);

                    }

                }

                throw raise;
            }
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
        public Fatura GetById(int id)
        {
            FaturaYonetimiDbModel db = new FaturaYonetimiDbModel();
            Fatura fatura = db.Fatura.Where(x => x.ID == id).FirstOrDefault();
          
            return fatura;
        }
    }
}

