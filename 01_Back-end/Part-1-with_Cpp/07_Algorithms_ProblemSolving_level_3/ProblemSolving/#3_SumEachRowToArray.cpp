#include <iostream>
#include <cstdlib>
#include <iomanip>
using namespace std;

//write a program to fill 3x3 Matrix with random numbers
//->Then sum each row  in separate arry then print the result

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
            cout<< setw(3) <<Matrix[Row][Col] <<"     ";
        }
        cout<<endl;
    }
    cout<<endl;
}

int MatrixRowSum(int Matrix[3][3], short RowNum, short COLs)
{   
    int RowSum=0;
    for(int col=0; col<COLs; col++)
    {   
        RowSum+=Matrix[RowNum][col];
    }
    return RowSum;
}

void StoreEachRowSumInArray(int Matrix[3][3],int RowSum[3], short Rows, short Cols)
{
    for(int row=0 ;row<Rows; row++)
    {   
        RowSum[row]=MatrixRowSum(Matrix,row,Cols);    

    }
}

void PrintArrayWithRowSum(int arr[3],short row)
{
    cout<<"3x3 random Matrix Each Row Sum:"<<endl;
    for(int i=0 ;i<row; i++)
        {   
            cout<<"Sum of Row[ "<<i+1<<" ]: "<< arr[i] <<endl;    

        }
}
int main()
{   
    srand((unsigned)time(NULL));
    int Matrix[3][3], RowSum[3];

    FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"3x3 random Matrix content:"<<endl;
    PrintMatrix(Matrix,3,3);

    StoreEachRowSumInArray(Matrix,RowSum,3,3);

    PrintArrayWithRowSum(RowSum,3);

    return 0;
}