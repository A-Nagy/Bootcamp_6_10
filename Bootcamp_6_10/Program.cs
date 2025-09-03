using Bootcamp_6_10.Data;
using Bootcamp_6_10.Repository;
using Bootcamp_6_10.Repository.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionstring = builder.Configuration.GetConnectionString("DefualtConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring));

//builder.Services.AddTransient(typeof(IRepository<>),typeof(MainRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
