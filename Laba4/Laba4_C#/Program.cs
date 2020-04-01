using System; 
 
namespace Laba4 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            Coord L1 = new Coord(); 
            Coord L2 = new Coord(2, 19); 
            Coord L3 = new Coord(L2); 
            L2 = L2 * 2; 
            L1 = L3 + L2; 
        } 
    } 
}
