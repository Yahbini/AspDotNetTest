using AspDotNetTest.Areas.Admin.Service;
using AspDotNetTest.Areas.Employee.Service;
using AspDotNetTest.Areas.EmplSupport.Service;
using AspDotNetTest.Models;
using AspDotNetTest.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"].ToString();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();

// admin
builder.Services.AddScoped<EmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<RequestService, RequestServiceImpl>();

// employee
builder.Services.AddScoped<EmployeeReqService, EmployeeReqServiceImpl>();

// employee support
builder.Services.AddScoped<RequestEmplSupportService, RequestEmplSupportServiceImpl>();

// login
builder.Services.AddScoped<LoginService, LoginServiceImpl>();

builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute(
    name: "myareas",
    pattern: "{area:exists}/{controller}/{action}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");


app.Run();
