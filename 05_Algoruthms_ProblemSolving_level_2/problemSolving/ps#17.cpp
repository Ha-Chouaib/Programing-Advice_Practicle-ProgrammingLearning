#include <iostream>
#include <string>
using namespace std;

//write a program that  Can guess any password with 3 CAP letters.

string ReadString(string MSG){
    string  str="";
    cout<< MSG <<endl;
    getline(cin,str);
    return str;
}

bool FindOutPassWord(string Pass)
{

    cout<<endl;
    string Word="";
    int counter=0;

    for(int i=65; i<=90; i++)
    {

       for(int x=65; x<= 90 ;x++)
       {
            for (int y = 65; y <=90; y++)
            {   
                counter++;

                Word+=char(i);
                Word+=char(x);
                Word+=char(y);

                
                cout<< "Trail["<< counter <<"]: "<< Word <<endl;

                if(Pass == Word){

                    cout<<"\nPassword is: "<<Word <<endl;
                    cout<<"Found after "<<counter <<" Trail(s)"<<endl;
                    return true;
                }

                Word="";
            }
            
       }
    
       cout<<endl;
    }
    
    cout<<"Password not found" <<endl;
    return false;

}
int main(){
    string GetPassword="";
    GetPassword= ReadString("Enter a password in 3 cap letters:");
    FindOutPassWord(GetPassword);  

    return 0;
}