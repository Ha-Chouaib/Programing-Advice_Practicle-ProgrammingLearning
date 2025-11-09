#include <iostream>
#include <cmath>
using namespace std;

void ReadNumbers(float& Side, float& Diagonal){

    cout<<"please enter the rectengle side: ";
    cin>>Side;

    cout<<"please enter the diagonale: ";
    cin>>Diagonal;

}

float RectangleAreaBySideAndDiagonal(float Side, float Diagonal){

    float Area= Side * sqrt(pow(Diagonal,2) - pow(Side,2));
    return Area; 
}

void DisplayResult(float Area){

    cout<< "The rectangle Area is: "<< Area <<endl;

}

int main(){

    float Side,Diagonal;
    ReadNumbers(Side, Diagonal);
    DisplayResult(RectangleAreaBySideAndDiagonal(Side, Diagonal));


    return 0;
}