#include <iostream>
using namespace std;

//Fill an array and check if it's a balindrom array or not.

void FillArray(int arr[100], int& arrLength)
{
    arrLength=6;
    arr[0]= 10;
    arr[1]= 20;
    arr[2]= 30;
    arr[3]= 30;
    arr[4]= 20;
    arr[5]= 10;
    
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
void PrintArray(int arr[100],int arrLength)
{
    for(int i=0; i <arrLength; i++)
    {
        cout<< arr[i] <<" ";
    }
    cout<<"\n";
}

int main()
{   int arr[100], arrLength=0;

    FillArray(arr, arrLength);

    IsBalindromArray(arr,arrLength);

    cout<<"Array Element: ";
    PrintArray(arr, arrLength);

    if(IsBalindromArray(arr,arrLength))
        cout<<"\nIts a Balindrom array\n";
    else
        cout<<"\nNot a Balindrom array\n";


    return 0;
}