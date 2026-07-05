using HotelApi.Domen;

namespace HotelApi.Business_Layer
{
    public interface IRoomService
    {
        Task<decimal> TakeRoom(int id);
        Task CheckRoom(int id);
        Task<IEnumerable<RoomClass>> GetAll();
        Task CreateRoom(RoomClass room);
        Task PutRoom(RoomClass room);
        Task DeleteRoom(int id);
        public Task<RoomClass?> GetRoom(int id);

        /// <summary>
        /// Бизнес-правило: определяет категорию номера по его стоимости.
        /// </summary>
        RoomCategory GetCategory(RoomClass room);
    }
}
