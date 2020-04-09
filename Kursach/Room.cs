using System;
namespace Kursach
{
    public class Room
    {
        private int guests;
        private int days;
        private int price;
        private string categorie;
        private string status;
        private static int size;
        public static int revenue = 0;
        static Room[] rooms;
        

        public Room(int numberofbeds, string roomcategorie)
        {
            guests = numberofbeds;
            categorie = roomcategorie;
            Array.Resize(ref rooms, ++size);
            rooms[size - 1] = this;
            status = "Empty";
        }

        public int ToPay(int numberofdays)
        {
            days = numberofdays;
            switch (categorie)
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
            this.status = "Paid";
            revenue += this.guests * price * this.days;
            return this.guests * price * this.days;
        }

        public void Book(int numberofdays)
        {
            days = numberofdays;
            this.status = "Booked";
        }

        public int PaidAfterBooking()
        {
            if (this.status == "Booked")
            {
                switch (categorie)
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
                this.status = "Paid";
                revenue += this.guests * price * this.days;
                return this.guests * price * this.days;
            }
            else
            {
                this.status = "Empty";
                return 0;
            } 
         }

        public string RoomState
        {
            get
            {
                return this.status;
            }          
        }

        public static int TotalProfit
        {
            get
            {
                return revenue;
            }
        }

        public static (Room[] Empty,Room[] Paid, Room[] Booked) GetInfo
        {
            get
            {
                int _emptysize = 0;
                int _paidsize = 0;
                int _bookedsize = 0;
                Room[] Empty = new Room[_emptysize];
                Room[] Paid = new Room[_paidsize];
                Room[] Booked = new Room[_bookedsize];
                for (int i = 0; i < rooms.Length; i++)
                {
                    if (rooms[i].status == "Empty")
                    {
                        Array.Resize(ref Empty, ++_emptysize);
                        Empty[_emptysize - 1] = rooms[i];
                    }                      
                    else if (rooms[i].status == "Paid")
                    {
                        Array.Resize(ref Paid, ++_paidsize);
                        Paid[_paidsize - 1] = rooms[i];
                    }
                    else
                    {
                        Array.Resize(ref Booked, ++_bookedsize);
                        Booked[_bookedsize -  1] = rooms[i];
                    }                   
                }
                return (Empty, Paid, Booked);
            }
        }
    }
}
