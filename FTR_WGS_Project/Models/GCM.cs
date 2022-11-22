using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("GCM")]
    public class GCM
    {
        [Key]
        [Required(ErrorMessage = "GCM Id Is Required")]
        public int GCMId { get; set; }


        [Column("GCMLevel", TypeName = "varchar")]
        [MaxLength(5)]
        [Required(ErrorMessage = "GCM Level Is Required")]
        public string GCMLevel { get; set; }
    }
}