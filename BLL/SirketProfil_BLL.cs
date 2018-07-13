using DataEntities;
using DAL;
namespace BLL
{
    public class SirketProfil_BLL
    {
        SirketProfil_DAL sirketDAL;
        public SirketProfil_BLL()
        {
            sirketDAL = new SirketProfil_DAL();
        }
        public SirketProfil SirketGetir(int id, FaturaYonetimiDbModel db)
        {
            SirketProfil sirketProfil = sirketDAL.GetByID(id, db);
            return sirketProfil;
        }
        //public void SirketAlacakBorcDurumu(Fatura model, int sirket_id, FaturaYonetimiDbModel _entity)
        //{
        //    SirketProfil sirketProfil = new SirketProfil();


        //        sirketProfil = SirketGetir(sirket_id,_entity); 

        //        if (model.FaturaTip == "ALIS")
        //        {
        //            sirketProfil.Borc = sirketProfil.Borc + model.GenelToplam;
        //        }
        //        else
        //        {

        //            sirketProfil.Alacak = sirketProfil.Alacak + model.GenelToplam;

        //        }

        //        sirketDAL.SaveChanges(sirketProfil,_entity);

    }
}
