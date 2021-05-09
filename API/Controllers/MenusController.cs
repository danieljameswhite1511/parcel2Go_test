using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.Data.EntityExtensions;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MenusController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Menu> _menuRepsoitory;
    private readonly DataContext _dataContext;

    public MenusController(IGenericRepository<Menu> menuRepsoitory, IMapper mapper, DataContext dataContext)
    {
      _dataContext = dataContext;
      _menuRepsoitory = menuRepsoitory;
      _mapper = mapper;

    }

    [HttpGet()]
    public async Task<ActionResult<MenuDto>> GetMenu([FromQuery] string name)
    {

      //I have left this in to demonstrate that there is a generic and configurable way to achieve the same result

      //var menu = await _menuRepsoitory.ReturnQueryableWhereAndInclude(x=>x.Name==name , x=>x.MenuItems).FirstOrDefaultAsync();

      var menu = await _menuRepsoitory.SingleAsyncByQuerySpecification(new MenuAndMenuItems(name));


      var menuDto = _mapper.Map<Menu, MenuDto>(menu);   

      return Ok(menuDto);

    }
  }
}