using System;

namespace laba2_oop
{
    public class MyText
    {

        MyString[] Text;
        int size;

        public void AddString(MyString str)
        {
            Array.Resize(ref Text, ++size);
            Text[size - 1] = str;
        }

        public void RemoveString(int delIndex)
        {
            var newData = new MyString[Text.Length - 1];
            for (int i = 0; i < delIndex; i++)
            {
                newData[i] = Text[i];
            }
            for (int i = delIndex; i < newData.Length; i++)
            {
                newData[i] = Text[i + 1];
            }
            Text = newData;
            size--;
        }

        public void Erase()
        {
            MyString[] text = new MyString[0];
            Text = text;
            size = 0;
        }
        
        public int FindStr(MyString str)
        {
            int counter = 0;
            foreach (var item in Text)
            {
                if (item.ToChar == str.ToChar)
                {
                    counter++;
                }
            }
            return counter;
        }

        public void DelLen(int n)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                if(Text[i].GetLength() == n)
                {
                    RemoveString(i);
                }
            }
        }

        public void UppLetters()
        {
            for (int i = 0; i < Text.Length; i++)
                Text[i].UppLetters();
        }
    }
}
