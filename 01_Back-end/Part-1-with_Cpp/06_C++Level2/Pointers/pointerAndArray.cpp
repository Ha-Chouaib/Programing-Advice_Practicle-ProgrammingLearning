#include <iostream>
using namespace std;

int main()
{   int arr[4]={10,20,30,40};
    int *p;
    p= arr;

    cout<<"address of arr[0]-->(p)--> "<< p <<endl;
    cout<<"address of arr[1]-->(p+1)--> "<< p+1<<endl;
    cout<<"address of arr[2]-->(p+2)--> "<< p+2<<endl;
    cout<<"address of arr[3]-->(p+3)--> "<< p+3 <<endl;
    cout<<endl;
    cout<<endl;
    cout<<"Array elements value: \n";
    for(int i=0; i<4; i++)
    {
        cout<< "Value of arr["<< i <<"]-->"<< p+i <<endl;
    }

    return 0;
}