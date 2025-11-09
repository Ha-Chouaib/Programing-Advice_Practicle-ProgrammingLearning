// #pragma warning(disable : 4996)

#include<iostream>
#include<ctime>
using namespace std;



int main()
{
    time_t t= time(0);//--> Gives the current local time.
    char *dt= ctime(&t);//--> convert the current time to readable string.
    cout<<"Local time and date: "<< dt << endl;

    tm* gmtm= gmtime(&t);//--> convert current time to UTC time and date.
    
    dt= asctime(gmtm);

    cout<<"UTC date and time: "<< dt <<endl;

    return 0;
}