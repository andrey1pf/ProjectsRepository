#include<iostream>
#include<string>

using namespace std;

class ProgramFunctionalClasses
{
private:
    static int AmountOfNumbers(string line) {
        int CountNumbers = 0;
        for (int i = 0; i <= line.length(); ++i) {
            if (line[i] >= '0' && line[i] <= '9') {
                ++CountNumbers;
            }
        }
        return CountNumbers;
    }
public:
    bool operator()(string quantity1, string quantity2) {
        return AmountOfNumbers(quantity1) > AmountOfNumbers(quantity2);
    }
};
