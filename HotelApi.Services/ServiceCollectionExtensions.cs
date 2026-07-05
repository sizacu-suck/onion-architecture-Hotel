using Microsoft.Extensions.DependencyInjection;

namespace HotelApi.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            return services;
        }
    }
}
