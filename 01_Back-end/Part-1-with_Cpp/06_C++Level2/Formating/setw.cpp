#include <iostream>
#include <iomanip> //important to use setw referse to (set width manipulator).spacing manipulation.

using namespace std;


int main()
{   
    cout<<"|-----------|---------------------------------------------|------------|"<<endl;
    cout<<"|    Code   |                  Name                       |    Mark    |"<<endl;
    cout<<"|-----------|---------------------------------------------|------------|"<<endl;

    cout<<"|"<<setw(11)<<"c102"  <<"|" <<setw(45)<<"introduction to Programing"<<"|" <<setw(12)<<"90" <<"|"<<endl;
    cout<<"|"<<setw(11)<<"c134"  <<"|" <<setw(45)<<"Networking"                <<"|" <<setw(12)<<"70" <<"|"<<endl;
    cout<<"|"<<setw(11)<<"c1123" <<"|" <<setw(45)<<"Operating system"          <<"|" <<setw(12)<<"901"<<"|"<<endl;
    cout<<"|"<<setw(11)<<"c2310" <<"|" <<setw(45)<<"Linux"                     <<"|" <<setw(12)<<"10" <<"|"<<endl;
    cout<<"|-----------|---------------------------------------------|------------|"<<endl;
    return 0;
}
