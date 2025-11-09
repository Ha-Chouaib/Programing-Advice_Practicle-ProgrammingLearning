#include <iostream>
#include <string>
using namespace std;

//write a program that count How many time a specific number is repeated in array.

float ReadPositiveNumber(string MSG=""){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

void RedaArray(int Arr[100], int& ArrLength)
{
   ArrLength=ReadPositiveNumber("Enter number of element:");
   for(int i=0; i<ArrLength; i++)
   {
        cout<<"Element["<< i+1 <<"]: ";
        cin>>Arr[i];
   }
}

void PrintArray(int Arr[100],int ArrLength)
{
   for(int i=0; i<ArrLength; i++)
   {
    cout<<Arr[i] <<" ";
   }
   cout<<"\n";
}
int NumberRepeatCounting(int Arr[100], int ArrLength, int NumberToChek)
{
    int counter=0;
    for(int i=0; i<ArrLength; i++)
    {
        if(Arr[i]== NumberToChek)
            counter++;
    }
    return counter;
}
void DisplayResults(int Arr[100],int ArrLength,int NumberToCheck )
{
    cout<<"Original array is: " ;
    PrintArray(Arr,ArrLength);
    cout<<"\nThe number"<<NumberToCheck <<"is Repeated "
        <<NumberRepeatCounting(Arr,ArrLength,NumberToCheck)
        <<"Time(s)"<<endl;

}
int main()
{  
    int Arr[100], ArrLength, NumberToCheck;
    
    RedaArray(Arr, ArrLength);
    NumberToCheck=ReadPositiveNumber("Enter a number to Check?");

    DisplayResults(Arr,ArrLength,NumberToCheck);


    
    return 0;
}