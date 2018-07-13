namespace DataEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaticiProfil")]
    public partial class SaticiProfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaticiProfil()
        {
            Fatura = new HashSet<Fatura>();
        }

        public int ID { get; set; }

        public int SirketID { get; set; }

        [StringLength(50)]
        public string Departman { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }

        public virtual SirketProfil SirketProfil { get; set; }
    }
}
