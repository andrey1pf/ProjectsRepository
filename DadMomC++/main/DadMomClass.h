#pragma once
#include<string>

using namespace std;

class DadMomClass
{
private:
	int _repeat;
	int _timeDelay;
	string _message;
public:
	static int numberRepeat;
	static string checkNumber;
	DadMomClass(string, int, int);
	void operator()();
};

