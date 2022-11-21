using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediCare2._0.Data;
using Auth0.AspNetCore.Authentication;
using MediCare2._0.Migrations;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MediCare2_0ContextConnection") ?? throw new InvalidOperationException("Connection string 'MediCare2_0ContextConnection' not found.");

builder.Services.AddDbContext<MediCare2_0Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MediCare2._0.Areas.Identity.Data.MediCare2_0User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MediCare2_0Context>();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
AppDbInitializer.Seed(app);
app.Run();
