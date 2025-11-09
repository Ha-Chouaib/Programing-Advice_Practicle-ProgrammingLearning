#include <iostream>
#include <cstdlib>
using namespace std;

// write a program that copy a random array in the reverce order.
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

void CopyArrayInReverseOrder(int SourcArr[100],int DestinationArray[100],int arrLength)
{   
    for(int i=0; i< arrLength; i++)
    {
        DestinationArray[i]=SourcArr[ arrLength -1 -i];
       
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

    int arr1[100] ;
    int arrLength=ReadPositiveNumber("Enter array range?");

    FillArryWithRandomNumber(arr1,arrLength);

    cout<<"\nOriginal array Array: \n";
    PrintArray(arr1, arrLength);

    int arr2[100];
    CopyArrayInReverseOrder(arr1,arr2,arrLength);

    cout<<"\nArray after revercing elements: \n";
    PrintArray(arr2, arrLength);



    return 0;
}
