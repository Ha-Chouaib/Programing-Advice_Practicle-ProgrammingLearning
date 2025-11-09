#include <iostream>
#include <cmath>
using namespace std;

float ReadRadiuos(){
    float Radious= 0;
    cout<<"please enter the Circle Radious: ";
    cin>>Radious;
    
    return Radious;
}

float CircleArea(float Radious){
    const float PI= 3.14;
    float Area = pow(Radious,2) *PI;
    return Area;
}

void PrintResult(float Area){
    cout<<"T\nhe Circle Area is: "<<Area<<endl;
}
int main(){

    PrintResult(CircleArea(ReadRadiuos()));
    return 0;
}