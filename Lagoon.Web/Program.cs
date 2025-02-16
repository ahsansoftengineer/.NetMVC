using Lagoon.App.Common;
using Lagoon.Infra.Common;
using Lagoon.Infra.Repo;
using Microsoft.EntityFrameworkCore;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    ConfigureServices(builder);
    var app = builder.Build();
    Configure(app);

    app.Run();
  }

  private static void ConfigureServices(WebApplicationBuilder builder)
  {
    var Srvs = builder.Services;
    Srvs.AddControllersWithViews();
    _ = Srvs.AddDbContext<AppDBContext>(opt =>
    {
      string? conStr = builder.Configuration
            .GetConnectionString("DefaultConnection");
      opt.UseSqlServer(conStr);
    });
    // Srvs.AddScoped<IRepoVilla, RepoVilla>();
    // Srvs.AddScoped<IRepoVillaNumber, RepoVillaNumber>();
    Srvs.AddScoped<IUnitOfWork, UnitOfWork>();
  }

  private static void Configure(WebApplication app)
  {
    if (!app.Environment.IsDevelopment())
    {
      app.UseExceptionHandler("/Home/Error");
      app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
  }
}