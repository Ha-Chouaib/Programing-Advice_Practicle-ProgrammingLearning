#include <iostream>
using namespace std;

//write a program fill an array based on asking the user:
//##To Add a number to the array
//##If want to add More if yes ask to add if No end the program.

int ReadNumber(string MSG="")
{
    int Num=0;
    
        cout<< MSG <<endl;
        cin>> Num;
    
    return Num;
}

void AddArrayElements(int Number, int arr[100],int& arrLength)
{   
    arrLength++;
    arr[arrLength -1]= Number;
}
void AddUserNumbersInArray(int arr[100], int& arrLength)
{   
    bool AddMore= true;
    do
    {   AddArrayElements(ReadNumber("Please enter a number"),arr,arrLength);
        cout<< "Do you wanna add More Numbers?\n"
            <<"Enter: [1]-->Yes || [0]-->No"<<endl;
        cin>>AddMore;

    }while(AddMore);
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
    int arr[100],arrLength=0;

    AddUserNumbersInArray(arr, arrLength);

    cout<<"\nArray Lengtt is: "<< arrLength <<endl;

    cout<<"\nArray Elements: \n";
    PrintArray(arr, arrLength);

    return 0;
}