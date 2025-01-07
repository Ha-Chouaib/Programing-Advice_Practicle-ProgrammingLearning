#include <iostream>
#include <cmath>
using namespace std;

void ReadTriangleInfo(float& Side, float& Base){

    cout<<"please enter Triangle Side: ";
    cin>>Side;

    cout<<"enter Triangle Base: ";
    cin>>Base;

}

float CircleAreaByIsoTraingle(float Side, float Base){

    const float PI=3.14;
    float Area= PI * (pow(Base,2) / 4) * ((2*Side - Base)/ (2*Side + Base));
    return Area;
}

void DisplayResult(float Area){
    cout<<"circle Area is: "<<Area <<endl;
}

int main(){

    float Side, Base;
    ReadTriangleInfo(Side, Base);
    DisplayResult(CircleAreaByIsoTraingle(Side,Base));
    
    return 0;
}