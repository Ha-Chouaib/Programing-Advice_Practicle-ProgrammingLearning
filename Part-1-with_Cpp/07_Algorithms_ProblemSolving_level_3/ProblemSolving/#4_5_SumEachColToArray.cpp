#include <iostream>
#include <cstdlib>
#include <iomanip>
using namespace std;

//write a program to fill 3x3 Matrix with random numbers
//->Then print each column sum
//->[ps#5] Store each column sum in array

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

int ColSum(int Matrix[3][3],short ColNum,short Rows)
{   
    int colSum=0;
    for(int Row=0; Row<Rows; Row++)
    {
        colSum+=Matrix[Row][ColNum];
    }
    return colSum;
}
void StoreColSumInArray(int arr[3], int Matrix[3][3],short COls,short Rows)
{
    for(int i=0; i<COls; i++)
    {
        arr[i]= ColSum(Matrix,i, Rows);
    }
}

void PrintColSum(int arr[3],int Cols)
{   
    cout<<"Each Column sum of the Matrix is: "<<endl;
    for(int i=0; i<Cols; i++)
    {
        cout<<" Col [ "<< i+1 <<" ] Sum= "<<setw(3) <<arr[i] <<endl;
    }
}

int main()
{
    srand((unsigned)time(NULL));
    int Matrix[3][3], ColSum[3];
    FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"Matrix content: "<<endl;
    PrintMatrix(Matrix,3,3);
    
    StoreColSumInArray(ColSum,Matrix, 3,3);

    PrintColSum(ColSum,3);


}