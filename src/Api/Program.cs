using Marthada.Infrastructures.Data;
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

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
