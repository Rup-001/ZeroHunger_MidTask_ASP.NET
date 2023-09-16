using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class ResturantDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "enter Password")]
        public string Password { get; set; }
    }
}