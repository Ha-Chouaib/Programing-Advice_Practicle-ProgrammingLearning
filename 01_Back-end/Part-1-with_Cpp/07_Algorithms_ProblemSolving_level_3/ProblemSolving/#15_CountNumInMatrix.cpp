#include <iostream>
#include <cstdlib>
#include <limits>
using namespace std;

//wrute a program to check if the Matrix scalar or not.
//->[Scalar]=the Matrix has the same number in the diagonal and 0 in the other numbers

int GetRandomNum(short From, short To)
{
    return rand()% (To - From + 1) +From;
}

void FillMatrixWithRandomNum(int Matrix[3][3],short ROWs, short COLs)
{
    for(int i=0;i<ROWs; i++)
    {
        for(int x=0; x<COLs; x++)
        {
            Matrix[i][x]= GetRandomNum(1,10);
        }
    }
}

int ReadNumberInRange(short From, short To, string MSG)
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

short CountNumInMatrix(short NumberToCount, int Matrix[3][3], short Rows, short Cols)
{   short counter=0;
    for(int Row=0; Row<Rows; Row++)
    {
        for(int Col=0; Col<Cols; Col++)
        {   
           if(NumberToCount == Matrix[Row][Col])
                counter++; 
        }
    }
    return counter;
}

int main()
{   
    srand((unsigned)time(NULL));
    int Matrix[3][3],  NumberToCount=0;
    FillMatrixWithRandomNum(Matrix,3,3);
    PrintMatrix(Matrix,3,3);

    NumberToCount=ReadNumberInRange(1,10,"Enter a number to count From 1 to 10.");

    cout<<"The number [ "<<NumberToCount<<" ] is repeated << "
        <<CountNumInMatrix(NumberToCount,Matrix,3,3)<<" >>  Time(s).\n";

    return 0;
}