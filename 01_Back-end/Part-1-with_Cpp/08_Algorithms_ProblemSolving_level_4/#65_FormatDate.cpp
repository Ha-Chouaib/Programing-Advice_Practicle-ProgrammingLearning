#include<iostream>
#include<string>
#include<vector>
using namespace std;

//write a program to Read date as string and do a function to format that date

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

stDate StringToDate(string StringDate,string Delimiter="/")
{   
    stDate Date;
    vector <string>vDate;
    MySplit(StringDate,vDate,Delimiter);

    Date.Day=  stoi(vDate[0]);
    Date.Month=stoi(vDate[1]);
    Date.Year= stoi(vDate[2]);
    
    return Date;
}

string DateToString(stDate Date,string Separator="/")
{
    return to_string(Date.Day)+ Separator +to_string(Date.Month)+ Separator +to_string(Date.Year);
}

string ChangStrCase(string Str, bool ToLower=true)
{  
    for(int i=0; i<Str.length(); i++)
    {
        if(ToLower)
            Str[i]=char(tolower(Str[i]));
        else
            Str[i]=char(toupper(Str[i]));
    }
    return Str;
}

string ReplaceWords(string Str,string WordToReplace,string NweWord)
{
    short pos=Str.find(WordToReplace);
    while(pos != std::string::npos)
    {
        Str.replace(pos, WordToReplace.length(),NweWord);
        pos=Str.find(WordToReplace);
    }

    return Str;
}


string DateFormat(stDate Date,string FormatOption="dd/mm/yyyy")
{
    string Format=""; 
    Format= ReplaceWords(FormatOption,"dd",to_string(Date.Day));
    Format= ReplaceWords(Format,"mm",to_string(Date.Month));
    Format= ReplaceWords(Format,"yyyy",to_string(Date.Year));

    return Format;
}



int main()
{   
    string stringDate=ReadTxt("Please enter a date -> ( dd/mm/yyyy )?");
    
    stDate Date=StringToDate(stringDate);
    
    printf("\n%s\n",DateFormat(Date).c_str());
    printf("\n%s\n",DateFormat(Date,"yyyy/dd/mm").c_str());
    printf("\n%s\n",DateFormat(Date,"Day: dd/Month: mm/ Year: yyyy").c_str());
    printf("\n%s\n",DateFormat(Date,"yyyy-mm-dd").c_str());
    printf("\n%s\n",DateFormat(Date,"[Day->dd]/[Month->mm]/[Year->yyyy]").c_str());

    return 0;
}