#include <iostream>
#include <cstdlib>
using namespace std;

//write a program searche for a specific number is it in the random array or not. 

float ReadPositiveNumber(string MSG="")
{
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

bool IsNumberInArray(int arr[100],int arrLength,int  NumberToSearch)
{   
    return FindNumberPositionInArray(arr,arrLength,NumberToSearch) != -1;
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
    

    if(IsNumberInArray(arr, arrLength, NumberToSearch))
    {
        cout<<"\nYes The Number you'r Looking for is Founded :-)\n";
        
    }else{
        cout<<"\nThe Number you'r Looking for Not Found :-(\n";
    }
    

    return 0;
}