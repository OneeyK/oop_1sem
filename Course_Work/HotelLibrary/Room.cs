using System;
namespace HotelLibrary
{
    public class Room : IHotel
    {
        protected internal event RoomStateHandler AddedRoom;

        protected internal event RoomStateHandler BookedRoom;

        protected internal event RoomStateHandler PaidForRoom;

        protected internal event RoomStateHandler PaidAfterBookingRoom;

        protected internal event RoomStateHandler FreeRoom;

        protected internal event RoomStateHandler GotInfo;

        public int _guests { get; private set; }
        public string guest_name { get; private set; }
        public int _days { get; private set; }
        private string _categorie;
        private int _price;
        public string status { get; private set; }
        public int Id { get; private set; }
        static int counter = 0;

        public Room(int guests, string categorie)
        {
            int price = 0;
            _guests = guests;
            _categorie = categorie;
            switch (_categorie)
            {
                case "luxe":
                    price = 50;
                    break;
                case "normal":
                    price = 30;
                    break;
                case "economy":
                    price = 15;
                    break;
            }
            _price = price;
            status = "Empty";
            Id = ++counter;
        }

        private void CallEvent(RoomEventArgs e, RoomStateHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }

        protected void OnGotInfo(RoomEventArgs e)
        {
            CallEvent(e, GotInfo);
        }

        protected void OnFreeRoom(RoomEventArgs e)
        {
            CallEvent(e, FreeRoom);
        }

        protected void OnBookedRoom(RoomEventArgs e)
        {
            CallEvent(e, BookedRoom);
        }

        protected void OnAddedRoom(RoomEventArgs e)
        {
            CallEvent(e, AddedRoom);
        }

        protected void OnPaidForRoom(RoomEventArgs e)
        {
            CallEvent(e, PaidForRoom);
        }

        protected void OnPaidAfterBookingRoom(RoomEventArgs e)
        {
            CallEvent(e, PaidAfterBookingRoom);
        }

        protected internal void GetInfo()
        {
            OnGotInfo(new RoomEventArgs($"Information about room #{Id}"));
            if (this.status == "Empty")
            {
                Console.WriteLine("Room is free at the moment");
            }
            else if (this.status == "Booked")
            {
                Console.WriteLine($"Room was booked for {this._days} days, for {this._guests} people.Payer - {this.guest_name}");
            }
            else
            {
                Console.WriteLine($"Room was paid for {this._days} days, for {this._guests} people.Payer -  {this.guest_name}");
            }
        }

        public int Pay(int days, string name)
        {
            this._days = days;
            this.guest_name = name;
            OnPaidForRoom(new RoomEventArgs($"{this.guest_name} paid {_price * this._days} for the room"));
            this.status = "Paid";
            return _price * this._days;
        }

        public void Book(int days, string name)
        {
            this.guest_name = name;
            this._days = days;
            this.status = "Booked";
            OnBookedRoom(new RoomEventArgs($"{this.guest_name} booked the room"));
        }

        protected internal int PaidAfterBooking()
        {
            OnPaidAfterBookingRoom(new RoomEventArgs($"{this.guest_name} paid {_price * this._days} after booking!"));
            this.status = "Paid";
            return _price * this._days;
        }

        protected internal void Free()
        { 
            OnFreeRoom(new RoomEventArgs($"Room #{Id} is now free"));
            this.status = "Empty";
        }

        protected internal virtual void AddRoom()
        {
            OnAddedRoom(new RoomEventArgs($"New room has been added. Room number - #{Id}"));
        }
    }
}
