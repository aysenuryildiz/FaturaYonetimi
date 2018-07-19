namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SirketProfil")]
    public partial class SirketProfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SirketProfil()
        {
            SaticiProfil = new HashSet<SaticiProfil>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        public int Telefon { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres { get; set; }

        [StringLength(50)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "money")]
        public decimal? Alacak { get; set; }

        [Column(TypeName = "money")]
        public decimal? Borc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaticiProfil> SaticiProfil { get; set; }
    }
}
