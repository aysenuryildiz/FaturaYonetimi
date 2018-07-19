namespace Entities
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
        [RegularExpression(@"^[a-zA-Z-çÇğİıÖöŞşÜü]+$", ErrorMessage = "Ad alanı sadece karakterlerden oluşmaktadır")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z-çÇğİıÖöŞşÜü]+$", ErrorMessage = "Soyad alanı sadece karakterlerden oluşmaktadır")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z-çÇğİıÖöŞş]+$", ErrorMessage = "Adres alanı sadece karakterlerden oluşmaktadır")]
        public string Adres { get; set; }

        [Column(TypeName = "money")]
        [Required]
        [Range(0.01, 100000000.00)]
        public decimal? Alacak { get; set; }
        [Required]
        [Range(0.01, 100000000.00)]
        [Column(TypeName = "money")]
        public decimal? Borc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
