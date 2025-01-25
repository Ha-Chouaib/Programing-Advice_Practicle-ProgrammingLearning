#include <iostream>
using namespace std;

void SwapByPointer(int *n1, int *n2)
{
    int temp=0;

    temp= *n1;
    *n1 = *n2;
    *n2 =temp;
}


int main()
{
    int num1= 12, num2=11;

    cout <<"Before Swaping\n";
    cout<<"Num1= "<< num1 <<endl;
    cout<<"Num2= "<< num2 <<endl;

    cout<<endl;
    SwapByPointer(&num1,&num2);

    cout<<"After swaping\n";
    cout<<"Num1= "<< num1 <<endl;
    cout<<"Num2= "<< num2 <<endl;

    return 0;


}