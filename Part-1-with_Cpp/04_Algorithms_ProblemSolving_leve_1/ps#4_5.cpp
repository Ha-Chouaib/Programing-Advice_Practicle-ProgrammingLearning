#include <iostream>
#include <string>
using namespace std;

struct stInfo
{
    short Age;
    bool HasDrivingLecense;
    bool HasRecommondation;
};

stInfo ReadInfo()
{

    stInfo Info;
    cout<< "please enter your Age: ";
    cin>> Info.Age;

    cout<<"Do you  have a Driving Lecense [you have enter: 1\\ you don't: 0]"<<endl;
    cin>> Info.HasDrivingLecense;
    cout<<"Do you  have a Recommondation [you have enter: 1\\ you don't: 0]"<<endl;
    cin>>Info.HasRecommondation;
    return Info;
}

bool IsAccepted(stInfo Info)
{
    if(Info.HasRecommondation){
        return true;
    }
    else{
        return (Info.Age > 21 && Info.HasDrivingLecense);
    }
}

void ShowResult(stInfo Info)
{

    if(IsAccepted( Info))
        cout<<"\n Hired "<<endl;
    else
        cout<<"\n Rejected"<<endl;
}

int main()
{
    ShowResult(ReadInfo());

    return 0;
}