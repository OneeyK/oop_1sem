#include <iostream>
#include <cstring>

using namespace std;

class MyString {
protected:
  char *str;

public:
  MyString(const string& _s) : str(strdup(_s.c_str())) {}

  ~MyString() {
    free(str);
  }

  virtual int GetLength() {
    return strlen(str);
  }
};

class MySymbol : public MyString {
public:
  MySymbol(const string& s) : MyString(s) {}

  void Exchange(char character, char changeto) {
    int len = GetLength();
    for (int i = 0; i < len; i++) {
      if (str[i] == character) {
        str[i] = changeto;
      }
    }
  }

  int GetLength() {
    return MyString::GetLength();
  }
};

int main() {
  // MyString *a = new MyString("qwerty");

  MySymbol *x = new MySymbol("asadc");
  x->Exchange('a', 'p');
  x->GetLength();
  delete x;

  return 0;
}
