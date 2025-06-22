using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using XPE.Desafio.Final5.API.Model.Domains;
using XPE.Desafio.Final5.API.Model.Respositories.Data.Context;
using XPE.Desafio.Final5.API.Model.Respositories.Implementation;
using XPE.Desafio.Final5.API.Model.Respositories.Interfaces;
using XPE.Desafio.Final5.API.Model.Services.Implementation;
using XPE.Desafio.Final5.API.Model.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(option => {
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<MyDbContext>();

builder.Services.AddScoped<IDefaultRepository<Product>, DefaultRepository<Product>>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
