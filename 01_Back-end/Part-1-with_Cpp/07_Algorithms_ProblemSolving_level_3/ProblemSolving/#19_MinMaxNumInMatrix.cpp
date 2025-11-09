#include <iostream>
#include <cstdlib>
#include <limits>
using namespace std;

//write a program to print the Max and min number in a matrix.

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

short MaxNumInMatirx(int Matrix[3][3],short Rows, short Cols)
{   short Max=Matrix[0][0];
    for(short row=0; row<Rows ;row++)
    {
        for(short col=0; col<Cols; col++)
        {
            if(Max <= Matrix[row][col])
                Max=Matrix[row][col];
        }
    }
    return Max;
}
short MinNumInMatirx(int Matrix[3][3],short Rows, short Cols)
{   short Min=Matrix[0][0];
    for(short row=0; row<Rows ;row++)
    {
        for(short col=0; col<Cols; col++)
        {
            if(Min >= Matrix[row][col])
                Min=Matrix[row][col];
        }
    }
    return Min;
}

int main()
{   
    srand((unsigned)time(NULL));
    int Matrix[3][3];
    FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"Matrix: "<<endl;
    PrintMatrix(Matrix,3,3);

    cout<< "Max Number in the Matrix: "<<MaxNumInMatirx(Matrix,3,3)<<endl;
    cout<< "Min Number in the Matrix: "<<MinNumInMatirx(Matrix,3,3)<<endl;
    
    
    return 0;
}
