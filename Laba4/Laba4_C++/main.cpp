#include <iostream>
#include <cmath>
#include "Coord.h"

using namespace std;

int main() {
    Coord L1;
    Coord L2(2, 19);
    Coord L3(L2);
    L2 = L2 * 2;
    L1 = L3 + L2;
    L1.GetInfo();
}
