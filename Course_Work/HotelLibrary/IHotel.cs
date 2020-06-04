using System;
namespace HotelLibrary
{
    public interface IHotel
    {
        int Pay(int days, string name);
        void Book(int days, string name);
    }
}
