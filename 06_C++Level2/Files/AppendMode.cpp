#include <iostream>
#include <fstream>
using namespace std;


int main()
{
    fstream Myfile;

    //-->[ios::out->(take sure if the file is already exist if not creat it) | ios::app->(Add new content without removing the old one)].
    // you can use just [ios::app] to append but it's better to combine [ios::out] with it.

    Myfile.open("MyFile.txt", ios::out | ios::app);// Append Mode.

    if(Myfile.is_open())
    {

        Myfile<<"It's a new line ...\n";
    }
    Myfile.close();
    
    return 0;

}   


    