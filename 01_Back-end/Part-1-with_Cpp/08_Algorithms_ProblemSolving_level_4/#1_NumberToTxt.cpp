//write a program to read a number then print it by txt.

#include <iostream>
using namespace std;

int ReadNumber()
{
    int num=0;
    cout<<"Enter a number: "<<endl;
    cin>>num;
    return num;
}
string NumberToTxt(int Num)
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

int main()
{   int Number=0;
    Number= ReadNumber();
    cout<< NumberToTxt(Number) <<endl;

    return 0;
}