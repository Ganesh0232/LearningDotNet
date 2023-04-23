using Microsoft.EntityFrameworkCore;
using MyRestaurantDM.Data;
using MyRestaurantDM.Mappings;
using MyRestaurantDM.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<IOrderRepo ,  OrderRepo>();

//To make use of AutoMapper , Following code need to be used
builder.Services.AddAutoMapper(typeof(AutoMapperProfies));

builder.Services.AddDbContext<MyRestaurantDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IItemRepo,ItemRepo>();

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
