using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Xml.Linq;
using Newtonsoft.Json;
using CRUD_Cascading_Dropdown_JQuery_MVC.Models;
using System.Text;

namespace CRUD_Cascading_Dropdown_JQuery_MVC.Controllers
{
    public class UserController : Controller
    {
        string conString = @"Data Source=DESKTOP-IOJE25P\SQLEXPRESS;Initial Catalog=dbEcommerce;Integrated Security=true";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserForm()
        {
            return View();
        }

        public ActionResult UserFormToEdit(string email)
        {
            //string data;
            UserModel userModel = new UserModel();
            string sqlQuery = "SELECT * FROM dbo.tblCustomer WHERE [Email] = @email";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@email", email);
                //cmd.Parameters.Add("@email", SqlDbType.Int).Value = email;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userModel.CustomerID = reader.GetInt32(0);
                        userModel.Name = reader.GetString(1);
                        userModel.Email = reader.GetString(2);
                        userModel.Country = reader.GetInt32(3);
                        userModel.State = reader.GetInt32(4);
                        userModel.City = reader.GetInt32(5);
                    }
                }               
            }
            return View("UserForm", userModel);
        }

        public ActionResult ListOfCustomer() 
        { 
            return View();
        }

        public JsonResult FetchListOfCustomers()
        {
            string sqlQuery = "SELECT * FROM tblCustomer JOIN tblCountry ON Country = CountryID JOIN tblState ON [State] = StateID JOIN tblCity ON City = CityID";
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                _ = adapter.Fill(dataTable);
            }
            string data = JsonConvert.SerializeObject(dataTable);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public void UserInsert(UserModel userModel)
        {
            string sqlQuery = "INSERT INTO tblCustomer VALUES (@name,@email,@country,@state,@city)";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 60).Value = userModel.Name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 60).Value = userModel.Email;
                cmd.Parameters.Add("@country", SqlDbType.Int).Value = userModel.Country;
                cmd.Parameters.Add("@state", SqlDbType.Int).Value = userModel.State;
                cmd.Parameters.Add("@city", SqlDbType.Int).Value = userModel.City;
                connection.Open();
                _ = cmd.ExecuteNonQuery();
            }
        }

        public JsonResult GetCountry()
        {
            string data;
            string sqlQuery = "SELECT * FROM dbo.tblCountry";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                data = JsonConvert.SerializeObject(dt);
            }
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetState(int CountryID)
        {
            
            string data;
            string sqlQuery = "SELECT * FROM dbo.tblState WHERE CountryID = @countryId";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.Add("@countryId", SqlDbType.Int).Value = CountryID;
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                data = JsonConvert.SerializeObject(dt);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCity(int StateID)
        {
            string data;
            string sqlQuery = "SELECT * FROM dbo.tblCity WHERE StateID = @stateId";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.Add("@stateId", SqlDbType.Int).Value = StateID;
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                data = JsonConvert.SerializeObject(dt);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult FetchOne(string CEmail)
        //{
        //    string data;
        //    //StringBuilder data = new StringBuilder();
        //    //data = cid;
        //    //string sqlQuery = "SELECT * FROM dbo.tblCity WHERE [Customer ID] = @cid";
        //    //using (SqlConnection connection = new SqlConnection(conString))
        //    //{
        //    //    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
        //    //    cmd.Parameters.Add("@cid", SqlDbType.Int).Value = cid;
        //    //    connection.Open();
        //    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    //    DataTable dt = new DataTable();
        //    //    adapter.Fill(dt);
        //        data = JsonConvert.SerializeObject(CEmail);
        //    //}
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

    }
}