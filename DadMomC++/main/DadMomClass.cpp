#include "DadMomClass.h"
#include<iostream>
#include<thread>
#include<chrono>
#include<mutex>

using namespace std;

int DadMomClass::numberRepeat;
string DadMomClass::checkNumber;
mutex mut;
mutex mut1;

DadMomClass::DadMomClass(string message, int repeat, int timeDelay)
{
	_message = message;
	_repeat = repeat;
	_timeDelay = timeDelay;
}

void DadMomClass::operator()()
{
	if (checkNumber == "Y") {
		for (int i = 0; i < numberRepeat; ++i) {
			if (numberRepeat == 0) {
				break;
			}
			this_thread::sleep_for(chrono::milliseconds{ _timeDelay });
			mut.lock();
			cout << _message << endl;
			mut.unlock();
			--numberRepeat;
		}
	}

	if (checkNumber == "N") {
		for (int i = 0; i < _repeat; ++i) {
			this_thread::sleep_for(chrono::milliseconds{ _timeDelay });
			mut1.lock();
			cout << _message << endl;
			mut1.unlock();
		}
	}

	if (checkNumber != "Y" && checkNumber != "N") {
		cout << "Вы не выбрали вариант окончания программы" << endl;
	}
}
