#include <iostream>
#include <limits>
using namespace std;

int ReadNumber()
{
    int number=0;
    cout<<"Enter a number: ";
    cin>> number;

    while (cin.fail())// mains that cin got the wrong answer string instead of number
    {
        cin.clear();
        cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');// be sure you include <limits> lib.

        cout<<"Wrong answer Please enter a number!"<<endl;
        cin>>number;
    }
    return number;
    
}

int main()
{
    cout<<"The number is: "<<ReadNumber() <<endl;
    return 0;
}