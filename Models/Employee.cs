using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_All_Sessions.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the Name of the Employee.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter the Location of the Employee.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Enter the Salary of the Employee.")]
        public int Salary {get; set; }
        [Required(ErrorMessage = "Enter the Department Id of the Employee.")]
        public int Deptid { get; set; }
    }
}