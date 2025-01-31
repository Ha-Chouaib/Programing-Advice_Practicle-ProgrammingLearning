#include<iostream>
using namespace std;


class clsPerson
{

public:

    void print()// without "virtual" the Overriding will not be effective 
    {
        cout<<"<<print>> In Person Field."<<endl;
    }
    
    virtual void Display()// With << virtual >> When the Heirs Overriding this function and we do Upcasting the function will be overrided
    {
        //The compiler it Creat a virtuel Table in Memory to Manage the Conflicts of Function Overriding <<To Insure That Each cls execute its on Function Not base class one >>
        // And This Table Makes a Lettel bit The Program Slow .
        cout<<"<<[Virtual] Display >> In Person Field"<<endl;
    }

};
class clsEmployee :public clsPerson
{

public:

    void print()
    {
        cout<<"<<print>> In Employee Field."<<endl;
    }
    void Display()
    {
        cout<<"<< Display >> In Employee Field"<<endl;
    }

};
class clsStudent :public clsPerson
{

public:

    void print()
    {
        cout<<"<<print>> In Student Field."<<endl;
    }
    void Display()
    {
        cout<<"<< Display >> In Student Field"<<endl;
    }

};



int main()
{

    clsPerson P1;
    clsEmployee E1;
    clsStudent S1;
    
    cout<<"Without Upcasting Normal Invoking\n"<<endl;
    //Early-Static Binding  the combiler knows the location of a Member or any at Building time before Run time "Early".
    P1.print();
    P1.Display(); //Virtual Function
    cout<<endl;
    //Early-Static Binding  the combiler knows the location of a Member or any at Building time before Run time "Early".
    E1.print();
    E1.Display();
    cout<<endl;
    //Early-Static Binding  the combiler knows the location of a Member or any at Building time before Run time "Early".
    S1.print();
    S1.Display();

    cout<< endl <<endl;

    clsPerson * P2;
    cout<<"\nWith UpCasting\n"<<endl;

    cout<<"Employee cls\n";
    P2=&E1;
    //Late-Dynamic Binding The Compiler Knows The Location Of a Method Or Member at Run time After Building time "Late". 
    P2->print();
    P2->Display();
    cout<<endl;

    cout<<"Student cls" <<endl;
    P2=&S1;
    //Late-Dynamic Binding The Compiler Knows The Location Of a Method Or Member at Run time After Building time "Late". 
    P2->print();
    P2->Display();
    cout<<endl;

    


    return 0;
}