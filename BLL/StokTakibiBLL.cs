﻿using DAL;
using System.Collections.Generic;
using Entities;
using System.Net.Mail;

namespace BLL
{
    public class StokTakibiBLL
    {
        StokTakibiDAL stokTakipDal;
        public StokTakibiBLL()
        {
            stokTakipDal = new StokTakibiDAL();
        }
        public StokTakibi StokTakibiIdGetir(int id, FaturaYonetimiDbModel db)
        {
            StokTakibi stokTakibi = stokTakipDal.GetByID(id, db);
            return stokTakibi;
        }
        public bool StokDurumuGuncelle(Fatura model, ICollection<StokHareketleri> stokHareketleriListesi, FaturaYonetimiDbModel db)
        {
            if (model.FaturaTip == "ALIS")
            {
                UrunStokDurumGuncellemeAlisIcin(stokHareketleriListesi, db);
            }
            else if (model.FaturaTip == "SATIS")
            {
                UrunStokDurumGuncellemeSatisIcin(stokHareketleriListesi, db);
            }




            return true;
        }

        private void UrunStokDurumGuncellemeAlisIcin(ICollection<StokHareketleri> stokHareketleriListesi, FaturaYonetimiDbModel db)
        {
            foreach (var item in stokHareketleriListesi)
            {
                var stokTakibi = StokTakibiIdGetir(item.UrunID, db);
                stokTakibi.StokDurumu = stokTakibi.StokDurumu + item.Miktar;
                stokTakipDal.Update(stokTakibi, db);
            }
        }

        private void UrunStokDurumGuncellemeSatisIcin(ICollection<StokHareketleri> stokHareketleriListesi, FaturaYonetimiDbModel db)
        {
            foreach (var item in stokHareketleriListesi)
            {
                var stokTakibi = StokTakibiIdGetir(item.UrunID, db);
                stokTakibi.StokDurumu = StokDurumHesapla(stokTakibi.StokDurumu, item.Miktar);
                stokTakipDal.Update(stokTakibi, db);
                if (stokTakibi.StokDurumu < 10)
                {
                    SendMailforStokDurumu(stokHareketleriListesi);
                }
            }
        }

        private int StokDurumHesapla(int? mevcutBakiye, int eklenenBakiyeMiktari)
        {
            var mevcutBakiyeDurum = mevcutBakiye ?? 0;
            return mevcutBakiyeDurum - eklenenBakiyeMiktari;
        }
        public void SendMailforStokDurumu(ICollection<StokHareketleri> stokHareketleriListesi)
        {
            foreach (var item in stokHareketleriListesi)
            {

                //SmtpClient client = new SmtpClient("some.server.com");
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = "someone@somewhere.com";
                //mailMessage.To.Add("someone.else@somewhere-else.com");
                //mailMessage.Subject = "Hello There";
                //mailMessage.Body = "Hello my friend!";
                //client.Send(mailMessage);

            }
        }
    }
}