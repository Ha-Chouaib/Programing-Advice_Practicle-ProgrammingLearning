#include <iostream>
#include <cstdlib>
#include <limits>
using namespace std;

//write a program to check if the Matrix Sparse or not.
//->[Sparse]= the number of zeros is More then the other number in the matrix.

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

bool IsSparseMatrix(int Matrix[3][3], short Rows, short Cols)
{   
    return (CountNumInMatrix(0,Matrix,Rows,Cols) >= (Rows * Cols)/2);
}

void ShowResult(int Matrix[3][3],short Rows, short Cols)
{
    IsSparseMatrix(Matrix,Rows,Cols)? cout<<"Yes: It Is Sparse Matrix\n" : cout<<"No: It's Not a Sparse Matrix\n";
}

int main()
{   
    srand((unsigned)time(NULL));
    int Matrix[3][3]={{0,0,9},{0,0,9},{0,0,6}};
    // FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"Matrix: "<<endl;
    PrintMatrix(Matrix,3,3);

    ShowResult(Matrix,3,3);

    
    return 0;
}