using System.Linq;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EntityExtensions
{
    public static class MenuExtension
    {
         public static IQueryable<Menu> MenuAndNMenuItems(this IQueryable<Menu> query)
        {
            return query.Include(x=>x.MenuItems);
        }
    }
}