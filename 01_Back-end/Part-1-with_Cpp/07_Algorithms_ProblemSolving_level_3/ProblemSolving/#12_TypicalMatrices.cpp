#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <cmath>
using namespace std;

//write a program to compare tow 3x3 Matrix with random numbers
//->and check is they  are Typical or not.

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

bool AreMatricesTypical(int Matrix1[3][3], int Matrix2[3][3] ,short Rows, short Cols)
{   
    for(int Row=0; Row<Rows; Row++)
    {
        for(int Col=0; Col<Cols; Col++)
        {   
            if(Matrix1[Row][Col] != Matrix2[Row][Col])
                return 0;
            
        } 
    }
    return 1;
    
}

void ShowResult(int Matrix1[3][3], int Matrix2[3][3] ,short Rows, short Cols)
{
    AreMatricesTypical(Matrix1,Matrix2,Rows, Cols) ? cout<<"\nYes: Matrices are Typical.\n" : cout<<"\nNo: Matrices are Not Typical!\n";
}

void PrintMatrix(int Matrix[3][3], short ROWs, short COLs)
{
    for(int Row=0; Row<ROWs; Row++)
    {
        for(int Col=0; Col<COLs; Col++)
        {   
            printf("%0*d    ",2,Matrix[Row][Col]);
            
        }
        cout<<endl;
    }
    cout<<endl;
}

int main()
{   srand((unsigned)time(NULL));
    int Matrix[3][3], Matrix2[3][3];

    FillMatrixWithRandomNum(Matrix,3,3);
    FillMatrixWithRandomNum(Matrix2,3,3);

    cout<<"Matrix Element: "<<endl;
    PrintMatrix(Matrix,3,3);

    cout<<"Matrix2 Element: "<<endl;
    PrintMatrix(Matrix2,3,3);

    ShowResult(Matrix,Matrix2,3,3);
    return 0;
}