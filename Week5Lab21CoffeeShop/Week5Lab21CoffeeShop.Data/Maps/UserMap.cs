using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Week5Lab21CoffeeShop.Domain.Models;

namespace Week5Lab21CoffeeShop.Data.Maps
{
    class UserMap: EntityTypeConfiguration<User>
    {
        internal UserMap()
        {
            HasKey(x => x.UserId);
            Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.Items)
                .WithMany(i => i.Users)
                .Map(ui =>
                    {
                        ui.MapLeftKey("UserId");
                        ui.MapRightKey("ItemId");
                        ui.ToTable("CartItem");

                    });
        }
    }
}
