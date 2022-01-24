using Quadwave.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadwave.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("sp_addcustomer", connection);
            if (connection.State == ConnectionState.Closed) { connection.Open(); }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", 2);
            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tbl);
            List<customer> cust = new List<customer>();
            foreach(DataRow row in tbl.Rows)
            {
                cust.Add(new customer
                {
                    customer_id = Convert.ToInt32(row["customer_id"]),
                    customer_name = row["customer_name"].ToString(),
                    country=row["country"].ToString(),
                    customer_date=row["created_date"].ToString()
                }) ;
            }
            return View(cust);
        }

       public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(FormCollection form)
        {
            string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("sp_addcustomer", connection);
            if (connection.State == ConnectionState.Closed) { connection.Open(); }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", 1);
            command.Parameters.AddWithValue("@cusomer_name", form["name"].ToString());
            command.Parameters.AddWithValue("@countory", form["countory"].ToString());
            command.Parameters.AddWithValue("@fname", form["fname"].ToString());
            command.Parameters.AddWithValue("@lname", form["lname"].ToString());
            command.Parameters.AddWithValue("@city", form["city"].ToString());
            command.Parameters.AddWithValue("@add", form["address"].ToString());
            command.Parameters.AddWithValue("@number",form["number"].ToString());
            
            int n = command.ExecuteNonQuery();
            connection.Close();
            if (n > 0)
            {
                Response.Write("<script>alert('Customer Saved Successfully:)');</script>");
            }
            else
            {
                Response.Write("<script>alert('Customer not Saved :)');</script>");
            }

            return View(); 
        }
        public ActionResult EditPage()
        {
            int cid = Convert.ToInt32(Request.QueryString["cid"]);

            string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("sp_addcustomer", connection);
            if (connection.State == ConnectionState.Closed) { connection.Open(); }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", 4);
            command.Parameters.AddWithValue("@cid", cid);
            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tbl);
            List<customer> cus = new List<customer>();
            foreach (DataRow row in tbl.Rows)
            {
                cus.Add(new customer
                {
                    customer_id = Convert.ToInt32(row["customer_id"]),
                    customer_name = row["customer_name"].ToString(),
                    country = row["country"].ToString(),
                    customer_date = row["created_date"].ToString(),
                    fname=row["fist_name"].ToString(),
                     lname=row["Last_name"].ToString(),
                   number=row["Mobile"].ToString(),
                    address=row["Address"].ToString(),
                    city=row["city"].ToString()
                });
            }
            return View(cus);
        }
        [HttpPost]
        public ActionResult EditPage( FormCollection form)
        {
            int cid = Convert.ToInt32(Request.QueryString["cid"]);

            string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("sp_addcustomer", connection);
            if (connection.State == ConnectionState.Closed) { connection.Open(); }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", 5);
            command.Parameters.AddWithValue("@cid", cid);
            command.Parameters.AddWithValue("@fname", form["fname"].ToString());
            command.Parameters.AddWithValue("@lname", form["lname"].ToString());
            command.Parameters.AddWithValue("@city", form["city"].ToString());
            command.Parameters.AddWithValue("@add", form["address"].ToString());
            command.Parameters.AddWithValue("@number", form["number"].ToString());

            int n = command.ExecuteNonQuery();
            connection.Close();
            if (n > 0)
            {
                Response.Write("<script>alert('Customer Saved Successfully:)');</script>");
            }
            else
            {
                Response.Write("<script>alert('Customer not Saved :)');</script>");
            }
            return View();
        }
        public ActionResult deletePage()
        {
            int cid = Convert.ToInt32(Request.QueryString["cid"]);
            string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("sp_addcustomer", connection);
            if (connection.State == ConnectionState.Closed) { connection.Open(); }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", 3);
            command.Parameters.AddWithValue("@cid", cid);
            int n = command.ExecuteNonQuery();
            return RedirectToAction("index");
        }
        public ActionResult ViewPage()
        {
            int cid = Convert.ToInt32(Request.QueryString["cid"]);
            string constr = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("sp_addcustomer", connection);
            if (connection.State == ConnectionState.Closed) { connection.Open(); }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", 4);
            command.Parameters.AddWithValue("@cid", cid);
            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tbl);
            List<customer> cust = new List<customer>();
            foreach (DataRow row in tbl.Rows)
            {
                cust.Add(new customer
                {
                    customer_id = Convert.ToInt32(row["customer_id"]),
                    customer_name = row["customer_name"].ToString(),
                    country = row["country"].ToString(),
                    customer_date = row["created_date"].ToString(),
                    fname = row["fist_name"].ToString(),
                    lname = row["Last_name"].ToString(),
                    number = row["Mobile"].ToString(),
                    address = row["Address"].ToString(),
                    city = row["city"].ToString()
                });
            }
            return View(cust);
        }

    }
}