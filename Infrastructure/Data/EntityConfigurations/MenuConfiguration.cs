using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {

    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
          builder.HasMany(x => x.MenuItems);

        }
    }
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
             //builder.HasOne(x => x.Menu).WithMany(x=>x.MenuItems).HasForeignKey(x => x.MenuId);
            builder.HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);
            builder.Property(x => x.LinkText).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SortOrder).IsRequired();

        }
    }

  
}