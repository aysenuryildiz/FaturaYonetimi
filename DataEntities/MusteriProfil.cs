namespace DataEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MusteriProfil")]
    public partial class MusteriProfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MusteriProfil()
        {
            Fatura = new HashSet<Fatura>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyad { get; set; }
        [Required]
        public string Telefon { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal? Alacak { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal? Borc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
