using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Auth;
using ZeroHunger.Db;
using ZeroHunger.Db.Models;
using ZeroHunger.Models;


namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        //[Logged]

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //[Logged]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeDTO emp)
        {
            if(ModelState.IsValid)
            {
                var db = new UmxContext();
                db.Employees.Add(Convert(emp));
                db.SaveChanges();

                TempData["msg"] = "employee added";
                return View();
            }
            else
            {
                TempData["msg"] = "error";
                return View();
            }
            
        }

        //[Logged]
        public ActionResult ShowEmployee()
        {
            var db = new UmxContext();
            var emp = db.Employees.ToList();
            return View(emp);
        }
        [HttpGet]
        public ActionResult Pending()
        {
            var db = new UmxContext();
            var pending = (from u in db.FoodDonates
                           where u.Status.Equals("pending")
                           select u).ToList();
            var emps = db.Employees.ToList();
            ViewBag.emps = emps;
            //var pendingList = new List<FoodDonate>(pending);
            return View(pending);
        }
        [HttpPost]
        public ActionResult Pending(FormCollection fc) {
            var reqId = fc["C_Id"];
            var EmpId = fc["EmpId"];
            return null;
        }
        [HttpGet]
        public ActionResult Assign()
        {
            var db = new UmxContext();
            var pending = (from u in db.FoodDonates
                           where u.Status.Equals("pending")
                           select u);
            var pendingList = new List<FoodDonate>(pending);
            return View(pendingList);
        }
        [HttpPost]
       /* public ActionResult Assign()
        {
            return View();
        }*/

        public ActionResult Logout()
        {
            Session["Id"] = null;
            Session["Name"] = null;
            Session["Email"] = null;

            return RedirectToAction("Index", "Home");
        }

        Employee Convert(EmployeeDTO emp)
        {
            var e = new Employee()
            {
                Name = emp.Name,
                Email = emp.Email,
                Password = emp.Password
            };
            return e;
        }
    }
    

}