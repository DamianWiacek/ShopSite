using ShopSite.Entities;
using ShopSite.Services;
using NLog.Web;
using ShopSite.Middleware;
using Microsoft.AspNetCore.Identity;
using ShopSite.Models;
using FluentValidation;
using ShopSite.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using ShopSite.Repositories;

var builder = WebApplication.CreateBuilder(args);

var authenticationSettings = new ShopSite.AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
// Add services to the container.

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg => {
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddDbContext<ShopDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Services DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

//Repositories DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IPasswordHasher<User>,PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<NewUserDto>,NewUserDtoValidator>();

//Middleware DI
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseNLog();
builder.Services.AddCors(setup =>
{
    setup.AddPolicy("ui", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
            .WithOrigins(

                "http://localhost:8080",
                "http://localhost:4200");
    });
});


var app = builder.Build();

app.UseCors("ui");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
