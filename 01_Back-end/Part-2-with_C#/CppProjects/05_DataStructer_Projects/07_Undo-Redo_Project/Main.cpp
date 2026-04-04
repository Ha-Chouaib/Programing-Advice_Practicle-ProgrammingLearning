#include<iostream>
#include"clsMyString.h"

using namespace std;

int main()
{
    clsMyString S;
    cout<<"String Value: "<<S.GetStr() <<endl;

    S.SetStr("Chouaib1");
    cout<<"String Value: "<<S.GetStr() <<endl;

    S.SetStr("Chouaib2");
    cout<<"String Value: "<<S.GetStr() <<endl;

    S.SetStr("Chouaib3");
    cout<<"String Value: "<<S.GetStr() <<endl;

    cout<<"\n===========Undo============\n";
    cout<<"Undo (1)"<<endl;
    S.Undo();
    cout<<"String Value: "<<S.GetStr() <<endl;

    cout<<"Undo (2)"<<endl;
    S.Undo();
    cout<<"String Value: "<<S.GetStr() <<endl;

    cout<<"Undo (3)"<<endl;
    S.Undo();
    cout<<"String Value: "<<S.GetStr() <<endl;

    cout<<"\n===========Redo============\n";
    cout<<"Redo (1)"<<endl;
    S.Redo();
    cout<<"String Value: "<<S.GetStr() <<endl;

    cout<<"Redo (2)"<<endl;
    S.Redo();
    cout<<"String Value: "<<S.GetStr() <<endl;

    cout<<"Redo (3)"<<endl;
    S.Redo();
    cout<<"String Value: "<<S.GetStr() <<endl;



    return 0;
}