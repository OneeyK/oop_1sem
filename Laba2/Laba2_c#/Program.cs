using System; 
 
namespace laba2_oop 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            MyString str1 = new MyString("ab"); 
            MyString str2 = new MyString("b"); 
            MyString str3 = new MyString("c"); 
            MyText text1 = new MyText(); 
            text1.AddString(str1); 
            text1.AddString(str2); 
            text1.AddString(str3); 
            text1.FindStr(str1); 
        } 
    } 
}
