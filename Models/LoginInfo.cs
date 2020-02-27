using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_All_Sessions.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage ="Please enter the User name ...")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Please Enter the password .....")]
        public string Password { get; set; }
    }
}