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
        public ActionResult Index(string UserName , string Password)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=Mcop;User Id=sa;Password=Akhilesh@123;");
            var Query = "select count(*) from LoginInfo where UserName=@uName and Password=@passwd" ;
            SqlCommand cmd = new SqlCommand(Query,con);
            cmd.Parameters.Add(new SqlParameter("@uName",UserName));
            cmd.Parameters.Add(new SqlParameter("@passwd",Password));
            con.Open();
            int noOfUsers = (int) cmd.ExecuteScalar();
            con.Close();
            if(noOfUsers >0)
            {
                return RedirectToAction("Home");
            }
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}