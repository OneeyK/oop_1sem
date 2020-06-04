using System;
namespace HotelLibrary
{
    public class NewRoom : Room
    {
        public NewRoom(int guests, string categorie) : base(guests, categorie)
        {
        }

        protected internal override void AddRoom()
        {
            base.AddRoom();
        }
    }
}
