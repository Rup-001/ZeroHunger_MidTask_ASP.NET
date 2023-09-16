using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Db;
using ZeroHunger.Db.Models;
using ZeroHunger.Models;
using System.Collections.Generic;

namespace ZeroHunger.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        [HttpGet]
        public ActionResult Index()
        {
            return View();
            /*var db = new UmxContext();
            var food = db.FoodDonates.ToList();
            return View(food);*/
            /*int id = (int)Session["id"];
            var db = new UmxContext();

            var history = (from u in db.FoodDonates
                           where u.ResId.Equals(id)
                           select u);
           
            return View();*/
        }
        [HttpPost]
        public ActionResult Index(FoodDonateDTO obj)
        {
            var db = new UmxContext();

            var foodDonate = new FoodDonate()
            {
                Name = obj.Name,
                Quantity = obj.Quantity,
                ExpireDate = obj.Expiredate,
                Status = "pending",
                ResId = (int)Session["Id"]
            };
            db.FoodDonates.Add(foodDonate);
            db.SaveChanges();
            return View();

        }
        public ActionResult History()
        {
            int id = (int)Session["Id"];
            var db = new UmxContext();
            var history = (from u in db.FoodDonates
                           where u.Id.Equals(id)
                           select u);
            var historyList = db.FoodDonates.ToList();
            return View(historyList);

            /* var historyList = new List<FoodDonate>(history);
            return View(Convert(historyList));*/
            /* var db = new UmxContext();
             var history = db.FoodDonates.ToList();
             return View(history);*/

            
            /* var db = new UmxContext();
             var history = db.FoodDonates.ToList();
             return View(history);*/

        }
       

        public ActionResult Logout()
        {
            Session["Id"] = null;
            Session["Name"] = null;
            Session["Email"] = null;

            return RedirectToAction("Index", "Home");
        }
        /*List<FoodDonateDTO> Convert(List<FoodDonate> foodDonates)
            {
                var nd = new List<FoodDonateDTO>();

                foreach (var foodDonate in foodDonates)
                {
                    var u = Convert(foodDonate);
                    nd.Add((FoodDonateDTO)u);
                }

                return nd;
            }*/
    }
}