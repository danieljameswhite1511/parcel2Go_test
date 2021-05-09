using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Middleware;
using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
  public class Startup
  {
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
      _config = config;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      //services.AddControllersWithViews();
      services.AddSwaggerGen();
      services.AddControllers();
      services.AddHttpContextAccessor();
      services.AddApplicationServices();
      
      services.AddDbContext<DataContext>(x => x.UseSqlite(_config.GetConnectionString("SQLiteConnection")));
      //services.AddDbContext<DataContext>(x => x.UseSqlServer(_config.GetConnectionString("SqlExpressConnection")));

       services.AddCors(opt => {

                opt.AddPolicy("CorsPolicy", policy =>{
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });

            });
      

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
         app.UseSwagger();
         app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseMiddleware<ExceptionMiddleware>();

      app.UseHttpsRedirection();

      app.UseStaticFiles();

      app.UseRouting();

      app.UseCors("CorsPolicy");

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });

      
    }
  }
}
