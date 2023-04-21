using ApiHero.Context;
using ApiHero.Models;
using ApiHero.Services;
using Microsoft.EntityFrameworkCore;
//using ApiHero.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Hero;Integrated Security=True;Encrypt=False;"));
});

builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<IPowerService, PowerService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
