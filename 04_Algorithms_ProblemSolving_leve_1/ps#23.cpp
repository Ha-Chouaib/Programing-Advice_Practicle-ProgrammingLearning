#include <iostream>
#include <cmath>
using namespace std;

void ReadTriangleData(float& A, float& B, float& C){

    cout<<"enter triangle side A: ";
    cin>>A;

    cout<<"enter triangle base B: ";
    cin>>B;

    cout<<"enter Triangle side C: ";
    cin>>C;
}

float CircleAreaByArbTriangle(float SideA, float BaseB, float SideC){

    const float PI= 3.14;
    float P= (SideA + BaseB + SideC)/2;
    float T= (SideA * BaseB * SideC) /(4 * sqrt(P * (P - SideA)*(P -BaseB)*(P - SideC)));
    float Area= PI * pow(T,2);

    return Area;
}

void DisplayResult(float Area){
    cout<<"circle Area is: "<<Area <<endl;
}
int main(){
    float SideA, BaseB, SideC;
    ReadTriangleData(SideA, BaseB, SideC);
    DisplayResult(CircleAreaByArbTriangle(SideA, BaseB, SideC));
    
    return 0;
}