namespace WebCRUDDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student")]
    public partial class student
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }
}
