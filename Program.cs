using Microsoft.EntityFrameworkCore;
using OlympicGames.Models;

var builder = WebApplication.CreateBuilder(args);

//MUST bet called vefore AddControllersWithViews
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

//get Connection string from "TeamContext"
builder.Services.AddDbContext<CountryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CountryContext")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});


var app = builder.Build();



// Add services to the container.
builder.Services.AddControllersWithViews();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// MUST BE CALLED before UseEndPoints
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "custom",
    pattern: "{controller}/{action}/cat/{activeCat}/game/{activeGame}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
