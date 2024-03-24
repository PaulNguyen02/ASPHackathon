using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebEnvironment_Hackathon_GaMo.Context;
using WebEnvironment_Hackathon_GaMo.Models;
using WebEnvironment_Hackathon_GaMo.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebEnviDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("WebEnvi")));

builder.Services.AddIdentity<User, UserRole>()
    .AddEntityFrameworkStores<WebEnviDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
builder.Services.AddTransient<RoleManager<UserRole>, RoleManager<UserRole>>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EmailSender>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
