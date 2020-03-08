using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_All_Sessions.Models
{
    public class EmployeeRepositry
    {
        public List<Employee> GetAll()
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;DataBase=Mcop;User Id =sa;Password=Akhilesh@123");
            var Query = "Select * from Employee";
            SqlCommand cmd = new SqlCommand(Query,con);
            List<Employee> empList = new List<Employee>();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Employee emp = new Employee
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = (int)dr[3],
                    Deptid = (int)dr[4]
                };
                empList.Add(emp);
            }
            con.Close();
            return empList;
        }

        public bool Delete_Employee(int id)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;DataBase=Mcop;User Id =sa;Password=Akhilesh@123");
            var Query = "delete from Employee where Id=@id";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.Add(new SqlParameter("@Id",id));
            con.Open();
            int noOfAffactedRows = cmd.ExecuteNonQuery();
            con.Close();
            return noOfAffactedRows > 0 ? true : false;
        }


    }
}