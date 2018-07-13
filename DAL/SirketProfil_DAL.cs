using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
namespace DAL
{
    public class SirketProfil_DAL
    {
        public SirketProfil GetByID(int id, FaturaYonetimiDbModel _entity)
        {
       
                var saticiModel = _entity.SaticiProfil.Where(x => x.ID == id).FirstOrDefault();
                int sirketid = saticiModel.SirketID;
                var sirketModel = _entity.SirketProfil.Where(x => x.ID == sirketid).FirstOrDefault();

                return sirketModel;

         

        }


        public void SaveChanges(SirketProfil model, FaturaYonetimiDbModel entity)
        {
         
                var ent = entity.Entry(model);
                ent.State = System.Data.Entity.EntityState.Modified;

              



       
        }
    }
}
