namespace DataEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fatura")]
    public partial class Fatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fatura()
        {
            StokHareketleri = new HashSet<StokHareketleri>();
        }

        public int ID { get; set; }

        public int MusteriD { get; set; }

        public int SaticiID { get; set; }

        [Required]
        [StringLength(10)]
        public string FaturaTip { get; set; }

        [StringLength(50)]
        public string FaturaTarihi { get; set; }

        [Column(TypeName = "money")]
        public decimal? AraToplam { get; set; }

        [Column(TypeName = "money")]
        public decimal? KDVToplam { get; set; }

        [Column(TypeName = "money")]
        public decimal? GenelToplam { get; set; }

        public virtual MusteriProfil MusteriProfil { get; set; }

        public virtual SaticiProfil SaticiProfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StokHareketleri> StokHareketleri { get; set; }
    }
}
