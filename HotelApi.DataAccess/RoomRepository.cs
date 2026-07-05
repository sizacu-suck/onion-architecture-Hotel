using HotelApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.DataAccess;

public class RoomRepository : IRoomRepository
{
    private readonly Context context;

    public RoomRepository(Context _context)
    {
        this.context = _context;
    }

    public async Task<IEnumerable<RoomClass>> GetAll()
    {
        return await context.Room.ToListAsync();
    }

    public async Task<RoomClass?> Get(int id)
    {
        return await context.Room.FindAsync(id);
    }

    public async Task AddAsync(RoomClass room)
    {
        await context.Room.AddAsync(room);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RoomClass room)
    {
        context.Room.Update(room);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var room = await context.Room.FindAsync(id);

        context.Room.Remove(room);
        await context.SaveChangesAsync();
    }
}
