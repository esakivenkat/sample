using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthCareServices.Models;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HealthCareServices.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        string connectin=Convert.ToString(WebConfigurationManager.AppSettings["connectionString"]);

        public ActionResult Index()
        {
           
            return View(main().ToList());
        }

        public ActionResult Edit(Int64 ID)
        {
            //List<Class1> mm = new List<Class1>();
            Class1 ll = null;
            SqlConnection con = new SqlConnection(connectin);
            con.Open();
            SqlCommand com = new SqlCommand("sp_bind122", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("ID",ID));
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
               ll = new Class1();
                ll.ID = ID;
                ll.NAME = Convert.ToString(read["NAME"]);
                ll.DOB = Convert.ToDateTime(read["DOB"]);
                ll.MobileNo = Convert.ToInt64(read["MobileNo"]);
                ll.Address = Convert.ToString(read["Address"]);
                ll.salary = Convert.ToInt64(read["salary"]);
                ll.Department = Convert.ToString(read["DepartmentName"]);
                //mm.Add(ll);
            }
            con.Close();

            return View(ll);
           
        }


        public List<Class1> main()
        {
            List<Class1> mm = new List<Class1>();
            SqlConnection con=new SqlConnection(connectin);
            con.Open();
            SqlCommand com = new SqlCommand("sp_listmainn", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Class1 ll = new Class1();
                ll.NAME = Convert.ToString(read["NAME"]);
                ll.DOB = Convert.ToDateTime(read["DOB"]);
                ll.MobileNo = Convert.ToInt64(read["MobileNo"]);
                ll.Address = Convert.ToString(read["Address"]);
                ll.salary = Convert.ToInt64(read["salary"]);
                ll.Department = Convert.ToString(read["DepartmentName"]);
                mm.Add(ll);
            }
            con.Close();

            return mm;
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View(new Class1());
        }

        public ActionResult Create(Class1 cls)
        {
            if (cls.ID > 0)
            {
                Update(cls);
                return RedirectToAction("Index");

            }
            else
            {
                Create1(cls);

                return RedirectToAction("Index");
            }
            return View();
        }

        public bool Create1(Class1 cls)
        {
            List<Class1> mm = new List<Class1>();
            SqlConnection con = new SqlConnection(connectin);
            con.Open();
            SqlCommand com = new SqlCommand("sp_create11", con);
            com.CommandType = CommandType.StoredProcedure;
           // com.Parameters.Add(new SqlParameter("ID", DBNull.Value));
            com.Parameters.Add(new SqlParameter("NAME", cls.NAME));
            com.Parameters.Add(new SqlParameter("DOB", cls.DOB));
            com.Parameters.Add(new SqlParameter("MobileNo", cls.MobileNo));
            com.Parameters.Add(new SqlParameter("Address", cls.Address));
            com.Parameters.Add(new SqlParameter("salary", cls.salary));
            com.Parameters.Add(new SqlParameter("DepartmentName", cls.Department));
            com.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public bool Update(Class1 cls)
        {
            SqlConnection con = new SqlConnection(connectin);
            con.Open();
            SqlCommand com = new SqlCommand("sp_update1112", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("ID", cls.ID));
            com.Parameters.Add(new SqlParameter("NAME", cls.NAME));
            com.Parameters.Add(new SqlParameter("DOB", cls.DOB));
            com.Parameters.Add(new SqlParameter("MobileNo", cls.MobileNo));
            com.Parameters.Add(new SqlParameter("Address", cls.Address));
            com.Parameters.Add(new SqlParameter("salary", cls.salary));
            com.Parameters.Add(new SqlParameter("DepartmentName", cls.Department));
            com.ExecuteNonQuery();
            con.Close();
            return true;
        }



    }
}
