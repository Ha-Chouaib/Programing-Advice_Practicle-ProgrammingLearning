#include<iostream>
using namespace std;


class clsPerson
{
private:
int _ID=92827;

public:

    int ID()//Get Property only We Should not Add a Set One "In READ Only Mode"
    {
        return _ID;
    }
};

int main()
{
    clsPerson P1;
    cout<<"ID = "<< P1.ID() <<endl;
    
    return 0;
}

