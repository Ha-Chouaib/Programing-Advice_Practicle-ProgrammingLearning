#include <iostream>
#include <cstdlib>
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

bool IsMatrixScalar(int Matrix[3][3],short Rows, short Cols)
{   
    int FirstDiagonal=Matrix[0][0];
    for(short row=0; row<Rows; row++)
    {
        for(short col=0; col<Cols; col++)
        {
            if(row==col && FirstDiagonal!= Matrix[row][col])
                return 0;
            if(row!=col && Matrix[row][col]!=0)
                return 0;
        }
    }
    return 1;
}

void ShowResult(int Matrix[3][3],short Rows, short Cols)
{
    IsMatrixScalar(Matrix,Rows, Cols) ? cout<<"\nYes: Matrix is Scalar.\n" : cout<<"\nNo: Matrix is Not Scalar!\n";
}

int main()
{   srand((unsigned)time(NULL));
    int Matrix[3][3]={{9,0,0},{0,9,0},{0,0,9}};

    // FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"Matrix: "<<endl;
    PrintMatrix(Matrix,3,3);

    ShowResult(Matrix,3,3);

    return 0;
}