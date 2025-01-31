#include <iostream>
using namespace std;

struct stCalculationInfo
{
    int numbers[100];
    float result=0;
    short ShouldStopIn;
};

stCalculationInfo GetNumbers()
{

    stCalculationInfo CalculationInfo;

    cout<<"Enter: [0000] to stop the Operation."<<endl;

    int counter=0;
    while(counter <=100){

        cout<<"please enter the number: ";
        cin>>CalculationInfo.numbers[counter];

        if(CalculationInfo.numbers[counter]== 0000){
            CalculationInfo.ShouldStopIn= counter;
            break;
        }
            
        counter++;
    }
    return CalculationInfo;
}

float SumOfNumbers(stCalculationInfo Number)
{

    for(int i=0; i<Number.ShouldStopIn; i++){

        Number.result+= Number.numbers[i];
    }

    return Number.result;

}

void ShowResult(float Result)
{
    cout<<endl<<"The Result is: "<< Result<<endl;
}

int main(){
    ShowResult(SumOfNumbers(GetNumbers()));
    return 0;
}