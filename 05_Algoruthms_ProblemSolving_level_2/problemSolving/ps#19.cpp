#include <iostream>
#include <cstdlib>
using namespace std;

//write a program can return a random number in a specific range.

int RandomNumber(int From, int To)
{ 
    int RandNum= rand()% (To -From +1) +From;
    return RandNum;
}



int main(){
    srand((unsigned)time(NULL)); // without this rand will not work

    cout<< RandomNumber(2,8) <<endl;
    cout<< RandomNumber(1,5) <<endl;
    cout<< RandomNumber(50,100) <<endl;
    
    return 0; 
}