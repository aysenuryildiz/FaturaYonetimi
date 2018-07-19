namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KeyValueModel")]
    public partial class KeyValueModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
