using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Db;
using ZeroHunger.Db.Models;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(ResturantDTO signup)
        {
            var db = new UmxContext();
            if(ModelState.IsValid)
            {
                db.Resturants.Add(Convert(signup));
                db.SaveChanges();
                TempData["msg"] = "User Added!";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                TempData["msg"] = "Signup failed";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTo obj)
        {
            var db = new UmxContext();
            var user = (from u in db.Users
                        where u.Name.Equals(obj.Name) &&
                        u.Pass.Equals(obj.Pass)
                        select u).SingleOrDefault();

            var employee = (from u in db.Employees
                            where u.Name.Equals(obj.Name) &&
                            u.Password.Equals(obj.Pass)
                            select u).SingleOrDefault();

            var resturant = (from u in db.Resturants
                             where u.Name.Equals(obj.Name) &&
                             u.Password.Equals(obj.Pass)
                             select u).SingleOrDefault();

            if (user!= null)
            {
                Session["Id"] = user.Id;
                Session["Name"] = user.Name;
                return RedirectToAction("Index", "Admin");
            }

            else if(employee !=null)
            {
                Session["Id"] = employee.Id;
                Session["Name"] = employee.Name;
                return RedirectToAction("Index", "Employee");
            }

            else if(resturant != null)
            {
                Session["Id"] = resturant.Id;
                Session["Name"] = resturant.Name;
                return RedirectToAction("Index", "Resturant");
            }
            else
            {
                TempData["msg"] = "Login Failed!";
                return View(obj);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*LoginDTo Convert (User signup)
        {
            var sign = new LoginDTo()
            {
                Name = signup.Name,
                Pass = signup.Pass
            };
            return sign;
        }*/
        Resturant Convert(ResturantDTO signup)
        {
            var sign = new Resturant()
            {
                Name = signup.Name,
                Email = signup.Email,
                Address = signup.Address,
                Password = signup.Password
            };
            return sign;
        }
    }
}