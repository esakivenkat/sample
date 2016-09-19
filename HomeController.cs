using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using checkbox_sample.Models;

namespace checkbox_sample.Controllers
{
    public class HomeController : Controller
    {
        string connection = "Data Source=WEB-SERVER\\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;password=fresher";
        SqlConnection con = null;
        SqlCommand cmd = null;
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }

        public ActionResult ggg()
        {
            jQueryDataTableParamModel dm=new jQueryDataTableParamModel();
           // List<Class1> obj = new List<Class1>();
          //  Class1 g = new Class1();            
            var sa = main();
            var result = from d in sa select new[]
            {
                d.id.ToString(),
                d.name,d.age.ToString(),
                d.place,"" 
            };
                       return Json(new 
                       {
                           sEcho = dm.sEcho, 
                           iTotalLength = result, 
                           iTotalDisplayRecords = result, 
                           aaData = result },
                         JsonRequestBehavior.AllowGet);

        }

        public List<Class1> main()
        {
            List<Class1> b = new List<Class1>();
            Class1 e=new Class1();
            using (con = new SqlConnection(connection))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_nnn", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;                   
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Class1 a = new Class1();
                        a.id=Convert.ToInt16(dr["id"]);
                        a.name = Convert.ToString(dr["name"]);
                        a.age = Convert.ToInt16(dr["age"]);
                        a.place = Convert.ToString(dr["place"]);
                        b.Add(a);
                    } dr.Close();

                } return b;
            }
        }

        public string save(string name, Int16 age, string place, int tick)
        {
            Class1 ab=new Class1();
            ab.name=name;
            ab.age=age;
            ab.place=place;
            ab.tick = tick;
            using (con = new SqlConnection(connection))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_hhh", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("id", ab.id));
                    cmd.Parameters.Add(new SqlParameter("name",ab.name));
                    cmd.Parameters.Add(new SqlParameter("age", ab.age));
                    cmd.Parameters.Add(new SqlParameter("place", ab.place));
                    cmd.Parameters.Add(new SqlParameter("tick", ab.tick));
                    cmd.ExecuteNonQuery();
                }
            }
            return "";
        }

        public string update(Int16 id, string name, Int16 age, string place)
        {
            Class1 ab = new Class1();
            ab.id = id;
            ab.name = name;
            ab.age = age;
            ab.place = place;
            using (con = new SqlConnection(connection))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_hhh2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("id", ab.id));
                    cmd.Parameters.Add(new SqlParameter("name", ab.name));
                    cmd.Parameters.Add(new SqlParameter("age", ab.age));
                    cmd.Parameters.Add(new SqlParameter("place", ab.place));
                    cmd.ExecuteNonQuery();
                }
            }
            return "";
        }
    }
}
