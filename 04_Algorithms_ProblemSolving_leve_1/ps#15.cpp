#include <iostream>
using namespace std;

void ReadNumbers(float height, float width){

    cout<<"Enter the Height of the Rectangle: ";
    cin>>height;

    cout<<"Enter the width: ";
    cin>> width;

}

float CalculatRectahleArea(float Height, float Width){
    return Height * Width;
}


void DisplayResults(float Area){

    cout<<"The Rectangle Area is: "<<Area <<endl;
}
int main(){
    float Height, Width;
    ReadNumbers(Height, Width);
    DisplayResults(CalculatRectahleArea(Height, Width));

    return 0;
}