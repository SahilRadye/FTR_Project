using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("AssignmentDetail")]
    public class AssignmentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DetailFormNo { get; set; }

        [Required(ErrorMessage = "Home Country is Required")]
        public string From_HomeCountry { get; set; }

        [Required(ErrorMessage = "Host Country is Required")]
        public string To_HostCountry { get; set; }

        [Required(ErrorMessage = "Home City is Required")]
        public string From_HomeCity { get; set; }

        [Required(ErrorMessage = "Host City is Required")]
        public string To_HostCity { get; set; }

        [Required(ErrorMessage = "GBU is Required")]
        public string From_GBU { get; set; }

        [Required(ErrorMessage = "GBU is Required")]
        public string To_GBU { get; set; }

        [Required(ErrorMessage = "Legal Entity is Required")]
        public string From_LegalEntity { get; set; }

        [Required(ErrorMessage = "Legal Entity is Required")]
        public string To_LegalEntity { get; set; }

        [Required(ErrorMessage = "Division is Required")]
        public string From_Division { get; set; }

        [Required(ErrorMessage = "Division is Required")]
        public string To_Division { get; set; }

        [Required(ErrorMessage = "Expected Start Date is Required")]
        public DateTime ExpectedStartDate { get; set; }

        [Required(ErrorMessage = "Expected End Date is Required")]
        public DateTime ExpectedEndDate { get; set; }

        [Required(ErrorMessage = "Reason is Required")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Replacing Employee Field is Required")]
        public string ReplacingEmployee { get; set; }

        [Required(ErrorMessage = "Reporting is Required")]
        public string ReportingTo { get; set; }

        [Required(ErrorMessage = "Review is Required")]
        public string Review { get; set; }

        [Required(ErrorMessage = "Full Time Work is Required")]
        public string FullTimeWork { get; set; }

        public string WorkingTime { get; set; }

        [Required(ErrorMessage = "Employment Relatioship is Required")]
        public string EmploymentRelatioship { get; set; }

        [Required(ErrorMessage = "Role in HostCountry is Required")]
        public string Role_HostCountry { get; set; }

        [Required(ErrorMessage = "Role Description is Required")]
        public string Role_Description { get; set; }

        [Required(ErrorMessage = "Annual Base Salary is Required")]
        public string AnnualBaseSalary { get; set; }

        [Required(ErrorMessage = "Bearing Cost PersonName is Required")]
        public string BearingCost_PersonName { get; set; }

        [Required(ErrorMessage = "Cost Center is Required")]
        public string Cost_Center { get; set; }

        [Required(ErrorMessage = "Client Name is Required")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Project Name is Required")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Activity is Required")]
        public string Activity { get; set; }

        [Required(ErrorMessage = "WFM Request Id is Required")]
        public string WFMRequestId { get; set; }


        [ForeignKey("TravelDetail")]
        public int RequestNo { get; set; }
        public TravelDetail TravelDetail { get; set; }
    }
}