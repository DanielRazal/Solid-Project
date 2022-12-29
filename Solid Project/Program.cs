using Data.Context;
using Data.Repositories.Interfaces;
using Data.Repositories.Repo;
using Microsoft.EntityFrameworkCore;
using Solid_Project.Service.Class;
using Solid_Project.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("StoreConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var ctx = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
//    ctx.Database.EnsureDeleted();
//    ctx.Database.EnsureCreated();
//}


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

app.Run();
