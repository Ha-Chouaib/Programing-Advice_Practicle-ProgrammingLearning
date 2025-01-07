#include <iostream>
#include <cstdlib>
#include <cmath>
using namespace std;

//Fill an array with random numbers  and copy just the prime nubers from the array.

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
bool IsPrime(int Num){

    int HalfNum= round(Num/2);
   
    for(int i=2; i<=HalfNum; i++){

        if(Num % i == 0)
            return 0;
    }

    return 1;
}

void CopyPrimeNumInArray(int OriginalArr[100],int CopyArr[100] ,int arrLength, int& CopyArrLen)
{   
    int count=0;
    for(int i=0; i<arrLength; i++)
    {
        if(IsPrime(OriginalArr[i]))
        {
            CopyArr[count]= OriginalArr[i];
            count++;
        }
              
    }
    CopyArrLen= --count;
}

void PrintArray(int arr[100],int arrLength )
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
    int arr[100],CopyArr[100],arrLength, CopyarrLength=0;

    FillArryWithRandomNumber(arr, arrLength);
    CopyPrimeNumInArray(arr,CopyArr,arrLength, CopyarrLength);

    cout<<"The Original Array is: ";
    PrintArray(arr, arrLength);


    cout<<"The Copy Array is: ";
    PrintArray(CopyArr,CopyarrLength);

    return 0;
}