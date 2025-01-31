#pragma once
#include<iostream>
#include<string>
#include<cstdlib>
#include<cmath>
#include"clsDate.h"
#include"clsInputValidate.h"

using namespace std;

class clsUtil
{

public:  
    
    
    static string Tabs(short HowManyTabs)
    {   string Tab="";
        for(int tab=0; tab< HowManyTabs; tab++)
        {
            Tab+= '\t';
        }
        return Tab;
    }

    static string NumberToTxt(int Num)
    {   
        if(Num == 0)
        {
            return "";
        }

        if(Num>=1 && Num<=19)
        {
            string arr[]
            {
                "","One","Tow","Three","Four","Five ","Six","Seven","Eight","Nine","Ten","Eleven",
                "Twelve","Thirteen","Fourteen","Fifteen","sixteen","Seventeen","Eighteen","Nineteen"
            };
            return arr[Num] + " ";
        }
        if(Num>=20 && Num<=99)
        {
            string arr[]
            {
                "","","Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety"
            };
            return arr[Num/ 10]+" "+ NumberToTxt(Num % 10);
        }
        if(Num>=100 && Num<=199)
        {
            return "One Hundered "+NumberToTxt(Num % 100);
        }
        if(Num>=200 && Num<=999)
        {
            return NumberToTxt(Num /  100) + "Hundered " + NumberToTxt(Num % 100);
        }
        if(Num>=1000 && Num<=1999)
        {
            return  "one Thousand "+ NumberToTxt(Num %1000);
        }
        if(Num>=2000 && Num<=999999)
        {
            return NumberToTxt(Num / 1000) + "Thousand "+NumberToTxt(Num % 1000);
        }
        if(Num>=1000000 && 1999999)
        {
            return "one Million "+NumberToTxt(Num % 1000000);
        }
        if(Num>= 2000000 && 999999999)
        {
            return NumberToTxt(Num / 1000000) +"Millions "+NumberToTxt(Num % 1000000);
        }
        if(Num>=1000000000 && 1999999999)
        {
            return "One Billion "+NumberToTxt(Num % 1000000000);
        }
        else
        {
            return  NumberToTxt(Num / 1000000000)+"Billions "+NumberToTxt(Num % 1000000000);
        }
    }


    static bool AreYouSure(string MSG="Are you Sure to Complete this Operation? (Y/N)")
    {   
        char A='N';
        cout<< MSG <<endl;
        cout<<": ";
        cin>>A;
        
        return toupper(A)== 'Y'? true : false;
    }
    
    static void Srand()
    {
        srand((unsigned)time(NULL));
    }

    static int RandomNumber(int From, int To)
    {
        int RandNum= rand()% (To -From +1) +From;
        return RandNum;
    }

    enum enRandomCharType
    {
        SmallLetter=1,
        CapitalLetter=2,
        SpecialCaracter=3,
        Digit=4,
        Mix=5,
    };

    static enRandomCharType ReadCharType()
    {   
        int Randoption;
        cout<< "\nTo get Random of: "
            <<"\nsmall letter      Enter-->[1]"
            <<"\nCapital letter    Enter-->[2]"
            <<"\nSpecial Character Enter-->[3]"
            <<"\na Digit           Enter-->[4]"
            <<"\nUse all           Enter-->[5]"
            <<"\n: ";
        cin>>Randoption;
        return (enRandomCharType )Randoption;

    }

    static char GetRandomChar( enRandomCharType CharType)
    {
        switch(CharType)
        {
        case enRandomCharType::SmallLetter :
            return char(RandomNumber(97,122));

        case enRandomCharType::CapitalLetter:
            return char(RandomNumber(65,90));

        case enRandomCharType::SpecialCaracter:
            return char(RandomNumber(33,47));

        case enRandomCharType::Digit:
            return char(RandomNumber(48,57));

        case enRandomCharType::Mix:
            return char(RandomNumber(32,127));

        default:
            return char(RandomNumber(48,57));
        }
    }

    static string GenerateRandomWord(enRandomCharType CharType, short HowmanyChars)
    {

        string RandWord="";

        for(int i=1; i<=HowmanyChars; i++)
        {
            RandWord+= GetRandomChar(CharType);

        }
        return RandWord;
    }

    static string AddSeparator(short i,short Length, string Separator)
    {   
        if(i >= 1 && i <Length && Length !=1 )
            return Separator;
        return "";
    }

    static string GenerateRandomKey(enRandomCharType CharType, short HowmanyParts,short HowmanyChars )
    {
        string RandKey="";
        for(int i=1; i <=HowmanyParts; i++)
        {
            RandKey+=GenerateRandomWord(CharType,HowmanyChars) + AddSeparator(i,HowmanyParts,"-");
        }
        return RandKey;
    }
    
    static int GetDigitsSum(int Num)
    {
        int Remaindre=0;
        int Result= 0;
        while(Num > 0){
            Remaindre= Num % 10;
            Num/=10;
            Result+= Remaindre; 
        }

        return Result;
    }

    static int ReverceDigits(int Num)
    {
        int Remainder=0, RevNum=0;
        while(Num > 0){
            Remainder= Num %10;
            Num/= 10;
            RevNum= RevNum * 10 + Remainder;    

      }
        return RevNum;
    }

    static int DigitFrequency(int Number, short Digit)
    {
        int Remainder=0, Frq=0;
        while(Number > 0){
            Remainder = Number % 10;
            Number/= 10;

         if(Remainder == Digit)
                Frq++;
        }
        return Frq;
    }

    static void Swap(int& num1, int& num2)
    {

        short Temp;

        Temp= num1;
        num1= num2;
        num2= Temp;
    }
    static void Swap(double& num1, double& num2)
    {

        double Temp;

        Temp= num1;
        num1= num2;
        num2= Temp;
    }
    static void Swap(string& Str1, string& Str2)
    {

        string Temp;

        Temp= Str1;
        Str1= Str2;
        Str2= Temp;
    }
    static void Swap(char& Char1, char& Char2)
    {

        char Temp;

        Temp= Char1;
        Char1= Char2;
        Char2= Temp;
    }
    static void Swap(bool& A, bool& B)
    {

        bool Temp;

        Temp= A;
        A= B;
        B= Temp;
    }
    static void Swap(Date::clsDate& Date1, Date::clsDate& Date2)
    {

        Date::clsDate Temp;

        Temp= Date1;
        Date1= Date2;
        Date2= Temp;
    }
    

    static bool IsPrime(int Num)
    {

        int HalfNum= round(Num/2);

        for(int i=2; i<=HalfNum; i++){

            if(Num % i == 0)
                return 0;
        }

        return 1;
    }

    static bool IsOddNumber(short Number){

        if(Number % 2 ==0)
            return 0;
        else
            return 1;

    }

    static bool IsPerfectNumber(int Num)
    {
        int result=0;
        for(int i=1; i<Num; i++){

            if(Num % i == 0)
                result+= i;
        }
        return Num == result;
    }

    static bool IsBalindromeNumber(int Num)
    {   // exampl: 123321
    return Num == ReverceDigits(Num);

    }

    static string Encryption(string Txt, short EncryptionKey)
        {
            for(int i=0; i<= Txt.length();i++)
            {
                Txt[i]=char( (int)Txt[i] +EncryptionKey);

            }    
            return Txt;
        }

    static string Decryption(string Text, short EncryptionKey)
        {
            for(int i=0; i<=Text.length(); i++)
            {
                Text[i]=char( (int)Text[i] -EncryptionKey);
            }
            return Text;
        }

    static void FillArryWithRandomNumber(int arr[], int& arrLength, short From, short To)
    {   
        cout<<"Enter element number:";
        cin>>arrLength;

        for(int i=0; i<arrLength; i++ )
        {
            arr[i]=RandomNumber(From,To);
        }

    }

    static void PrintArray(int Arr[],int ArrLength)
    {
       for(int i=0; i<ArrLength; i++)
       {
        cout<<Arr[i] <<" ";
       }
       cout<<"\n";
    }
    
    static int RepeatCounting(int Arr[], int ArrLength, int NumberToChek)
    {
        int counter=0;
        for(int i=0; i<ArrLength; i++)
        {
            if(Arr[i]== NumberToChek)
                counter++;
        }
        return counter;
    }
    
    static int ReturnMaxNumberInArray(int arr[], int arrLength)
    {   
        int MaxNum=0;
        for(int i=0; i<arrLength; i++)
        {   
            if(arr[i]>= MaxNum)
            {
                MaxNum=arr[i];

            }

        }
        return MaxNum;
    }

    static int ReturnMinNumberInArray(int arr[], int arrLength)
    {   
        int MinNum=0;
        MinNum=arr[0];
        for(int i=0; i<arrLength; i++)
        {   
            if(arr[i] <= MinNum)
            {
                MinNum=arr[i];

            }

        }
        return MinNum;
    }
    
    static int SumOfArray(int arr[], int arrLength)
    {
        int arrSum=0;
        for(int i=0; i<arrLength; i++)
        {
            arrSum+= arr[i];
        }

        return arrSum;
    }
    
    float AverageArray(int arr[], int arrLength)
    {
        return (float) SumOfArray(arr,arrLength)/ arrLength;
    }

    static void SumOfTowArrays(int arr1[], int arr2[], int SumArrays[], int arrLength)
    {
        for(int i=0; i< arrLength; i++)
        {
            SumArrays[i]= arr1[i] + arr2[i];
        }

    }
    
    static  void ShuffleArray(int arr[], int arrLength)
    {   int temp;
        for(int i=0; i<arrLength; i++)
        {   
            Swap(arr[RandomNumber(1,arrLength)-1], arr[RandomNumber(1, arrLength)-1]);
        }

    }

    static short FindNumberPositionInArray(int arr[],int arrLength,int  NumberToSearch)
    {   
        cout<<"\nYou'r Looking for the Number: "<<NumberToSearch;
        for(int i=0; i< arrLength; i++)
        {
            if(arr[i]== NumberToSearch)
                return i;

        }
        return -1;
    }

    static bool IsNumberInArray(int arr[],int arrLength,int  NumberToSearch)
    {   
        return FindNumberPositionInArray(arr,arrLength,NumberToSearch) != -1;
    }

    static void AddArrayElements(int Number, int arr[],int& arrLength)
    {   
        arrLength++;
        arr[arrLength -1]= Number;
    }
    
    static void AddUserNumbersInArray(int arr[], int& arrLength)
    {   
        bool AddMore= true;
        do
        {   AddArrayElements(clsInputValidate<short>::ReadNumber("Please enter a number"),arr,arrLength);
            cout<< "Do you wanna add More Numbers?\n"
                <<"Enter: [1]-->Yes || [0]-->No"<<endl;
            cin>>AddMore;

        }while(AddMore);
    }
    
    static void CopyArrayUsingAddArrayElement(int OriginalArr[],int CopyArr[] ,int arr1Length, int& arr2Length)
    {
        for(int i=0; i<arr1Length; i++)
        {
            AddArrayElements(OriginalArr[i],CopyArr,arr2Length);
        }

    }
    
    static void CopyDistinctNumbersToArray(int arr[], int DistArr[], int arrLength, int& DistArrLength)
    {
        for(int i=0; i<arrLength; i++)
        {
            if(!IsNumberInArray(DistArr,arrLength, arr[i]))
            {
                AddArrayElements(arr[i], DistArr, DistArrLength);
            }
        }

    }

    static bool IsBalindromArray(int SourceArr[],int arrLength)
    {

       for(int i=0; i<arrLength; i++)
       {
            if(SourceArr[i] != SourceArr[arrLength -1 -i])
                return 0;
       }
       return 1;
    }

    

};