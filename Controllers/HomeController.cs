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
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginInfo loginInfo)
        {
            if(ModelState.IsValid)
            {

                SqlConnection con = new SqlConnection(@"Server=localhost;Database=Mcop;User Id=sa;Password=Akhilesh@123;");
                var Query = "select count(*) from LoginInfo where UserName=@uName and Password=@passwd";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.Add(new SqlParameter("@uName", loginInfo.UserName));
                cmd.Parameters.Add(new SqlParameter("@passwd", loginInfo.Password));
                con.Open();
                int noOfUsers = (int)cmd.ExecuteScalar();
                con.Close();
                if (noOfUsers > 0)
                {
                    return RedirectToAction("Home");
                } 
                else
                {
                    ModelState.AddModelError("IC", "You Entered the Wrong Credianials..");
                }
            } 
            
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}