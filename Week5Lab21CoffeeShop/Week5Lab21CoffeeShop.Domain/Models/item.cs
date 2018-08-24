using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Lab21CoffeeShop.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string LocationFrom { get; set; }
        public string GrindType { get; set; }
        public string Shade { get; set; }
        public double PricePerPound { get; set; }
    }
}
