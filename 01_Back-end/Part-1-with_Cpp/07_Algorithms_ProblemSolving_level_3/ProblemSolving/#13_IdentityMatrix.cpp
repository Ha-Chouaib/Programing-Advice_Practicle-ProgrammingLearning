#include <iostream>
#include <cstdlib>
#include <iomanip>
using namespace std;

//write a program to fill 3x3 Matrix with random numbers
//->Then check is the matrix [Identity] or not

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


bool IsIdentityMatrix(int Matrix[3][3], short Rows,short Cols)
{
    for(int row=0; row<Rows; row++)
    {
        for(int col=0; col<Cols; col++)
        {

            if(row == col && Matrix[row][col] !=1)
                return 0;
            if(row != col  &&  Matrix[row][col] !=0)
                return 0;
        }
    }
    return 1;
}

void ShowResult(int Matrix[3][3],short Rows, short Cols)
{
    IsIdentityMatrix(Matrix,Rows, Cols) ? cout<<"\nYes: Matrix is Identity.\n" : cout<<"\nNo: Matrix is Not Identity!\n";
}


int main()
{   
    srand((unsigned)time(NULL));
    int Matrix[3][3]={{1,0,0},{0,1,0},{0,0,1}};

    // FillMatrixWithRandomNum(Matrix,3,3);
    

    cout<<"3x3 random Matrix content:"<<endl;
    PrintMatrix(Matrix,3,3);

    ShowResult(Matrix, 3,3);



    return 0;
}