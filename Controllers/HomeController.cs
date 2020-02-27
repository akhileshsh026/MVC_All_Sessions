using MVC_All_Sessions.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_All_Sessions.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
                EmployeeRepositry employeeRepositry = new EmployeeRepositry();
                var list = employeeRepositry.GetAll();
                return View(list);
        }


        public ActionResult DeleteEmployee()
        {

        }

        public ActionResult CreateEmployee()
        {

        }

        public ActionResult UpdateEmployee()
        {

        }




    }
}