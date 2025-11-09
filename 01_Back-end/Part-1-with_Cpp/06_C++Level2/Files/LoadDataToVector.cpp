#include <iostream>
#include<vector>
#include<fstream>
#include<string>

using namespace std;

void LoadDataFromFileToVector(string FileName, vector <string> &vFileContent)
{
    fstream Myfile;
    Myfile.open(FileName, ios::in);//Read Mode.

    if(Myfile.is_open())
    {
        string line;

        while(getline(Myfile, line))
        {
            vFileContent.push_back(line);
        }
        Myfile.close();
    }
}

int main()
{   vector <string> vFileContent;

    LoadDataFromFileToVector("MyFile.txt", vFileContent);

    for(string &line : vFileContent)
    {
        cout<< line <<endl;
    }

    return 0;
}