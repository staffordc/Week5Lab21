using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Week5Lab21CoffeeShop.Domain.Models;

namespace Week5Lab21CoffeeShop.Data
{
    public class Week5Lab21CoffeeShopInitializer : DropCreateDatabaseIfModelChanges<Week5Lab21CoffeeShopContext>
    {
        protected override void Seed(Week5Lab21CoffeeShopContext context)
        {
            context.Users.Add(new User()
            {
                FirstName = "King",
                LastName = "Calamari",
                Email = "octo@sucker.net",
                Password = "SquidKilla",
                ConfirmPassword = "SquidKilla",
                PhoneNumber = "888-888-8888",
                FavoriteCoffee = "Grimblo's Brew"
            });
            context.Users.Add(new User()
            {
                FirstName = "Squid",
                LastName = "Kid",
                Email = "squid@sucker.net",
                Password = "SquidKid",
                ConfirmPassword = "SquidKid",
                PhoneNumber = "121-212-1212",
                FavoriteCoffee = "Simblo's Snap Up"
            });
            context.Items.Add(new Item()
            {
                ItemName = "Grimblos Brew",
                LocationFrom = "Grunderground",
                GrindType = "Coarse",
                Shade = "Dark",
                PricePerPound = 1.5
            });
            context.Items.Add(new Item()
            {
                ItemName = "Simblos Snap Up",
                LocationFrom = "Snap Canyon",
                GrindType = "FineGrind",
                Shade = "Light",
                PricePerPound = 5.5
            });
            context.Items.Add(new Item()
            {
                ItemName = "Umple Dumples",
                LocationFrom = "Wimplington",
                GrindType = "Fine as Sand",
                Shade = "Light as Can Be",
                PricePerPound = 3.75
            });
            context.Items.Add(new Item()
            {
                ItemName = "WAKE UP!!!",
                LocationFrom = "Swamp Fi",
                GrindType = "Coarsely",
                Shade = "Darkly",
                PricePerPound = 5.55
            });
            base.Seed(context);
            context.SaveChanges();
        }
    }
}
