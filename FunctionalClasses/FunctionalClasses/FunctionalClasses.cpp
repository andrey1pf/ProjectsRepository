#include<iostream>
#include<fstream>
#include<list>
#include<iterator>
#include<string>
#include<algorithm>
#include "ProgramFunctionalClasses.h"

using namespace std;

int main() {

	ifstream input("input.txt");

    if (!input) {
        cerr << "Error. Input file not found. Create an input file at the root of the project...";
        return -1;
    }
    if (input.peek() == EOF) {
        cerr << "Error. The file is empty. Check it's content..." << endl;
        return 1;
    }

    list<string> CharacterList;
    string line;
    ProgramFunctionalClasses function;
    int CountFiveSizeRange = 0;

    cout << "Five lines containing the most number of DIGITS :" << endl;

    while (getline(input, line)) {
        if (line.length() > 100) {
            cerr << "Error. The string is longer than 100 characters. Make the line shorter ..." << endl;
            return 2;
        }
        CharacterList.push_back(line);
    }
    input.close();

    CharacterList.sort(function);

    list <string>::iterator i;
    for (i = CharacterList.begin(); i != CharacterList.end(); ++i) {
        cout << *i << endl;
        ++CountFiveSizeRange;
        if (CountFiveSizeRange == 5) break; // крутой костыль!
    }

	return 0;
}
