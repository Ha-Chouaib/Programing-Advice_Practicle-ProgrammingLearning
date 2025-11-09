#include <iostream>
#include <cstdlib>
using namespace std;

//write program print the max number in the array.

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
int main()
{   srand((unsigned)time(NULL));

    int arr[100],arrLength;

    FillArryWithRandomNumber(arr, arrLength);

    cout<<"Array elements: ";
    PrintArray(arr, arrLength);

    cout<<"The Maximum element: " << ReturnMaxNumberInArray(arr,arrLength) <<endl;
    


    return 0;
}
