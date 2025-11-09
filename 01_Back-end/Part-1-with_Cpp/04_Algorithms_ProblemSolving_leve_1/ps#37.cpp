#include <iostream>
#include <string>
using namespace std;

float ReadNumber(string MSG){

    float Num=0;
    cout<< MSG << endl;
    cin>>Num;

    return Num;
}

float SumNumbers(){

    cout<<"Enter [-99] to stop thr Calculation"<<endl;
    int Sum=0, Num= 0, counter=1;
    do{
        Num= ReadNumber("Enter the number " + to_string(counter) );
        if(Num == -99)
            break;
        Sum+=Num;
        counter++;
    }while(Num != -99);
    return Sum;
}

int main(){
    float Result=SumNumbers();
    cout<<"Result ="<<Result<<endl;
    return 0;
}