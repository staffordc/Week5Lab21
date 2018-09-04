using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Lab21CoffeeShop.Domain.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
    }
}
