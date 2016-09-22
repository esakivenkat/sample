using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareServices.Models
{
     <add key="connectionString" value="Data Source=WEB-SERVER\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;Pwd=fresher"/>
    public class Class1
    {

        private Int64 _ID;

        private string _NAME;
        private DateTime _DOB;

        private Int64 _MobileNo;
        private string _Address;

        private Int64 _salary;
        private string _Department;


        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        public Int64 MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public Int64 salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
    }
}