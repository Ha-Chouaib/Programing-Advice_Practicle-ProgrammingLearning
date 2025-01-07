#include <iostream>
#include <cstdlib>
using namespace std;

//write a program that shufll an ordered array.

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

void FillArrayInOrder(int arr[100],int arrLength)
{
    for(int i=0; i< arrLength; i++)
    {
        arr[i]= i+1;
    }
}

void SwapNumbers(int& num1, int& num2){

    short Temp;
    
    Temp= num1;
    num1= num2;
    num2= Temp;
}


void ShuffleArray(int arr[100], int arrLength)
{   int temp;
    for(int i=0; i<arrLength; i++)
    {   
        SwapNumbers(arr[RandomNumber(1,arrLength)-1], arr[RandomNumber(1, arrLength)-1]);
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

    int arr[100] ;
    int arrLength=ReadPositiveNumber("Enter array range?");

    FillArrayInOrder(arr,arrLength);

    cout<<"Array Befor shuffle: ";
    PrintArray(arr, arrLength);

    ShuffleArray(arr,arrLength);

    cout<<"Array after shuffle: ";
    PrintArray(arr, arrLength);



    return 0;
}
