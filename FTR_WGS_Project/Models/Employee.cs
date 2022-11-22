using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column("EmpId", TypeName = "varchar")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Employee Id is Required")]
        public string EmpId { get; set; }

        [Column("EName", TypeName = "varchar")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Employee Name is Required")]
        public string EName { get; set; }

        [Column("DASId", TypeName = "varchar")]
        [MaxLength(10)]
        public string DASId { get; set; }


        [ForeignKey("GCM")]
        public int GCMId { get; set; }
        public GCM GCM { get; set; }


        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }


        [ForeignKey("Country")]
        public string CountryId { get; set; }
        public Country Country { get; set; }

    }
}