using Crud_final.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Crud_final.Controllers
{
    public class DefaultController : Controller
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-05I2OQQ7;initial catalog=db3; integrated security=true");
        public ActionResult Index()
        {
            return View();
        }

        public void InsertData(Class1 obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@roll_no", obj.Roll_No);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.Parameters.AddWithValue("@checkbox", obj.Checkbox);
            cmd.Parameters.AddWithValue("@reg_no", obj.Reg_No);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult Show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("get_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void DeleteData(Class1 obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult EditData(Class1 obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("edit_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void UpdateData(Class1 obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@roll_no", obj.Roll_No);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.Parameters.AddWithValue("@checkbox", obj.Checkbox);
            cmd.Parameters.AddWithValue("@reg_no", obj.Reg_No);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult ShowCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("show_country", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowState(int cid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("show_state", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}