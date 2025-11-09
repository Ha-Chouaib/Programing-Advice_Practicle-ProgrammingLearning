#include <iostream>
#include <cstdlib>
using namespace std;

//write a program counting Positive numbers from random array.

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
    int RandNum=rand() % (To -From +1)+From;
    return RandNum;
}

void FillArryWithRandomNumber(int arr[100], int arrLength)
{   
    for(int i=0; i<arrLength; i++ )
    {
        arr[i]=RandomNumber(-100,100);
    }

}


int PositiveNumbersCountingInArray(int arr[100],int  arrLength)
{   int Count=0;
    for(int i=0; i < arrLength; i++)
    {
        if(arr[i] >= 0)
            Count++;
    }
    return Count;
}

void PrintArray(int arr[100],int arrLength)
{
    for(int i=0; i <arrLength; i++)
    {
        cout<< arr[i] <<" ";
    }
    cout<<"\n";
}


int main()
{   srand((unsigned)time(NULL));

    int arr[100], arrLength=0;

    arrLength=ReadPositiveNumber("Enter a positive number");
    FillArryWithRandomNumber(arr, arrLength);


    cout<<"\nArray Content: ";
    PrintArray(arr, arrLength);

    cout<<"\nPositive Numbers Count: " << PositiveNumbersCountingInArray(arr,arrLength) <<endl;

    return 0;
}