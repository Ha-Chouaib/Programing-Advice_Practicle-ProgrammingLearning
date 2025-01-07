#include <iostream>
using namespace std;

enum enPassFail{Pass=1, Fail=0};

struct stMarksInfo{

    int mark[100];
    float Result=0;
    short ShouldStopIn;

};

stMarksInfo ReadMarks()
{
    stMarksInfo Marks;
    cout<<"Enter:[111] to stop."<<endl;
    short counter=0;
    while(counter < 100){
        cout<<"Add the Mark: ";
        cin>>Marks.mark[counter];

        if(Marks.mark[counter]== 111){
            Marks.ShouldStopIn = counter;
            break;
        }
        counter++;
    }
    return Marks;
}

float SumOfMarks(stMarksInfo Marks)
{

    for(int i=0; i<Marks.ShouldStopIn; i++){

        Marks.Result+= Marks.mark[i];
    }

    return Marks.Result;
}

float MarksAverage(stMarksInfo Marks)
 {
    return SumOfMarks(Marks) / Marks.ShouldStopIn; 
 }

bool IsPassAVG(float MarksAVG){

    if(MarksAVG >= 50)
        return enPassFail::Pass;
    else
        return enPassFail::Fail;
}

void DisplayResults(float MarksAVG){

    cout<<"The Average is: "<< MarksAVG<<endl;

    if(IsPassAVG(MarksAVG)){
        cout<<"\nPass"<<endl;
    }
    else
        cout<<"\nFail"<<endl;

}

int main(){
DisplayResults(MarksAverage(ReadMarks()));

    return 0;
}