using DAL;
using Entities;

namespace BLL
{
    public class KullaniciBLL
    {
        KullaniciDAL kullanici_DAL;
        public KullaniciBLL()
        {
            kullanici_DAL = new KullaniciDAL();
        }
        public bool KullaniciKontrolü(LoginModel loginModel)
        {
            var email = loginModel.Email;
            var password = loginModel.Password;
            kullanici_DAL.KullaniciKontrolü(email, password);
            if (kullanici_DAL.KullaniciKontrolü(email, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
