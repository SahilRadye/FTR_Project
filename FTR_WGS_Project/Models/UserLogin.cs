using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTR_WGS_Project.Models
{
    [Table("UserLogin")]
    public class UserLogin
    {
        [Key]
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }


        [Column("Password", TypeName = "varchar")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }


        [ForeignKey("Employee")]
        public string EmpId { get; set; }
        public Employee Employee { get; set; }
    }
}