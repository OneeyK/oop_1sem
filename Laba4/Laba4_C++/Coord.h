#include <iostream>
#include <cmath>

using namespace std;

class Coord {
    double x, y;

public:
    Coord() : x(0.0), y(0.0) {
    }

    Coord(double start, double end) : x(start), y(end) {
    }

    Coord(const Coord& c) : x(c.x), y(c.y) {
    }

    double GetLength() const {
        return abs(this->y) - abs(this->x);
    }

    void GetInfo() const {
        cout << "X-position is " << this->x;
        cout << " and Y-position is " << this->y;
        cout << endl;
    }

    friend Coord operator+(const Coord& L1, const Coord& L2) {
        return Coord(L1.x + L2.x, L1.y + L2.y);
    }

    friend Coord operator*(const Coord& L1, int a) {
        return Coord(L1.x * a, L1.y * a);
    }
};
