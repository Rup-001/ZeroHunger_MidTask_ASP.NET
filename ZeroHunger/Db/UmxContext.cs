using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZeroHunger.Db.Models;

namespace ZeroHunger.Db
{
    public class UmxContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Resturant> Resturants { get; set; }

        public DbSet<FoodDonate> FoodDonates { get; set; }

    }
        
}