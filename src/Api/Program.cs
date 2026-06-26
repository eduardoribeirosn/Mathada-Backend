using Marthada.Api.Services.Categories.Queries;
using Marthada.Api.Services.Products.Commands;
using Marthada.Api.Services.Products.Queries;
using Marthada.Api.Services.Users.Commands;
using Marthada.Domain.Interfaces.Repositories;
using Marthada.Domain.Interfaces.Services.Commands;
using Marthada.Domain.Interfaces.Services.Queries;
using Marthada.Infrastructures.Data;
using Marthada.Infrastructures.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<MarthadaDbContext>(
    options => {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string não encontrada!");

        options.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        ); 
    }
);

// Scopeds
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommands, ProductCommands>();
builder.Services.AddScoped<IProductQueries, ProductQueries>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommands, UserCommands>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryQueries, CategoryQueries>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
