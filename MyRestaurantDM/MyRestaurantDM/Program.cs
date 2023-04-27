using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyRestaurantDM.Data;
using MyRestaurantDM.Mappings;
using MyRestaurantDM.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<IOrderRepo ,  OrderRepo>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

//To make use of AutoMapper , Following code need to be used
builder.Services.AddAutoMapper(typeof(AutoMapperProfies));

builder.Services.AddDbContext<MyRestaurantDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AuthDMDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConnection")));

builder.Services.AddScoped<IItemRepo,ItemRepo>();

//62.SettingUp Identity
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("MyRestaurant")
    .AddEntityFrameworkStores<AuthDMDbContext>()
    .AddDefaultTokenProviders();
//Setting Password
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequiredLength = 6;
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt : Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
