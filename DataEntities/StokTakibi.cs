namespace DataEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StokTakibi")]
    public partial class StokTakibi
    {
        public int ID { get; set; }

        public int UrunID { get; set; }

        public int? StokDurumu { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
