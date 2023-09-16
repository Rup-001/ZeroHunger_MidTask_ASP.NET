using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.Db.Models
{
    public class FoodDonate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public DateTime ExpireDate { get; set; }
        public String Status { get; set; }
        [ForeignKey("Resturant")]
        public int ResId { get; set; }
        public virtual Resturant Resturant { get; set; }
        [ForeignKey("Employee")]
        public int? EmpId { get; set; }
        public virtual Employee Employee { get; set; }


    }
}