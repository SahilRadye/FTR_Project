using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("Travel")]
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Travel Type is Required")]
        public int TravelId { get; set; }


        [Column("TravelType", TypeName = "varchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Travel Type is Required")]
        public string TravelType { get; set; }
    }
}