using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class EmployeeModel
    {
        public int? EmpID { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "FirstName is Required.")]
        public string EmpFirstName { get; set; }
        [Display(Name = "LastName")]
        public string EmpLastName { get; set; }
        [Display(Name = "Salary")]
        public int EmpSalary { get; set; }
    }
}