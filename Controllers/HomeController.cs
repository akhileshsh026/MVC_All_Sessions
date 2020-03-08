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


        public ActionResult DeleteEmployee(int id)
        {
            EmployeeRepositry employeeRepositry = new EmployeeRepositry();
            bool result = employeeRepositry.Delete_Employee(id);
            if(result)
            {
                TempData["Sucess"] = "The Employee Wih Id : " + id + " Deleted Sucessfully.";
                return RedirectToAction("Index");
            } else
            {
                return View();
            }

        }

        public ActionResult CreateEmployee(Employee emp)
        {
            return View();
        }






    }
}