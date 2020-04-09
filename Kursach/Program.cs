using System;

namespace Kursach
{
    class Program
    {
        static void Main(string[] args)
        {
            Room[] EmptyRooms;
            Room[] PaidRooms;
            Room[] BookedRooms;
            Room room1 = new Room(3, "luxe");
            Room room2 = new Room(2, "economy");
            Room room3 = new Room(3, "economy");
            Room room4 = new Room(4, "normal");
            room1.Book(10);
            room2.ToPay(4);
            room1.PaidAfterBooking();
            (EmptyRooms, PaidRooms, BookedRooms) = Room.GetInfo;
        }
    }
}
