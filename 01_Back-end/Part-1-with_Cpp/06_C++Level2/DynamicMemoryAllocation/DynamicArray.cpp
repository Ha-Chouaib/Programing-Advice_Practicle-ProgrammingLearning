#include <iostream>
using namespace std;



int main(){

    int num=0;
    cout<<"How many students you want add there Degrase\n";
    cin>> num;

    float* ptr;
    ptr= new float[num];

    cout<<"Enter students Grades:\n";
    for(int i=0; i<num; i++)
    {
        cout<<"Student[ "<< i+1 <<" ]: ";
        cin>> *(ptr + i);
    }

    cout<<"Display Results:\n";
    for(int i =0 ; i< num; i++)
    {
        cout<<"student( "<< i+1 <<" ) :"<< *(ptr + i) <<endl;
    }

    delete []ptr;

    return 0;
}