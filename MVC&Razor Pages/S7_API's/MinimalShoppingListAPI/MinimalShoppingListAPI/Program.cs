//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//// Learn more about configuring Swagger/OpenAPI at 
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

//app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}

using Microsoft.EntityFrameworkCore;
using MinimalShoppingListAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(opt =>opt.UseInMemoryDatabase("ShopppingListApi"));

var app = builder.Build();

app.MapGet("/shoppinglist", async (ApiDbContext db) =>
{
    return await db.Groceries.ToListAsync();
});


app.MapPost("/shoppinglist", async (Grocery grocery, ApiDbContext db) =>
{
    db.Groceries.Add(grocery);
    await db.Groceries.ToListAsync();
    return Results.Created($"/shoppinglist/{grocery.Id}", grocery);
});

app.MapGet("/shoppinglist/{id}", async (int id, ApiDbContext db) =>
{
    var grocery = await db.Groceries.FindAsync(id);
    return grocery != null ? Results.Ok(grocery) : Results.NotFound();
});

app.MapDelete("/shoppinglist/{id}", async (int id, ApiDbContext db) =>
{
    var grocery = await db.Groceries.FindAsync(id);
    if(grocery != null)
    {
        db.Groceries.Remove(grocery);
      await  db.Groceries.ToListAsync();
        return Results.NoContent();

    }

    return Results.NotFound();
 
});

app.MapPut("/shoppinglist/{id}", async(int id,Grocery grocery, ApiDbContext db) =>

{
    var groceryIn = await db.Groceries.FindAsync(id);

    if(groceryIn != null)
    {
        db.Update(grocery);

        await db.SaveChangesAsync();
        return Results.Ok(groceryIn);
    }
    return Results.NotFound();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.Run();