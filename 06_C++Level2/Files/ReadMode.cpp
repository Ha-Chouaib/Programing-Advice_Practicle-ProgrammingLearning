#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void ReadFilecontent(string FileName)
{
    fstream Myfile;
    Myfile.open(FileName,ios::in);//Read Mode. "JUST Read"

    if(Myfile.is_open())
    {
        string line;
        while(getline(Myfile, line))
        {
            cout<< line <<endl;
        }
        Myfile.close();
    }
}

int main()
{
    ReadFilecontent("MyFile.txt");
    return 0;
}