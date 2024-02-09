using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Areas.Admin.Services;
using Store.Areas.Admin.Services.Base;
using Store.Areas.Admin.Services.InterfaceService;
using Store.Data;
using Store.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IBaseInterface<Category>,CategoryService>();
builder.Services.AddScoped<ISubCategoryInterface, SubCategoryService>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
  );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
