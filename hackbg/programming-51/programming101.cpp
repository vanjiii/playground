#include <iostream>
#include <algorithm>

using namespace std;

bool Exoh(string);
bool ABCheck(string);
string dashInsert(int);

int main() {
    cout << dashInsert(99946);
    cout << endl;
    cout << dashInsert(56730);
    cout << endl;
    return 0;
}

string dashInsert(int num){
    string str = to_string(num);
    string output;
    int currentDigit;
    int nextDigit;

    for (int i = 0; i < str.length() - 1; i++) {
        currentDigit = (int)str[i];
        nextDigit = (int)str[i + 1];
        if((currentDigit % 2 == 1) &&
            nextDigit % 2 == 1
            ){
            output += currentDigit;
            output += '-';
        }else {
            output += str[i];
        }
    }

    output += str[str.length() - 1];
    return output;
}

bool Exoh (string string1){
    int x = 0;
    int o = 0;
    for (int i = 0; i < string1.length(); i++) {
        switch (string1[i]){
            case 'o':
                o++;
                break;
            case 'x':
                x++;
                break;
        }
    }
    return x == o ? true : false;
}

bool ABCheck(string str){
    int placesBetween = 4;
    transform(str.begin(), str.end(), str.begin(), ::tolower);

    for (int i = 0; i < str.length() - placesBetween; i++) {
        if (str[i] == 'a'){
            if (str[i + placesBetween] == 'b'){
                return true;
            }
        } else if (str[i] == 'b'){
            if (str[i + placesBetween] == 'a'){
                return true;
            }
        }
    }
    return false;
}