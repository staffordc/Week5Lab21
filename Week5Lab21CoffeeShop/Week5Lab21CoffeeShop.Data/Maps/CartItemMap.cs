using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Lab21CoffeeShop.Domain.Models;

namespace Week5Lab21CoffeeShop.Data.Maps
{
    class CartItemMap : EntityTypeConfiguration<CartItem>
    {
        internal CartItemMap()
        {
            HasKey(x => x.CartItemId);
            Property(x => x.CartItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
        }
    
    }
}
