using Microsoft.EntityFrameworkCore;
using ContactList.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add EF Core DI
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext")));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
 {

 endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 endpoints.MapControllerRoute(
     name: "contactRoute",
     pattern: "Contact/Detail/{id}/{slug}",
     defaults: new { controller = "Contact", action = "Detail" });

     endpoints.MapControllerRoute(
         name: "editRoute",
         pattern: "Contact/Edit/{id}/{slug}",
         defaults: new { controller = "Contact", action = "Edit" });

     endpoints.MapControllerRoute(
         name: "deleteRoute",
         pattern: "Contact/Delete/{id}/{slug}",
         defaults: new { controller = "Contact", action = "Delete" });
 });
app.Run();
