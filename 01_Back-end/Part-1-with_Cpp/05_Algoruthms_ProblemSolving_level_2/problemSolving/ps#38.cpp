#include <iostream>
#include <cstdlib>
#include <cmath>
using namespace std;

//write a program copy just Odd number from a radom array. 

enum enOddOrEven{Odd=1, Even=2};


float ReadPositiveNumber(string MSG=""){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

enOddOrEven IsOddNumber(short Number){

    if(Number % 2 ==0)
        return enOddOrEven::Even;
    else
        return enOddOrEven::Odd;
    
}

int RandomNumber(int From, int To)
{
    int RandNum=rand() % (To -From +1)+From;
    return RandNum;
}

void AddArrayElements(int Number, int arr[100],int& arrLength)
{   
    arrLength++;
    arr[arrLength -1]= Number;
}

void FillArryWithRandomNumber(int arr[100], int arrLength)
{   
    for(int i=0; i<arrLength; i++ )
    {
        arr[i]=RandomNumber(1,100);
    }

}

void CopyOddNumbers(int SourceArray[100], int CopyArray[100], int SouArrLength,int& CopArrLength)
{
    for(int i=0; i< SouArrLength; i++)
    {
        if(IsOddNumber(SourceArray[i])== enOddOrEven::Odd)
            AddArrayElements(SourceArray[i],CopyArray, CopArrLength);
    }

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

    int arr1[100],arr2[100], arr1Length=0, arr2Length=0;

    arr1Length= ReadPositiveNumber("Enter element number");
    FillArryWithRandomNumber(arr1,arr1Length);

    CopyOddNumbers(arr1, arr2, arr1Length, arr2Length);

    cout<<"\nThe Original Array: ";
    PrintArray(arr1, arr1Length);

    cout<<"\nArray[2] Odd numbers: ";
    PrintArray(arr2, arr2Length);


    return 0;
}