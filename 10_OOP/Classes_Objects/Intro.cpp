#include<iostream>
#include<string>
using namespace std;


class clsStudent
{
private: // here by default in the class all varialbles and methodes are private (Hidden) well not be showen outside of the class
        // And even You add [private:] ore not it still be Hidden 
    short pass=123; 
    string Key="gf-ky3223k-xkjhgk";

public: // until you add [public] all methods and variable bellow it well appear outside class as the same as struct.
    string FirstName="";
    string LastName=""; //Data Member
    short Age=0;
    string StudentInfo()//Method Member
    {
        return FirstName + " " +LastName+ " Age: " + to_string(Age);
    }
};



int main()
{   
    clsStudent Student1; // [clsStudent]-->(Class) / [Student1]-->(Object)

    Student1.FirstName="Chouaib";
    Student1.LastName="Hadadi";
    Student1.Age=22;

    cout<< Student1.StudentInfo() <<endl;

    return 0;
}