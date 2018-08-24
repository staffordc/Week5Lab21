using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Week5Lab21CoffeeShop.Data
{
    public class Week5Lab21CoffeeShopInitializer : DropCreateDatabaseAlways<Week5Lab21CoffeeShopContext>
    {
        protected override void Seed(Week5Lab21CoffeeShopContext context)
        {
            base.Seed(context);
        }
    }
}
