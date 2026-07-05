using HotelApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<RoomClass> Room { get; set; }
    }
}
