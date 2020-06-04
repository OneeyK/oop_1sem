using System;
namespace HotelLibrary
{

    public class Hotel<T> where T : Room
    {
        T[] rooms;
        public string _name { get; private set; }
        public Hotel(string name)
        {
            this._name = name;
        }

        public void RoomAdd(int guests, string categorie, RoomStateHandler addroomhandler,
            RoomStateHandler payhandler, RoomStateHandler bookhandler, RoomStateHandler paidafterbookinghanlder,
            RoomStateHandler freeroom, RoomStateHandler getinfo)
        {
            T newRoom = new NewRoom(guests, categorie) as T;
            if (newRoom == null)
                throw new Exception("Can't add the room");
            if (guests < 0)
                throw new Exception("Wrong number of guests");
            if (categorie != "luxe" && categorie != "economy" && categorie != "normal")
                throw new Exception("Wrong room category");
            if (rooms == null)
                rooms = new T[] { newRoom };
            else
            {
                T[] tempRooms = new T[rooms.Length + 1];
                for (int i = 0; i < rooms.Length; i++)
                    tempRooms[i] = rooms[i];
                tempRooms[tempRooms.Length - 1] = newRoom;
                rooms = tempRooms;
            }
            newRoom.AddedRoom += addroomhandler;
            newRoom.BookedRoom += bookhandler;
            newRoom.PaidAfterBookingRoom += paidafterbookinghanlder;
            newRoom.PaidForRoom += payhandler;
            newRoom.FreeRoom += freeroom;
            newRoom.GotInfo += getinfo;

            newRoom.AddRoom();
        }
        
        public void Pay(int id, int days, string name)
        {
            T room = FindRoom(id);
            if (room == null)
                throw new Exception($"Room #{id} was not found");
            if (room.status != "Empty")
                throw new Exception($"Room #{id} was already paid or booked");
            if (days < 0)
                throw new Exception("Wrong number of days");
            room.Pay(days, name);
        }

       public void Book(int id, int days, string name)
        {
            T room = FindRoom(id);
            if (room == null)
                throw new Exception($"Room #{id} was not found");
            if (room.status != "Empty")
                throw new Exception($"Room #{id} was already paid or booked");
            if (days < 0)
                throw new Exception("Wrong number of days");
            room.Book(days, name);
        }

        public void GetInfo(int id)
        {
            T room = FindRoom(id);
            if (room == null)
                throw new Exception($"Room #{id} was not found");
            room.GetInfo();
        }

        public void PaidAfterBooking(int id)
        {
            T room = FindRoom(id);
            if (room == null)
                throw new Exception($"Room #{id} was not found");
            if (room.status != "Booked")
                throw new Exception($"Room #{id} has not been booked");
            room.PaidAfterBooking();
        }

        public void Free(int id)
        {
            T room = FindRoom(id);
            if (room == null)
                throw new Exception($"Room #{id} was not found");
            if (room.status == "Empty")
                throw new Exception($"Room #{id} is already free");
            room.Free();
        }

        public T FindRoom(int id)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].Id == id)
                    return rooms[i];
            }
            return null;
        }
    }
}
