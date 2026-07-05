namespace HotelApi.Domain
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomClass>> GetAll();
        Task<RoomClass?> Get(int id);
        Task AddAsync(RoomClass room);
        Task UpdateAsync(RoomClass room);
        Task DeleteAsync(int id);
    }
}
