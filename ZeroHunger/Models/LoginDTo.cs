using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class LoginDTo
    {
        [Required(ErrorMessage ="enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter pass")]
        public string Pass { get; set; }
    }
}
