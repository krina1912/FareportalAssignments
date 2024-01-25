using Microsoft.EntityFrameworkCore;
using ServerSide.Models;
using ServerSide.Repository;
using ServerSide.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFlight<KrinaFlight>,FlightRepo>();
builder.Services.AddScoped<IFlightServ<KrinaFlight>,FlightServ>();
builder.Services.AddScoped<ILogin<KrinaCustomer>,LoginRepo>();
builder.Services.AddScoped<ILoginServ<KrinaCustomer>,LoginServ>();

builder.Services.AddDbContext<Ace52024Context>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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