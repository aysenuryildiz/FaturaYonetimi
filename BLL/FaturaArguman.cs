using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class FaturaArguman
    { 
        public int musteriD;
        public int saticiID;
        public string faturaTip;
        public string faturaTarihi;
        public ICollection<StokHareketleri> stokHareketleriListesi;

    }
}

