#include <iostream>
#include <fstream>
using namespace std;



int main()
{

    fstream MyFile;

// write Mode [ios::out] :
//-->if the file not already exist well creat it and write what you want to it.
// --> if it's already existed well remove the olde content and add the new one.

    MyFile.open("MyFile.txt",ios::out); 

    if(MyFile.is_open())// to be sure that the file is opened.
    {
        // add the content by this way.
        MyFile<<"that is the first file manipulation with cpp.\n";
        MyFile<<"My name is chouaib hadadi.\n";
        MyFile<<"I'am 21 years old.\n";
    }
    MyFile.close(); 



    return 0;
}