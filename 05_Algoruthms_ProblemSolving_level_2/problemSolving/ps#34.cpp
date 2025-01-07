#include <iostream>
#include <cstdlib>
using namespace std;

//write a program search for a specific number int a random array and return its position and the order of that number

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

short FindNumberPositionInArray(int arr[100],int arrLength,int  NumberToSearch)
{   
    cout<<"\nYou'r Looking for the Number: "<<NumberToSearch;
    for(int i=0; i< arrLength; i++)
    {
        if(arr[i]== NumberToSearch)
            return i;
        
    }
    return -1;
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

    int arr[100],arrLength, NumberToSearch;

    arrLength =ReadPositiveNumber("enter elements Number: ");
    FillArryWithRandomNumber(arr, arrLength);

    cout<<"\nArray elements: \n";
    PrintArray(arr, arrLength);

    NumberToSearch= ReadPositiveNumber("please enter a number to search for?");
    int NumberPosition;
    NumberPosition= FindNumberPositionInArray(arr,arrLength,NumberToSearch);

    if(NumberPosition == -1)
    {
        cout<<"\nThe Number you'r Looking for Not Found :-(\n";
        
    }else{
        cout<<"\nThe Number found in position "<< NumberPosition <<endl;
        cout<<"Number Order is: "<< NumberPosition+1 <<endl;
    }
    

    return 0;
}