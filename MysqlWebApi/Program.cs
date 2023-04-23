
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MysqlWebApi;
using MysqlWebApi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityFrameworkMySQL().AddDbContext<DBContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("custom-header", path );
//    await next();
//});
app.UseMiddleware<SimpleMiddleware>();

app.MapControllers();

app.Run();
