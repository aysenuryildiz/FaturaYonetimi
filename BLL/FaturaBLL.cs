using DAL;
using Entities;
using System;
using System.Collections.Generic;
namespace BLL
{
    public class FaturaBLL
    {
        FaturaDAL faturaDAL;
        #region CTor
        public FaturaBLL()
        {
            faturaDAL = new FaturaDAL();
        }
        #endregion
        #region public Fatura Kaydet


        public string FaturaKaydet(FaturaArguman faturaArguman)
        {
            string mesaj = "";
            StokHareketleriBLL stokHareketleriBLL = new StokHareketleriBLL();
            StokTakibiBLL stokTakibiBLL = new StokTakibiBLL();
            MusteriBLL musteriBLL = new MusteriBLL();

            using (FaturaYonetimiDbModel db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (faturaArguman != null)
                    {

                        var faturaModel = GetFaturaFromArgumant(faturaArguman);
                        var borcKontrol = MusteriBorcKontrolu(faturaModel, db);

                        if (borcKontrol)
                        {
                            stokHareketleriBLL.StokHareketleriKaydet(faturaModel.StokHareketleri, db);
                            FaturaHesapla(faturaModel, faturaModel.StokHareketleri, db);
                            musteriBLL.MusteriAlacakBorcDurumu(faturaModel, faturaModel.MusteriD, db);
                            stokTakibiBLL.StokDurumuGuncelle(faturaModel, faturaModel.StokHareketleri, db);
                            faturaDAL.Add(faturaModel, db);
                            mesaj = "müşterinin borcu fazla olduğu için kayıt edilemedi";
                            //mesaj = StructManager.SUCCESS_MESSAGE;
                        }
                        else
                        {
                            mesaj = "müşterinin borcu fazla olduğu için kayıt edilemedi";
                        }
                    }
                }
                catch
                {
                    throw;
                }
                return mesaj;
            }
        }
        #endregion
        #region Fatura Tutar Hesapla

        /// <summary>FATURANIN ARA TOPLAM,KDV TOPLAM,GENEL TOPLAMININ HESAPLANMASI
        /// <paramref name="model">ARATOPLAM,KDVTOPLAM VE GENELTOPLAMIN HANGİ MODELE SEÇ EDİLECEĞİ</paramref> 
        /// <paramref name="stokHareketleriListesi"> FATURAYA AİT STOK HAREKETLERİ LİSTESİ </paramref>  
        /// <paramref name="db">MODELİ VERME</paramref>
        /// </summary>
        public void FaturaHesapla(Fatura model, ICollection<StokHareketleri> stokHareketleriListesi, FaturaYonetimiDbModel db)
        {
            decimal urunAraToplam;
            decimal urunKdvToplam;
            decimal urunGenelToplam;
            decimal faturaAraToplam = 0;
            decimal faturaKdvToplam = 0;
            decimal faturaGenelToplam = 0;
            foreach (var item in stokHareketleriListesi)
            {
                urunAraToplam = (item.Miktar * item.BirimFiyat);
                urunKdvToplam = (urunAraToplam * (decimal)(item.KdvMiktar / 100));
                urunGenelToplam = urunAraToplam + urunKdvToplam;
                faturaAraToplam += urunAraToplam;
                faturaKdvToplam += urunKdvToplam;
                faturaGenelToplam += urunGenelToplam;

                model.AraToplam = faturaAraToplam;
                model.KDVToplam = faturaKdvToplam;
                model.GenelToplam = faturaGenelToplam;
            }
        }
        #endregion
        #region Fatura GetByID

        public Fatura GetFatura(int id)
        {
            var faturaModel = faturaDAL.GetById(id);
            return faturaModel;
        }
        #endregion
        #region Musteri Borc Kontrolü

        public bool MusteriBorcKontrolu(Fatura model, FaturaYonetimiDbModel db)
        {
            var borcLimit = GetBorcLimit();

            MusteriBLL musteriBLL = new MusteriBLL();
            MusteriProfil musteriProfil = musteriBLL.MusteriGetir(model.MusteriD, db);
            if ((musteriProfil.Borc - musteriProfil.Alacak) > borcLimit)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
        #endregion
        #region  Int32 GetBorcLimit()

        private Int32 GetBorcLimit()
        {
            var borcLimitString = new KeyValueModelHelper().GetValue(StructManager.BORC_LIMIT_KEY);
            var borcLimit = string.IsNullOrEmpty(borcLimitString) ? 100000000 : Convert.ToInt32(borcLimitString);
            return borcLimit;
        }
        #endregion
        #region Fatura GetFaturaFromArgumant

        public Fatura GetFaturaFromArgumant(FaturaArguman faturaArguman)
        {
            Fatura model = new Fatura();
            model.MusteriD = faturaArguman.musteriD;
            model.SaticiID = faturaArguman.saticiID;
            model.FaturaTip = faturaArguman.faturaTip;
            model.FaturaTarihi = faturaArguman.faturaTarihi;
            model.StokHareketleri = faturaArguman.stokHareketleriListesi;
            return model;
        }
        #endregion
    }
}
