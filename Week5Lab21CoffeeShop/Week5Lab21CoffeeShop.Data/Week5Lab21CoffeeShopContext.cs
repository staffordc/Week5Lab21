using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Lab21CoffeeShop.Data.Maps;
using Week5Lab21CoffeeShop.Domain.Models;
using System.Data.Entity;

namespace Week5Lab21CoffeeShop.Data
{
    public class Week5Lab21CoffeeShopContext : DbContext
    {
        public Week5Lab21CoffeeShopContext() : base("CoffeeShop")
        {
            Database.SetInitializer(new Week5Lab21CoffeeShopInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ItemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
