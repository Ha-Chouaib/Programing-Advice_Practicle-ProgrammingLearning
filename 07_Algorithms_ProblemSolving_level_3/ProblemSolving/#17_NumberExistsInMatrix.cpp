#include <iostream>
#include <cstdlib>
#include <limits>
using namespace std;

//write a program to check if the Given number exist on the matrix or not.

int GetRandomNum(short From, short To)
{
    return rand()% (To - From + 1) +From;
}

short ReadNumberInRange(short From, short To, string MSG)
{
    int Num=0;
    do
    {   cout<< MSG <<endl;
        cin>>Num;
        while(cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');
            cout<<"\nplease enter an Integer."<<endl;
            cin>>Num;
        }

    } while (From > Num || To < Num);
    
    return Num;
}

void FillMatrixWithRandomNum(int Matrix[3][3],short ROWs, short COLs)
{
    for(int i=0;i<ROWs; i++)
    {
        for(int x=0; x<COLs; x++)
        {
            Matrix[i][x]= GetRandomNum(1,100);
        }
    }
}

void PrintMatrix(int Matrix[3][3], short ROWs, short COLs)
{
    for(int Row=0; Row<ROWs; Row++)
    {
        for(int Col=0; Col<COLs; Col++)
        {   
            printf("%0*d    ",2,Matrix[Row][Col] );
            
        }
        cout<<endl;
    }
    cout<<endl;
}

bool IsNumExistInMatrix(short NumToSearch,int Matrix[3][3], short Rows, short Cols)
{
    for(int Row=0; Row<Rows; Row++)
    {
        for(int Col=0; Col<Cols; Col++)
        {   
           if(NumToSearch == Matrix[Row][Col])
                return 1; 
        }
    }
    return 0;
}

void ShowResult(short NumberToSearch,int Matrix[3][3],short Rows, short Cols)
{
    IsNumExistInMatrix(NumberToSearch,Matrix,Rows,Cols)? cout<<"Yes: The number ["<<NumberToSearch <<"] Is exist in the Matrix\n" : 
    cout<<"No:the Number [" <<NumberToSearch<<"] is Not found\n";
}

int main()
{   
    srand((unsigned)time(NULL));
    int Matrix[3][3],NumberToSearch=0;
    FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"Matrix: "<<endl;
    PrintMatrix(Matrix,3,3);

    NumberToSearch=ReadNumberInRange(1,100,"Please enter  the number you loking for?");
    ShowResult(NumberToSearch,Matrix,3,3);

    
    return 0;
}
