using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeListMVCApp.Models
{
    public class DropDownView
    {
        public int Ename { get; set; }
        
        public int DNo { get; set; }

        [Display(Name = "Departments")]
        public string Dname { get; set; }

        public string Job { get; set; }
    }
}