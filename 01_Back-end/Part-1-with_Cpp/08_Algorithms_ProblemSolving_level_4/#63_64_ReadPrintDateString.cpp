#include<iostream>
#include<string>
#include<vector>
using namespace std;

//write a program to
//-> Read Date String.
//-->Print Day Month Year Separatly.
//--->The Convert Date Structer to Date String And print it 

struct stDate
{
    short Day=0,Month=0,Year=0;
};

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

void MySplit(string str, vector <string>& vSplitstr, string Delimiter)
{
    string Token="";
    string Word="";
    short pos=0;
    

    while((pos= str.find(Delimiter)) != std::string::npos)
    {
        Token=str.substr(0, pos);

        if(Token != "")
        {   for(int i=0; i<Token.length();i++)
            {
                if(Token[i] != ' ')
                    Word+= Token[i];
            }

            vSplitstr.push_back(Word);
            
        }
        
        Word.clear();
        str.erase(0, pos + Delimiter.length());
    }

    if(str != "")
        vSplitstr.push_back(str);
}

stDate StringToDate(string StringDate)
{   
    stDate Date;
    vector <string>vDate;
    MySplit(StringDate,vDate,"/");

    Date.Day=  stoi(vDate[0]);
    Date.Month=stoi(vDate[1]);
    Date.Year= stoi(vDate[2]);
    
    return Date;
}

string DateToString(stDate Date,string Separator="/")
{
    return to_string(Date.Day)+ Separator +to_string(Date.Month)+ Separator +to_string(Date.Year);
}

int main()
{   
    string stringDate=ReadTxt("Please enter a date -> ( DD/MM/YY )?");
    
    stDate Date=StringToDate(stringDate);
    printf("\n\nThe Date is: \n");
    cout<<"Day: " <<Date.Day<<endl;
    cout<<"Month: " <<Date.Month<<endl;
    cout<<"Year: " <<Date.Year<<endl;

    cout<<"Date in string Format is: " <<DateToString(Date)<<endl;;

    return 0;
}