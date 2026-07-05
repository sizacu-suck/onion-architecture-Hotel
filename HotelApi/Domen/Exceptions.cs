namespace HotelApi.Domen
{
    public class RoomNotBookedException : Exception
    {
        public RoomNotBookedException(string message) : base(message) { }
    }
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException(string message) : base(message) { }

    }
    public class InvalidRoomPriceException : Exception
    {
        public InvalidRoomPriceException(string message) : base(message) { }

    }
    public class RoomNotEmptyException : Exception
    {
        public RoomNotEmptyException(string message) : base(message) { }

    }
    public class InvalidRoomDescriptionException : Exception
    {
        public InvalidRoomDescriptionException(string message) : base(message) { }
    }
}
