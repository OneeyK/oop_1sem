using System;
namespace HotelLibrary
{ 
    public delegate void RoomStateHandler(object sender, RoomEventArgs e);

    public class RoomEventArgs
    {
        public string Message { get; private set; }
        public RoomEventArgs(string _mes)
        {
            Message = _mes;
        }
    }
}
