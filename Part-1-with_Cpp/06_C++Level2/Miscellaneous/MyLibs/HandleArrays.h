#pragma once
#include <iostream>
#include "GetRandom.h"
#include "HandlNumbers.h"
#include "ReadInput.h"

using namespace std;
using namespace GetRandom;
using namespace HandlNum;
using namespace ReadInput;

namespace HandleArrays
{
void FillArryWithRandomNumber(int arr[100], int& arrLength)
{   
    cout<<"Enter element number:";
    cin>>arrLength;

    for(int i=0; i<arrLength; i++ )
    {
        arr[i]=RandomNumber(1,100);
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
int RepeatCounting(int Arr[100], int ArrLength, int NumberToChek)
{
    int counter=0;
    for(int i=0; i<ArrLength; i++)
    {
        if(Arr[i]== NumberToChek)
            counter++;
    }
    return counter;
}
int ReturnMaxNumberInArray(int arr[100], int arrLength)
{   
    int MaxNum=0;
    for(int i=0; i<arrLength; i++)
    {   
        if(arr[i]>= MaxNum)
        {
            MaxNum=arr[i];

        }

    }
    return MaxNum;
}

int ReturnMinNumberInArray(int arr[100], int arrLength)
{   
    int MinNum=0;
    MinNum=arr[0];
    for(int i=0; i<arrLength; i++)
    {   
        if(arr[i] <= MinNum)
        {
            MinNum=arr[i];

        }

    }
    return MinNum;
}
int SumOfArray(int arr[100], int arrLength)
{
    int arrSum=0;
    for(int i=0; i<arrLength; i++)
    {
        arrSum+= arr[i];
    }

    return arrSum;
}
float AverageArray(int arr[100], int arrLength)
{
    return (float) SumOfArray(arr,arrLength)/ arrLength;
}



void SumOfTowArrays(int arr1[100], int arr2[100], int SumArrays[100], int arrLength)
{
    for(int i=0; i< arrLength; i++)
    {
        SumArrays[i]= arr1[i] + arr2[i];
    }

}
void ShuffleArray(int arr[100], int arrLength)
{   int temp;
    for(int i=0; i<arrLength; i++)
    {   
        SwapNumbers(arr[RandomNumber(1,arrLength)-1], arr[RandomNumber(1, arrLength)-1]);
    }

}

short FindNumberPositionInArray(int arr[100],int arrLength,int  NumberToSearch)
{   
    cout<<"\nYou'r Looking for the Number: "<<NumberToSearch;
    for(int i=0; i< arrLength; i++)
    {
        if(arr[i]== NumberToSearch)
            return i;
        
    }
    return -1;
}

bool IsNumberInArray(int arr[100],int arrLength,int  NumberToSearch)
{   
    return FindNumberPositionInArray(arr,arrLength,NumberToSearch) != -1;
}

void AddArrayElements(int Number, int arr[100],int& arrLength)
{   
    arrLength++;
    arr[arrLength -1]= Number;
}
void AddUserNumbersInArray(int arr[100], int& arrLength)
{   
    bool AddMore= true;
    do
    {   AddArrayElements(ReadNumber("Please enter a number"),arr,arrLength);
        cout<< "Do you wanna add More Numbers?\n"
            <<"Enter: [1]-->Yes || [0]-->No"<<endl;
        cin>>AddMore;

    }while(AddMore);
}
void CopyArrayUsingAddArrayElement(int OriginalArr[100],int CopyArr[100] ,int arr1Length, int& arr2Length)
{
    for(int i=0; i<arr1Length; i++)
    {
        AddArrayElements(OriginalArr[i],CopyArr,arr2Length);
    }

}
void CopyDistinctNumbersToArray(int arr[100], int DistArr[100], int arrLength, int& DistArrLength)
{
    for(int i=0; i<arrLength; i++)
    {
        if(!IsNumberInArray(DistArr,arrLength, arr[i]))
        {
            AddArrayElements(arr[i], DistArr, DistArrLength);
        }
    }

}

bool IsBalindromArray(int SourceArr[100],int arrLength)
{
    
   for(int i=0; i<arrLength; i++)
   {
        if(SourceArr[i] != SourceArr[arrLength -1 -i])
            return 0;
   }
   return 1;
}

}