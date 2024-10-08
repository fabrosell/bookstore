using Bookstore.API;
using Bookstore.Domain;
using Bookstore.Infra.Data.Context;
using Bookstore.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookstoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreConnection")));

// Bookstore configuration services
builder.Services.AddSingleton(typeof(WebApplicationBuilder), builder);
builder.Services.AddSingleton<IBookstoreConfiguration, BookstoreConfiguration>();

// Bookstore services
builder.Services.RegisterServices();


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
