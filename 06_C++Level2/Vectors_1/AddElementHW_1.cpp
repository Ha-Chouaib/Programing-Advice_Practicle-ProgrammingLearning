#include <vector>
#include <iostream>
#include <limits>

using namespace std;

void FillVector(vector <int> &vNum)
{   char AddMore= 'n';
    int Num=0;

    do
    {
        cout<<"Pease enter a number?"<<endl;
        cin>>Num;

        while(cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');
            cout<<"Type Error!!. please enter an integer!"<<endl;
            cin>>Num;
        }
        vNum.push_back(Num);
        cout<<"Do you want Add More [yes]-->(Y)\\ No-->(N)."<<endl;
        cin>>AddMore;


    } while (AddMore== 'Y' || AddMore== 'y');
    
}

void PrintVector(vector <int> &vNums)
{
    for(int &Num : vNums)
    {
        cout<< Num <<endl;
    }
}

int main()
{   vector <int> vNumbers;

    FillVector(vNumbers);
    PrintVector(vNumbers);


    return 0;
}