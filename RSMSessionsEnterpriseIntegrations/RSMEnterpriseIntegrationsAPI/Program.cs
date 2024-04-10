using Microsoft.EntityFrameworkCore;

using Domain.Interfaces;

using Application.Interfaces;
using Application.Services;

using Infrastructure.Context;
using Infrastructure.Repositories;

using RSMEnterpriseIntegrationsAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication("Bearer")
 .AddJwtBearer(opt =>
 {
     var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
     var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

     opt.RequireHttpsMetadata = false;

     opt.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateAudience = false,
         ValidateIssuer = false,
         IssuerSigningKey = signingKey
     };
 });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdvWorksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        opt => opt.MigrationsAssembly(typeof(AdvWorksDbContext).Assembly.FullName));
});

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<ISalesOrderHeaderRepository, SalesOrderHeaderRepository>();
builder.Services.AddTransient<ISalesOrderHeaderService, SalesOrderHeaderService>();

builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();

builder.Services.AddTransient<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
