using CRUD.Models;
using CRUD.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.OpenApi.Models;
using ProductsApi.Models;
using System.Reflection;
using CRUD.Middleware;
using CRUD.Decorators;
using CRUD.Queries;
using FluentValidation;
using System;
using CRUD.Validators;
using FluentValidation.AspNetCore;
using CRUD.HTTPClientShowCase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));


builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.Decorate(typeof(IRequestHandler<GetProductListCommand, List<Product>>), typeof(ProductQueryHandlerDecorator));

// we want the instance to be alive and available for the entire scope of the given HTTP request
builder.Services.AddScoped<IProductRepository, SQLProductRepository>();
// an example of the Strategy pattern is to choose whether you want to work with sql database  or in memory data
// we want the in memory repositry instance to be the same one through the life time of the application so the data is not lost every time w make an HTTP request
//builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

builder.Services.AddControllers().AddFluentValidation(v=>v.RegisterValidatorsFromAssemblyContaining<Product>());

builder.Services.AddHttpClient<IUsersService, UsersHttpClient>();
builder.Services.AddMemoryCache();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAngularOrigins");
app.UseMiddleware<ExceptionHandling>();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
