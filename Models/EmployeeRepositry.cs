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

        public bool Create_Employee(Employee emp)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Server=localhost;Database=Mcop;User Id=sa;Password=Akhilesh@123");
            var Query = "insert into Employee (Name,Location,Salary,Deptid) values (@Name,@Location,@Salary,@Deptid)";
            SqlCommand cmd = new SqlCommand(Query,sqlConnection);
           // cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@Name",emp.Name));
            cmd.Parameters.Add(new SqlParameter("@Location",emp.Location));
            cmd.Parameters.Add(new SqlParameter("@Salary", emp.Salary));
            cmd.Parameters.Add(new SqlParameter("@Deptid", emp.Deptid));
            sqlConnection.Open();
            int noOfInfectedRows = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return noOfInfectedRows >0 ? true : false;

        }

    }
}