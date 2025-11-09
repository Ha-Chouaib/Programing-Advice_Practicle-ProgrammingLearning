#include<iostream>
using namespace std;

class clsPerson
{
public:
    clsPerson()
    {
        cout<<"Constructor Field"<<endl;
    }


    //the Destructor is the oposite of constructor .
    // its the Last Method that execute on the class and the last to be Destroyed when the class life is end.
    //we can use it when we want to add some thing or actions when the class life is end or destroyed

    ~clsPerson()
    {
        cout<<"Desstructor Field"<<endl;
    }
    

};

void Func1()
{
    cout<< "\nIn Function 1"<<endl;
    clsPerson P1;

}

void Func2()
{
    cout<<"\nIn Function 2"<<endl;
    clsPerson * P2= new clsPerson;
    delete P2; // When You Use Pionters with New its realy necessaryto ad Delete ...(Pointer name)
    //BKZ the rubish othe old data wwll not removed from thr memory when the function or class life is end.
}

int main()
{
    Func1(); //when the fuction is end all its members well be destroyed and the class ends with destructor methode member.
    Func2();//Here I take The P1 Values in the run time by pointer using "new" and without delete the destctore int *P2 well not be executed.

    return 0;
}