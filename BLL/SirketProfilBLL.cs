using Entities;
using DAL;
namespace BLL
{
    public class SirketProfilBLL
    {
        SirketProfilDAL sirketDAL;
        public SirketProfilBLL()
        {
            sirketDAL = new SirketProfilDAL();
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
