using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Db.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}