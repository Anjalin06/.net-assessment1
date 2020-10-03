using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamWebApp.Models;

namespace ExamWebApp.Controllers
{
    public class MVCController : Controller
    {
        public ViewResult Display()
        {
            var context = new MyDatabaseEntities();
            var model = context.EmpTables.ToList();
            return View(model);
        }
        public ActionResult Find(string id)
        {
            int EmpId = int.Parse(id);
            var context = new MyDatabaseEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == EmpId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Find(EmpTables emp)
        {
            var context = new MyDatabaseEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == emp.EmpId);
            model.EmpName = emp.EmpName;
            model.EmpAddress = emp.EmpAddress;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();
            return RedirectToAction("Display");
        }
        public ViewResult AddEmployee()
        {
            var model = new EmpTables();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployee(EmpTables emp)
        {
            var context = new MyDatabaseEntities();
            context.EmpTables.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Display");
        }
        public ActionResult DeleteEmployee(string id)
        {
            int EmpId = int.Parse(id);
            var context = new MyDatabaseEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == EmpId);
            context.EmpTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}