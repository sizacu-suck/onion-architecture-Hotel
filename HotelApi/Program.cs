using HotelApi;
using HotelApi.Business_Layer;
using HotelApi.Domen;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();

var app = builder.Build();


app.MapControllers();

app.Run();
