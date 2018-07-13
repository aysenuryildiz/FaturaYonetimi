namespace DataEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [Key]
        [Required(ErrorMessage ="EMA�L G�R�N�Z")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage ="��FRE G�R�LMES� ZORUNLUDUR")]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }
    }
}
