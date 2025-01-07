#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <cmath>
using namespace std;

//write a program to compare tow 3x3 Matrix with random numbers
//->and check is they equal or not.

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

int SumOfMatrix(int Matrix[3][3],short Rows, short Cols)
{   
    int Sum=0;
    for(short row=0; row<Rows; row++)
    {
        for(short col=0; col<Cols; col++)
        {
            Sum+=Matrix[row][col];
        }
    }
    return Sum;
}

bool AreMatricesEqual(int Matrix1[3][3], int Matrix2[3][3] ,short Rows, short Cols)
{   
    int M1Sum=SumOfMatrix(Matrix1,Rows,Cols);
    int M2Sum=SumOfMatrix(Matrix2,Rows,Cols);
    return (M1Sum == M2Sum);
}

void ShowResult(int Matrix1[3][3], int Matrix2[3][3] ,short Rows, short Cols)
{
    AreMatricesEqual(Matrix1,Matrix2,Rows, Cols) ? cout<<"\nYes: Matrixs are equal.\n" : cout<<"\nNo: Matrixs are Not Equal!\n";
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