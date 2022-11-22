using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("AssignmentContact")]
    public class AssignmentContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactFormNo { get; set; }

        [Required(ErrorMessage = "Budget Holder Name is Required")]
        public string BudgetHolder_Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter in correct email address format")]
        public string BudgetHolder_Email { get; set; }

        [Required(ErrorMessage = "Home HrDirector Name is Required")]
        public string Home_HrDirector_Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter in correct email address format")]
        public string Home_HrDirector_Email { get; set; }

        [Required(ErrorMessage = "Home LineManager Name is Required")]
        public string Home_LineManager_Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter in correct email address format")]
        public string Home_LineManager_Email { get; set; }

        [Required(ErrorMessage = "Host HrDirector Name is Required")]
        public string Host_HrDirector_Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter in correct email address format")]
        public string Host_HrDirector_Email { get; set; }

        [Required(ErrorMessage = "Host LineManager Name is Required")]
        public string Host_LineManager_Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter in correct email address format")]
        public string Host_LineManager_Email { get; set; }

        [ForeignKey("TravelDetail")]
        public int RequestNo { get; set; }
        public TravelDetail TravelDetail { get; set; }
    }
}