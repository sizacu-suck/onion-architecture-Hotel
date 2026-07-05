using Microsoft.EntityFrameworkCore;

namespace HotelApi
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
