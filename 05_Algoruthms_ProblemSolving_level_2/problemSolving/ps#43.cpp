#include <iostream>
#include <cstdlib>
using namespace std;

//write a program counting Even numbers from a radom array.

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


int EvenNumbersCountingInArray(int arr[100],int  arrLength)
{   int EvenCount=0;
    for(int i=0; i < arrLength; i++)
    {
        if(arr[i] %2 == 0)
            EvenCount++;
    }
    return EvenCount;
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

    int arr[100], arrLength=0;

    arrLength=ReadPositiveNumber("Enter a positive number");
    FillArryWithRandomNumber(arr, arrLength);


    cout<<"\nArray Content: ";
    PrintArray(arr, arrLength);

    cout<<"\nEven Numbers Count: " << EvenNumbersCountingInArray(arr,arrLength) <<endl;

    return 0;
}