using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DataEntities;

namespace BLL
{
    public class Kullanici_BLL
    {
        Kullanici_DAL kullanici_DAL;
        public Kullanici_BLL()
        {
            kullanici_DAL =new Kullanici_DAL();
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
