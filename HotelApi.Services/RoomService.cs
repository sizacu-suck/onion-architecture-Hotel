using HotelApi.Domain;

namespace HotelApi.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        // Пороги цены, по которым определяется категория номера.
        private const decimal ComfortThreshold = 3000m;
        private const decimal LuxThreshold = 6000m;

        // Сервисный сбор при бронировании — зависит от категории номера.
        private const decimal StandardServiceFeeRate = 0.05m;
        private const decimal ComfortServiceFeeRate = 0.08m;
        private const decimal LuxServiceFeeRate = 0.12m;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }




        public async Task CheckRoom(int id)
        {
            var room = await _roomRepository.Get(id)
                ?? throw new RoomNotFoundException($"Комната {id} не найдена");

            if (room.busy == true)
            {
                throw new RoomNotBookedException("Комната уже забронирована");
            }
        }

        public async Task CreateRoom(RoomClass room)
        {
            if (room.cost <= 0)
            {
                throw new InvalidRoomPriceException("У комнаты не может быть отрицательная цена");
            }

            await _roomRepository.AddAsync(room);
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _roomRepository.Get(id)
                ?? throw new RoomNotFoundException($"Комната {id} не найдена");

            if (room.busy)
            {
                throw new RoomNotEmptyException("Для удаления комната должна быть пустой");
            }

            await _roomRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoomClass>> GetAll()
        {
            return await _roomRepository.GetAll();
        }

        public async Task<RoomClass?> GetRoom(int id)
        {
            var room = await _roomRepository.Get(id) ??
                throw new RoomNotFoundException($"Комната {id} не найдена");

            return room;
        }

        public async Task PutRoom(RoomClass room)
        {
            var res = await _roomRepository.Get(room.id)
                ?? throw new RoomNotFoundException($"Комната {room.id} не найдена");

            if (room.cost <= 0)
            {
                throw new InvalidRoomPriceException("У комнаты не может быть отрицательная цена");
            }

            await _roomRepository.UpdateAsync(room);
        }

        /// <summary>
        /// Бронирует номер и рассчитывает итоговую цену с учётом сервисного сбора,
        /// зависящего от категории номера.
        /// </summary>
        public async Task TakeRoom(int id)
        {
            var room = await _roomRepository.Get(id)
                ?? throw new RoomNotFoundException($"Комната {id} не найдена");

            if (room.busy)
            {
                throw new RoomNotBookedException("Комната уже забронирована");
            }

            room.busy = true;
            await _roomRepository.UpdateAsync(room);

        }
    }
}
