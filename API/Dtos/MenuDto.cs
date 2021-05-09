using System.Collections.Generic;

namespace API.Dtos
{
    public class MenuDto
    {
        public string Name { get; set; }
        public List<MenuItemDto> MenuItems { get; set; }
        
    }
}