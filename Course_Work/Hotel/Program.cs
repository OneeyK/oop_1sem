using System;
using HotelLibrary;

namespace Kursovaya
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel<Room> hotel = new Hotel<Room>("Avrora");
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Add room \t\t 2. Pay for room   \t 3. Book room");
                Console.WriteLine("4. Pay after booking \t 5. Free room   \t 6. Get info of the room");
                Console.WriteLine("Enter the number:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            AddNewRoom(hotel);
                            break;
                        case 2:
                            Pay(hotel);
                            break;
                        case 3:
                            Book(hotel);
                            break;
                        case 4:
                            PayAfterBooking(hotel);
                            break;
                        case 5:
                            FreeRoom(hotel);
                            break;
                        case 6:
                            GetInfo(hotel);
                            break;
                        case 0:
                            alive = false;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void AddNewRoom(Hotel<Room> hotel)
        {
            Console.WriteLine("Enter the number of guests");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter category of the room (economy/normal/luxe)");
            string z = Convert.ToString(Console.ReadLine());

            hotel.RoomAdd(x, z,
                AddRoomHandler,
                BookHandler,
                PaidAfterBookingHanlder,
                PayHandler,
                FreeRoomHandler,
                GetInfoHandler
                );
        }

        private static void Pay(Hotel<Room> hotel)
        {
            Console.WriteLine("Enter room number");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("For how many days does customer want to live in the room");
            int days = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter customers name please");
            string name = Console.ReadLine();

            hotel.Pay(id, days, name);
        }

        private static void Book(Hotel<Room> hotel)
        {
            Console.WriteLine("Enter room number");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("For how many days does customer want to book the room");
            int days = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter customers name please");
            string name = Console.ReadLine();

            hotel.Book(id, days, name);
        }

        private static void PayAfterBooking(Hotel<Room> hotel)
        {
            Console.WriteLine("Enter room number");
            int id = Convert.ToInt32(Console.ReadLine());

            hotel.PaidAfterBooking(id);
        }

        private static void FreeRoom(Hotel<Room> hotel)
        {
            Console.WriteLine("Enter room number");
            int id = Convert.ToInt32(Console.ReadLine());

            hotel.Free(id);
        }

        private static void GetInfo(Hotel<Room> hotel)
        {
            Console.WriteLine("Enter room number");
            int id = Convert.ToInt32(Console.ReadLine());

            hotel.GetInfo(id);
        }

        private static void GetInfoHandler(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void FreeRoomHandler(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void AddRoomHandler(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void BookHandler(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void PaidAfterBookingHanlder(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void PayHandler(object sender, RoomEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
