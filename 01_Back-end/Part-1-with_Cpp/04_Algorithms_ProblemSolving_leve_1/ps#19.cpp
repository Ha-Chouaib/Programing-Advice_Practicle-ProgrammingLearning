#include <iostream>
#include <cmath>
using namespace std;

float RreadDiameter(){

    float Diameter;
    
    cout<<"Please enter the circle Diameter: ";
    cin>>Diameter;
    return Diameter;
}

float CircleAreaByDiameter(float Diameter){

    const float PI= 3.14;
    float Area= (pow(Diameter,2) * PI )/4;
    
    return Area;
}

void ShowResult(float Area){

    cout<<"Circle Area= "<<Area <<endl;
}
int main(){

    ShowResult(CircleAreaByDiameter(RreadDiameter()));
    return 0;
}