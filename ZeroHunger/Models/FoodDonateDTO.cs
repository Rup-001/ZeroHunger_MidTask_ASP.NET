using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class FoodDonateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public DateTime Expiredate { get; set; }
        public string Status { get; set; }

        [ForeignKey("ResturantDTO")]
        public int Res_Id { get; set; }
        public virtual ResturantDTO ResturantDTO { get; set; }
    }
}