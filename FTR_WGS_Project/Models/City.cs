using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityId { get; set; }


        [Column("CityName", TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string CityName { get; set; }


        [ForeignKey("Country")]
        public string CountryId { get; set; }

        public Country Country { get; set; }
    }
}