using System.Linq;
using Entities;

namespace DAL
{
    public class UrunDAL
    {
        public void Add(Urun urunModel)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    StokTakibi stokTakibiModel = new StokTakibi();
                    stokTakibiModel.StokDurumu = 1000;
                    stokTakibiModel.UrunID = urunModel.ID;
                    

                    db.StokTakibi.Add(stokTakibiModel);


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

            var stokmodel = db.StokTakibi.Where(x => x.UrunID == model.ID).FirstOrDefault();
           
            var ent = db.Entry(stokmodel);
            
            ent.State = System.Data.Entity.EntityState.Deleted;
            var urunent = db.Entry(model);
            urunent.State = System.Data.Entity.EntityState.Deleted;
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
