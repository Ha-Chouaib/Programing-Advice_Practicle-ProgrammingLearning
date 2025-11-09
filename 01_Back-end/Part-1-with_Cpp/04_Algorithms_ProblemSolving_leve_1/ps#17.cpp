#include <iostream>
#include <cmath>
using namespace std;

void ReadNumbers(float& Base, float& Height){

    cout<<"please enter the traingle Base: ";
    cin>> Base;

    cout<<"please enter the triangle Height: ";
    cin>>Height;
}

float TriangleArea(float Base, float Height){

    float Area= (Base/2)* Height;
    return Area;
}

void PrintResult(float Area){

    cout<<"\nTriangle Area is: "<<Area <<endl;
}
int main(){
    float Base, Height;
    ReadNumbers(Base, Height);
    PrintResult(TriangleArea(Base, Height));

    return 0;
}