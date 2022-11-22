using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("TravelDetail")]
    public class TravelDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestNo { get; set; }

        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Employee Name is Required")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Host Country is Required")]
        public string HostCountry { get; set; }


        [Required(ErrorMessage = "Host City is Required")]
        public string HostCity { get; set; }


        [Required(ErrorMessage = "Travel Start Date is Required")]
        public DateTime DateFrom { get; set; }


        [Required(ErrorMessage = "Travel End Date is Required")]
        public DateTime DateTo { get; set; }


        [Required(ErrorMessage = "Status is Required")]
        public string Status { get; set; }


        [ForeignKey("GCM")]
        public int GCMId { get; set; }
        public GCM GCM { get; set; }


        [ForeignKey("Travel")]
        public int TravelId { get; set; }
        public Travel Travel { get; set; }


        [ForeignKey("Employee")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Manager is Required")]
        public string SendTo { get; set; }
        public Employee Employee { get; set; }
    }
}