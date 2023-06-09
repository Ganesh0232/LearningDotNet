using DMWalksAPI.Data;
using DMWalksAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DMWalksDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DMWalksConnectionString")));

builder.Services.AddScoped<IRegionRepo , SqlRegionRepo>();
//builder.Services.AddScoped<IRegionRepo, InMemoryRegionRepo>();

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
