using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataEntities;

namespace DAL
{
    public class Urun_DAL
    {
        public bool UrunKaydet(Urun _objurun)
        {
            using (FaturaYonetimiDbModel _entity = new FaturaYonetimiDbModel())
            {
                try
                {
                    _objurun.ID = 1;

                    _entity.Urun.Add(_objurun);
                    _entity.SaveChanges();
                }
                catch
                {

                    throw;
                }


            }

            return true;
        }
        public void Delete(Urun model, FaturaYonetimiDbModel _entity)
        {
            var ent = _entity.Entry(model);
            ent.State = System.Data.Entity.EntityState.Deleted;
            _entity.SaveChanges();

        }

     
    }
}
