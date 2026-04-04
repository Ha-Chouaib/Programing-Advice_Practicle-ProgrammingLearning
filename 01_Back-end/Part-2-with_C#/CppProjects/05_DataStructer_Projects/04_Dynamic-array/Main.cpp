#include<iostream>
#include"clsDynamicArray.h"

using namespace std;

int main()
{


    clsDynamicArray <short>arr(6);
    arr.SetItem(0,1);
    arr.SetItem(1,2);
    arr.SetItem(2,3);
    arr.SetItem(3,4);
    arr.SetItem(4,5);
    arr.SetItem(5,6);

    arr.IsEmpty()?cout<<"\nThe array is Empty"<<endl :cout<< "The array Not empty"<<endl;
    cout<<"Array Size is: "<<arr.Size()<<endl;

    arr.print();
    
    cout<<endl;
    cout<<"\nResizing By 10\n";
    arr.Resize(10);
    cout<<"Array Size is: "<<arr.Size()<<endl;
    arr.print();
    
    cout<<endl;
    cout<<"Get Item (3): "<<arr.GetItem(3)<<endl;
    
    cout<<endl;
    cout<<"Reverce Array"<<endl;
    arr.Reverse();
    arr.print();
    
    cout<<endl;
    cout<<"Find Item Index By Value (4)"<<endl;
    int Index=arr.Find(4) ;
    Index== -1? cout<<"Item Not Found"<<endl : cout<< "Index: "<<Index <<endl;
    
    cout<<endl;
    cout<<"Delete Item By Value (6)"<<endl;
    arr.DeleteItem(6);
    arr.print();
    
    cout<<endl;
    cout<<"Insert 200 At Beginning"<<endl;
    arr.InsertAtBeginning(200);
    arr.print();
    
    cout<<endl;
    cout<<"Insert 600 At End "<<endl;
    arr.InsertAtEnd(600);
    arr.print();
    cout<<endl;
    cout<<"Insert Before Item(3)300"<<endl;
    arr.InsertBefore(3,300);
    arr.print();
    cout<<endl;
    cout<<"Insert After Item(1)100"<<endl;
    arr.InsertAfter(1,100);
    arr.print();
    
    



    return 0;
}