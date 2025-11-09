#include <iostream>
#include <cstdlib>
using namespace std;

//write a program that can sum betwenn 2 random arrays elements.and Add the result to another array

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
        arr[i]=RandomNumber(1,100);
    }

}

void SumOfTowArrays(int arr1[100], int arr2[100], int SumArrays[100], int arrLength)
{
    for(int i=0; i< arrLength; i++)
    {
        SumArrays[i]= arr1[i] + arr2[i];
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
{   
    srand((unsigned)time(NULL));
    int arr1[100], arr2[100],SumArrays[100], arrLength;

    arrLength= ReadPositiveNumber("Enter Element number?");
    FillArryWithRandomNumber(arr1, arrLength);
    FillArryWithRandomNumber(arr2, arrLength);
    SumOfTowArrays(arr1,arr2,SumArrays,arrLength);

    cout<<"\nArray [1]: \n";
    PrintArray(arr1,arrLength);

    cout<<"\nArray [2]: \n";
    PrintArray(arr2, arrLength);

    cout<<"\nSum of Array[1] + Array[2] = \n";
    PrintArray(SumArrays,arrLength);


    return 0;
}

