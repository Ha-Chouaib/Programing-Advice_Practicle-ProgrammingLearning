#include <iostream>
#include <cstdlib>
using namespace std;

//Copy the array in another way.

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
void AddArrayElements(int Number, int arr[100],int& arrLength)
{   
    arrLength++;
    arr[arrLength -1]= Number;
}

void CopyArrayUsingAddArrayElement(int OriginalArr[100],int CopyArr[100] ,int arr1Length, int& arr2Length)
{
    for(int i=0; i<arr1Length; i++)
    {
        AddArrayElements(OriginalArr[i],CopyArr,arr2Length);
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
    
    int arr1[100], arr2[100], arr1Length=0, arr2Length=0;

    arr1Length= ReadPositiveNumber("Enter element Number?");
    FillArryWithRandomNumber(arr1,arr1Length);

    CopyArrayUsingAddArrayElement(arr1,arr2, arr1Length,arr2Length);

    cout<<"\nOriginal Array: ";
    PrintArray(arr1, arr1Length);

    cout<<"The Copy Array: ";
    PrintArray(arr2, arr2Length);

    return 0;
}