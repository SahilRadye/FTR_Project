using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [Column("CountryId", TypeName = "varchar")]
        [MaxLength(10)]
        public string CountryId { get; set; }


        [Column("CountryName", TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string CountryName { get; set; }
    }
}