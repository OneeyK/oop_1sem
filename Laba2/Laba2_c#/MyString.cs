using System;
namespace laba2_oop
{
    public class MyString
    {
        char[] Str;

        public MyString(string str)
        {
            Str = str.ToCharArray();
        }

        public char[] ToChar
        {
            get
            {
                return Str;
            }
        }

        public int GetLength()
        {
            return Str.Length;
        }

        public void UppLetters()
        {
            for (int i = 0; i < Str.Length; i++)
                if (char.IsLetter(Str[i]))
                    Str[i] = char.ToUpper(Str[i]);
        }
    }
}
