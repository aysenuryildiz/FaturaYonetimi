﻿using System.Linq;
using DataEntities;
namespace DAL
{
    public class SirketProfil_DAL
    {
        public SirketProfil GetByID(int id, FaturaYonetimiDbModel db)
        {
            var saticiModel = db.SaticiProfil.Where(x => x.ID == id).FirstOrDefault();
            int sirketid = saticiModel.SirketID;
            var sirketModel = db.SirketProfil.Where(x => x.ID == sirketid).FirstOrDefault();
            return sirketModel;
        }
        public void SaveChanges(SirketProfil model, FaturaYonetimiDbModel entity)
        {
            var ent = entity.Entry(model);
            ent.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
