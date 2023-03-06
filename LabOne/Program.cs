using LabOne.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

//¬ходна€ точка программы

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

WebApplication app = builder.Build();

app.MapRazorPages();

app.Run();
