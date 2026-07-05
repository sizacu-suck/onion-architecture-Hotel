using HotelApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApi.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IRoomRepository, RoomRepository>();
            return services;
        }
    }
}
