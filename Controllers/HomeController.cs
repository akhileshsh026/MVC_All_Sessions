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

        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            if(ModelState.IsValid)
            {
                EmployeeRepositry employeeRepositry = new EmployeeRepositry();
                var isCreated = employeeRepositry.Create_Employee(emp);
                if (isCreated)
                {
                    TempData["sucess"] = "The Employee is Created sucessfully.";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        public ActionResult UpdateEmployee(int id)
        {
            EmployeeRepositry repo = new EmployeeRepositry();
            Employee emp = repo.GetById(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee emp)
        {
            if(ModelState.IsValid)
            {
                EmployeeRepositry repo = new EmployeeRepositry();
                bool isUpdated = repo.Update_Employee(emp);
                if (isUpdated)
                {
                    TempData["sucess"] = "The Employee is Created sucessfully.";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }









    }
}