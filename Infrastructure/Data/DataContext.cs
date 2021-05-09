using System.Linq;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
  public class DataContext : DbContext
  {
    private readonly IHttpContextAccessor _httpContentAccessor;

    public DataContext(){}

    public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContentAccessor) : base(options)
    {
      _httpContentAccessor = httpContentAccessor;
    }

    //Tenant
    public DbSet<Tenant> Tenants { get; set; }

    //Menu
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }


    //Services
    public DbSet<Service> Services { get; set; }
    public DbSet<Links> links { get; set; }


    public Tenant GetTenant()
    {
      var tenant = Tenants.FirstOrDefault(t => t.Host.ToLower() == _httpContentAccessor.HttpContext.Request.Host.Value.ToLower());
      return tenant;
    }



    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // //=> options.UseSqlServer("server=.\\SQLExpress;database=SQLExpress_db;trusted_connection=true;");
    // => options.UseSqlite("Data source=Sqlite_App.db");
  }

}