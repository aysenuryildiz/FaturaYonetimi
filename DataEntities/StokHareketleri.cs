namespace DataEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StokHareketleri")]
    public partial class StokHareketleri
    {
        public int ID { get; set; }

        public int FaturaID { get; set; }

        public int UrunID { get; set; }

        public int Miktar { get; set; }

        [Column(TypeName = "money")]
        public decimal BirimFiyat { get; set; }

        public double? KdvMiktar { get; set; }

        public virtual Fatura Fatura { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
