#include <iostream>
#include <string>
#include <fstream>
#include <vector>

using namespace std;

void LoadFileToVector(string FileName, vector<string> &vFileContent)
{
    fstream Myfile;
    Myfile.open(FileName, ios::in);

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

void SaveVectorToFile(string FileName, vector<string> &vFileContent)
{
    fstream Myfile;
    Myfile.open(FileName, ios::out);

    if(Myfile.is_open())
    {
        for(string &line : vFileContent)
        {
            if(line != "")
                Myfile << line <<endl;
        }
        Myfile.close();
    }
}

void UpdateRecord(string FileName, string OldRecord, string UpdateTo)
{
    vector<string> vFilecontent;
    LoadFileToVector(FileName, vFilecontent);

    for(string &line : vFilecontent)
    {
        if(line == OldRecord)
            line = UpdateTo;
    }

    SaveVectorToFile(FileName,vFilecontent);
}
void PrintFileContent(string FileName)
{
    fstream Myfile;
    Myfile.open(FileName, ios::in);

    if(Myfile.is_open())
    {
        string line;
        while(getline(Myfile,line))
        {
            cout<< line <<endl;
        }
        Myfile.close();
    }
}

int main()
{   
    cout<<"File content before update record.\n";
    PrintFileContent("MyFile.txt");

    UpdateRecord("MyFile.txt","Ali", "Omar");

    cout<<"\n\nFile content after Update record\n";
    PrintFileContent("MyFile.txt");

    return 0;
}