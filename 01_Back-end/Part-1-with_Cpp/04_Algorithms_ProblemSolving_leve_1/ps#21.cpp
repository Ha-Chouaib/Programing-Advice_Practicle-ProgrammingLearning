#include <iostream>
#include <cmath>
using namespace std;

float ReadCircumference(){

    float CFC;
    cout<<" please enter Circle Circumference: ";
    cin>> CFC;

    return CFC;
}

float CircleAreaByCircumference(float CFC){

    const float PI=3.14;
    float Area = pow(CFC,2)/ (4 * PI );
    return Area;
}

void DisplayResult(float Area){
    cout<<"Circle Area is: "<<Area <<endl;
}

int main(){

    DisplayResult(CircleAreaByCircumference(ReadCircumference()));
    return 0;
}