using DAL;
using DataEntities;
using System.Collections.Generic;
namespace BLL
{
    public class Fatura_BLL
    {
        Fatura_DAL faturaDAL;
        public Fatura_BLL()
        {
            faturaDAL = new Fatura_DAL();
        }
      
        public string FaturaKaydet(FaturaArguman faturaArguman)
        {
            // Fatura argümanlarının kontrolü
            // - Model Validasyon, (başka bir yerde yapılmıyor ise !) (bence hertürlü =) )
            // - Logic validasyon ( kesinlilkle ) 

            // DTO objeceleri ; DataTransferObject
            // Fatura => ana nesnen
            // Id, MüşteriModel(MüşteriAdi, MüşteriVKN), FaturaTarih, AraToplam, KDV, GenelToplam
            // class FaturaDTOToList
            // class FaturaDTOToDetail

            //var arguman = new FaturaArguman
            //{
            //    musteriAdi = MusteriD,
            //};
            //var fatura = GetFaturaFromArgumant(arguman);

            // Fatura Insert    => FaturaDAL.Add(fatura);

            // Stok bakiye güncelle

            // .. bilgilendirme maili gönder

            // ...
            string mesaj = "";
            StokHareketleri_BLL stokHareketleriBLL = new StokHareketleri_BLL();
            StokTakibi_BLL stokTakibiBLL = new StokTakibi_BLL();
            Musteri_BLL musteriBLL = new Musteri_BLL();
            SirketProfil_BLL sirketBLL = new SirketProfil_BLL();
            
            using (FaturaYonetimiDbModel db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (faturaArguman != null)
                    {
                        ///<summary>
                        ///if (MusteriD != 0 && SaticiID != 0 && FaturaTip != null && FaturaTarihi != null)
                        ///FaturaArguman faturaArguman = new FaturaArguman();
                        ///Fatura fatura = faturaArguman.FaturaArgumanlariDoldur(fatur);
                        ///  master alan kaydet
                        ///Fatura model = new Fatura();
                        ///model.MusteriD = MusteriD;
                        ///model.SaticiID = SaticiID;
                        ///model.FaturaTip = FaturaTip;
                        ///model.FaturaTarihi = FaturaTarihi;
                        /// </summary>
                        var faturaModel = GetFaturaFromArgumant(faturaArguman);
                        if (MusteriBorcKontrolu(faturaModel, db))
                        {
                            //detail alan kaydet
                            stokHareketleriBLL.StokHareketleriKaydet(faturaModel.StokHareketleri, db);


                            //aratoplam,kdvtoplam,geneltoplam hesapla
                            FaturaHesapla(faturaModel, faturaModel.StokHareketleri, db);

                            //müşteri-şirket alacak borc durumunu güncelle
                            musteriBLL.MusteriAlacakBorcDurumu(faturaModel, faturaModel.MusteriD, db);



                            //stok durumunu güncelle
                            stokTakibiBLL.StokDurumuGuncelle(faturaModel, faturaModel.StokHareketleri, db);
                            faturaDAL.Add(faturaModel, db);
                            mesaj = "kayıt başarılı";
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

        public bool MusteriBorcKontrolu(Fatura model, FaturaYonetimiDbModel db)
        {
            Musteri_BLL musteriBll = new Musteri_BLL();
            MusteriProfil musteriProfil = musteriBll.MusteriGetir(model.MusteriD, db);
            if ((musteriProfil.Alacak-musteriProfil.Borc)<10000)
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
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
    }
}
