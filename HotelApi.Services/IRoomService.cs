using HotelApi.Domain;

namespace HotelApi.Services
{
    public interface IRoomService
    {
        Task TakeRoom(int id);
        Task CheckRoom(int id);
        Task<IEnumerable<RoomClass>> GetAll();
        Task CreateRoom(RoomClass room);
        Task PutRoom(RoomClass room);
        Task DeleteRoom(int id);
        Task<RoomClass?> GetRoom(int id);
    }
}
