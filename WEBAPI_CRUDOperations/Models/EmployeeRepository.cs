using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WEBAPI_CRUDOperations.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public string Connection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            }
        }
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection myConnection = new SqlConnection(Connection))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(myCommand))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            string query = "select ID,Name, Gender, Designation, Department, EmailID, PhoneNo, Address from Employee";
            DataTable dt = GetData(query);
            if (dt.Rows.Count > 0)
            {
                Employee employee;

                int n = 0;
                while (n < dt.Rows.Count)
                {
                    employee = new Employee();
                    employee.ID = Convert.ToInt16(dt.Rows[n]["ID"].ToString());
                    employee.Name = dt.Rows[n]["Name"].ToString();
                    employee.Gender = dt.Rows[n]["Gender"].ToString();
                    employee.Designation = dt.Rows[n]["Designation"].ToString();
                    employee.Department = dt.Rows[n]["Department"].ToString();
                    employee.EmailID = dt.Rows[n]["EmailID"].ToString();
                    employee.PhoneNo = dt.Rows[n]["PhoneNo"].ToString();
                    employee.Address = dt.Rows[n]["Address"].ToString();
                    employees.Add(employee);
                    n++;
                }
            }
            return employees.ToArray();
        }
        public Employee Get(int ID)
        {
            Employee employees = new Employee();
            string query = "select ID,Name, Gender, Designation, Department, EmailID, PhoneNo, Address from Employee where ID ='" + ID + "'";
            DataTable dt = GetData(query);
            if (dt.Rows.Count > 0)
            {
                employees.ID = Convert.ToInt16(dt.Rows[0]["ID"].ToString());
                employees.Name = dt.Rows[0]["Name"].ToString();
                employees.Gender = dt.Rows[0]["Gender"].ToString();
                employees.Designation = dt.Rows[0]["Designation"].ToString();
                employees.Department = dt.Rows[0]["Department"].ToString();
                employees.EmailID = dt.Rows[0]["EmailID"].ToString();
                employees.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                employees.Address = dt.Rows[0]["Address"].ToString();
            }
            return employees;
        }
        public Employee Insert(Employee item)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(Connection);
            cmd.CommandText = "insert into Employee(Name, Gender, Designation, Department, EmailID, PhoneNo, Address) values(@Name,@Gender,@Designation,@Department,@EmailID,@PhoneNo,@Address)";
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@Gender", item.Gender);
            cmd.Parameters.AddWithValue("@Designation", item.Designation);
            cmd.Parameters.AddWithValue("@Department", item.Department);
            cmd.Parameters.AddWithValue("@EmailID", item.EmailID);
            cmd.Parameters.AddWithValue("@PhoneNo", item.PhoneNo);
            cmd.Parameters.AddWithValue("@Address", item.Address);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return item;
        }
        public bool Delete(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(Connection);
            cmd.CommandText = "delete from Employee where ID = '"+ID+"'";            
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(Employee item)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(Connection);
            cmd.CommandText = "update Employee set Name =@Name, Gender =@Gender, Designation = @Designation, Department = @Department, EmailID = @EmailID,PhoneNo = @PhoneNo, Address = @Address where ID = @ID";
            cmd.Parameters.AddWithValue("@ID", item.ID);
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@Gender", item.Gender);
            cmd.Parameters.AddWithValue("@Designation", item.Designation);
            cmd.Parameters.AddWithValue("@Department", item.Department);
            cmd.Parameters.AddWithValue("@EmailID", item.EmailID);
            cmd.Parameters.AddWithValue("@PhoneNo", item.PhoneNo);
            cmd.Parameters.AddWithValue("@Address", item.Address);
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}