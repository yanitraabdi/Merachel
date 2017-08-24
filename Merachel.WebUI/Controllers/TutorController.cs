using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merachel.Domain.Abstract;
using Merachel.Domain.Concrete;
using Merachel.Domain.Entities;
using Merachel.WebUI.Models;

namespace Merachel.WebUI.Controllers
{
    public class TutorController : Controller
    {
        private IEmployeeRepository employeereposiory;

        public TutorController(
            IEmployeeRepository employeerepo)
        {
            employeereposiory = employeerepo;
        }

        public ActionResult Index()
        {
            IEnumerable<Employee> employee = employeereposiory.Employees.Where(p => p.EmployeeStatus == true).ToList();
            return View(employee);
        }

        public FileContentResult GetTutorImage(int employeeid)
        {
            Employee pic = employeereposiory.Employees.FirstOrDefault(p => p.EmployeeID == employeeid);
            if (pic != null)
            {
                return File(pic.EmployeeImageData, pic.EmployeeMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}