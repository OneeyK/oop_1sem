using System;

namespace Laba7
{
    class Program
    {
        static void Main(string[] args)
        {
            CharList<char> charList = new CharList<char>();
            charList.Add(']');
            charList.Add('g');
            charList.Add('f');
            charList.Add('q');
            charList.Add('x');
            charList.Add('a');
            charList.DeleteMoreThanA();
        }
    }
}
