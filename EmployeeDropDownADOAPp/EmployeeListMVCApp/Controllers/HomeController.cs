using EmployeeListMVCApp.Models;
using Employees.Model;
using Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeListMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeServices _services;
        public HomeController(IEmployeeServices service)
        {
            _services = service;
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Departments = GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Index(DropDownView vm)
        {
            ViewBag.Id = vm.DNo;
            List<Employee> employees = _services.GetEmployee(vm.DNo);           
            ViewBag.Employe = employees.ToList();
            ViewBag.Departments = GetDepartments();
            return View(vm);
        }

        public SelectList GetDepartments()
        {
            List<Department> department = _services.GetDepartment();
            return new SelectList(department, "deptNO", "dName");
        }
    }
}