#include <iostream>
#include <cstdlib>
using namespace std;

//write a program that Sum the random array elements.

int RandomNumber(int From, int To)
{
    int RandNum=rand() % (To -From +1)+From;
    return RandNum;
}

void FillArryWithRandomNumber(int arr[100], int& arrLength)
{   
    cout<<"Enter element number:";
    cin>>arrLength;

    for(int i=0; i<arrLength; i++ )
    {
        arr[i]=RandomNumber(1,100);
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

int SumOfArrayElements(int arr[100], int arrLength)
{
    int arrSum=0;
    for(int i=0; i<arrLength; i++)
    {
        arrSum+= arr[i];
    }

    return arrSum;
}

int main()
{   
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    
    FillArryWithRandomNumber(arr, arrLength);

    cout<<"\nArray Elements: ";
    PrintArray(arr, arrLength);

    cout<<"\nSum of array elements is: "<<SumOfArrayElements(arr,arrLength) <<"\n";


    return 0;
}