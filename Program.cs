
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();

var app = builder.Build();


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
    name: "protocolos",
    pattern: "Protocolos/{action=Index}/{id?}",
    defaults: new { controller = "Protocolos" });


app.MapControllerRoute(
    name: "clientes",
    pattern: "Clientes/{action=Index}/{id?}",
    defaults: new { controller = "Clientes" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapControllerRoute(
    name: "protocolosSearch",
    pattern: "ProtocolosSearch/{action=Index}/{id?}",
    defaults: new { controller = "ProtocolosSearch" });

    


app.Run();
