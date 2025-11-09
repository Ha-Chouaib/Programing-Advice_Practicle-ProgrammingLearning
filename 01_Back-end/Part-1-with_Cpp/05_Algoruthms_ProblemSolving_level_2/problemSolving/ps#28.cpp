#include <iostream>
#include <cstdlib>
using namespace std;
// write a program that Make a copy of a random array.
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

void CopyArray(int OriginalArr[100],int CopyArr[100] ,int arrLength)
{
    for(int i=0; i<arrLength; i++)
    {
        CopyArr[i]=OriginalArr[i];
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
    int arr[100],CopyArr[100],arrLength;

    FillArryWithRandomNumber(arr, arrLength);
    CopyArray(arr,CopyArr,arrLength);

    cout<<"The Original Array is: ";
    PrintArray(arr, arrLength);


    cout<<"The Copy Array is: ";
    PrintArray(CopyArr,arrLength);

    return 0;
}