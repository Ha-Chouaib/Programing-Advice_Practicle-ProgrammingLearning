#include<iostream>
#include<vector>
#include<string>
#include<fstream>

using namespace std;

void SaveVectorToFile(string fileName, vector<string> &vFileContent )
{
    fstream Myfile;
    Myfile.open(fileName, ios::out);
    if(Myfile.is_open())
    {
        for(string &line : vFileContent)
        {   if(line != "")
                Myfile<< line <<endl;
        }
        Myfile.close();
    }
}

int main()
{
    vector <string> vfilecontent={"chouaib","Ahmad","Momo","kamal"};

    SaveVectorToFile("MyFile.txt", vfilecontent);

    return 0;
}