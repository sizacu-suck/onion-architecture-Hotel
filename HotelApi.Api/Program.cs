using HotelApi.DataAccess;
using HotelApi.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDataAccess(connectionString);
builder.Services.AddBusinessServices();

var app = builder.Build();

app.MapControllers();

app.Run();
