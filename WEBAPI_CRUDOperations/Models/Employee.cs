
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_CRUDOperations.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }
}