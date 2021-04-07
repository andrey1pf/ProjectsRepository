#include "DadMomClass.h"
#include<iostream>
#include<string>
#include<vector>
#include<thread>

using namespace std;

int main()
{
    setlocale(LC_ALL, "Russian");

    int numberThread;
    int repeat;
    int timeDelay;
    string message;

    vector<DadMomClass> properties;

    cout << "Какое кол-во сообщений хотите вывести?" << endl;
    cin >> DadMomClass::numberRepeat;
    cout << "Какое кол-во тредов хотите создать?" << endl;
    cin >> numberThread;
    for (int i = 0; i < numberThread; ++i) {
        cout << "Что будет в " << i + 1 << " треде?" << endl;
        cin >> message;
        cout << "Какое кол-во раз вывести сообщение в " << i + 1 << " треде?" << endl;
        cin >> repeat;
        cout << "Какая будет заддержка при выводе сообщения в " << i + 1 << " треде?" << endl;
        cin >> timeDelay;
        DadMomClass DadMom{ message, repeat, timeDelay };
        properties.push_back(DadMom);
    }

    cout << "Закончить программу по достижению общего кол-ва сообщений [Y/N]" << endl;
    cin >> DadMomClass::checkNumber;

    vector<thread> thr(numberThread);

    for (int i = 0; i < numberThread; ++i) {
        thr[i] = thread(properties[i]);
    }

    for (int i = 0; i < numberThread; ++i) {
        thr[i].join();
    }
}
