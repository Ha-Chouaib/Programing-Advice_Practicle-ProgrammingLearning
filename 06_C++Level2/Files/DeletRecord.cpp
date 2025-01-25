#include<iostream>
#include<fstream>
#include<string>
#include<vector>
using namespace std;

void LoadDataFromFileToVector(string FileName, vector <string> &vFilecontent)
{
    fstream Myfile;
    Myfile.open(FileName, ios::in);

    if(Myfile.is_open())
    {
        string line;
        while(getline(Myfile, line))
        {
            vFilecontent.push_back(line);
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
                Myfile<< line <<endl;
        }
        Myfile.close();
    }
}

void DeleteRecordFromFile(string FileName, string Record)
{       
    vector<string> vFileContent;
    LoadDataFromFileToVector(FileName, vFileContent);

    for(string &line : vFileContent)
    {
        if(line == Record)
            line ="";
    }
    SaveVectorToFile(FileName,vFileContent);
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
    cout<<"File content before Deleting record.\n";
    PrintFileContent("MyFile.txt");

    DeleteRecordFromFile("MyFile.txt","Momo");

    cout<<"\n\nFile content after delete record\n";
    PrintFileContent("MyFile.txt");

    return 0;
}