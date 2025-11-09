#include <iostream>
#include <cmath>
using namespace std;

float ReadSideSquare(){
    float SideSqr= 0;
    cout<<"please enter Side Square: ";
    cin>>SideSqr;

    return SideSqr;
}

float CircleAreainscribrInSquare(float SideSqr){

    const float PI= 3.14;
    float Area= (PI * pow(SideSqr,2))/4;
    return Area;
}

void ShowResult(float Area){
    cout<<"Circle Area is: "<<Area <<endl;
}

int main(){

    ShowResult(CircleAreainscribrInSquare(ReadSideSquare()));
    return 0;
}