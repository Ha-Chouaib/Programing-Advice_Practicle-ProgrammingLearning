#include <iostream>
#include <vector>
using namespace std;

int main()
{   vector <int> vNums;

    vNums.push_back(10);// add element to vector
    vNums.push_back(11);
    vNums.push_back(23);
    vNums.push_back(45);
    vNums.push_back(54);


    cout<<"Vector size: "<<vNums.size()<<endl; // size() it returns how many elements do you have in the vector

    cout<<"The first element: "<<vNums.front()<<endl;// front()--> returns the first element.
    cout<<"The Last element: "<<vNums.back()<<endl;// back()--> returns the Last element.
    cout<<"Capacity: "<<vNums.capacity() <<endl;//capacity()--> reurns overall size of vector [size of all data inside the vector].
    vNums.pop_back();// pop_back() Removes vector elements one by one
    vNums.pop_back();
    vNums.pop_back();
    vNums.pop_back();
    vNums.pop_back();

    if(!vNums.empty())// empty() returns true if the vector is empty and false if is full
        vNums.pop_back();

    cout<<"Vector size: "<<vNums.size()<<endl; 
    return 0;
}