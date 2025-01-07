#include <iostream>
using namespace std;

// # Write a programe that print a multiplacation table from 1 to 10

void TableHeader(){
    cout<<"\n\n--------------------------------Multiplication Table--------------------------------\n"<<endl;
    cout<<"\t";
    for(int i=1;i<=10;i++){
        cout<< i <<"\t";
    }
    cout<<"\n------------------------------------------------------------------------------------"<<endl;
}

string columnSeperator(int i){
    if(i<10)
        return "    |";
    else
        return "   |";
} 
void DisplayMultiplicationTable(){
    TableHeader();
    for(int i=1; i<=10; i++){

        cout<<" "<< i << columnSeperator(i) << "\t";
        for(int y=1; y<=10; y++){
            cout<< i * y <<"\t";
        }
        cout <<endl;
    }
   
}

int main(){
    
    DisplayMultiplicationTable();
    return 0;
}