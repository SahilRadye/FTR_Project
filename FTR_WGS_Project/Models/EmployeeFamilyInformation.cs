using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("EmployeeFamilyInformation")]
    public class EmployeeFamilyInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FormNo { get; set; }

        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "DOB is Required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Primary Citizenship is Required")]
        public string Primary_Citizenship { get; set; }

        [Required(ErrorMessage = "Secondary Citizenship is Required")]
        public string Secondary_Citizenship { get; set; }

        [Required(ErrorMessage = "DASId is Required")]
        public string DASId { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "GCM Level is Required")]
        public string GCMHomeCountry { get; set; }

        [Required(ErrorMessage = "GCM Level is Required")]
        public string GCMHostCountry { get; set; }

        [Required(ErrorMessage = "Family Status HomeCountry is Required")]
        public string FamilyStatus_HomeCountry { get; set; }

        [Required(ErrorMessage = "Family Status HostCountry is Required")]
        public string FamilyStatus_HostCountry { get; set; }

        [Required(ErrorMessage = "Partner Location is Required")]
        public string Partner_Location { get; set; }

        [Required(ErrorMessage = "Child Name is Required")]
        public string ChildName { get; set; }

        [Required(ErrorMessage = "Child DOB is Required")]
        public string ChildDOB { get; set; }

        [Required(ErrorMessage = "Child Citizenship is Required")]
        public string ChildPrimaryCitizenship { get; set; }

        [Required(ErrorMessage = "Tax Field is Required")]
        public string Dependent_On_Tax { get; set; }


        [ForeignKey("TravelDetail")]
        public int RequestNo { get; set; }
        public TravelDetail TravelDetail { get; set; }
    }
}