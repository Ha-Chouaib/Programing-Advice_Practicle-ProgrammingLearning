#include <iostream>
#include <cstdlib>
using namespace std;

//write a program that Fill an array with random number. and ask the user how many nubers wants in that array.

float ReadPositiveNumber(string MSG=""){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

int RandomNumber(int From, int To)
{
    int RandNum= rand()% (To -From +1) +From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int Arr[100], int& ArrLength)
{
   ArrLength=ReadPositiveNumber("Enter number of element:");
   for(int i=0; i<ArrLength; i++)
   {
        
        Arr[i]= RandomNumber(1,100);
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

int main()
{   srand((unsigned)time(NULL));
    int arr[100],arrLength;

    FillArrayWithRandomNumbers(arr, arrLength);

    cout<<"arry elements: ";
    PrintArray(arr, arrLength) ;
    return 0;
}