using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.AutoMapper;
using TestTask.BusinessLayer.Implementations;
using TestTask.BusinessLayer.Interfaces;
using TestTask.DataAccess;
using TestTask.DataAccess.Implementations;
using TestTask.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NewsSiteDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("TestTask.DataAccess")));

builder.Services.AddTransient<IArticlesRepository, ArticlesRepository>();
builder.Services.AddTransient<IArticlesService, ArticlesService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = new PathString("/Account/Login");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
