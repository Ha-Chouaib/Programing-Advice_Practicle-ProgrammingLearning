#include <iostream>
#include <iomanip>
using namespace std;

//write a program to fill 3x3 Matrix with  oredered numbers.
//-> Then transpose matrix and print it.

void FillMatrixInOrder(int Matrix[3][3], short Rows, short Cols)
{   short i=0;
    for(short row=0; row<Rows; row++)
    {   
        for(short col=0; col<Cols; col++)
        {   i++;
            Matrix[row][col]= i;
        }
    }
}


void TransposeMatrix(int Matrix[3][3],int MatrixTransposed[3][3],short Rows, short COLs)
{
    for(int x=0; x<Rows; x++)
    {
        for(int y=0; y<COLs; y++)
        {
            MatrixTransposed[x][y]= Matrix[y][x];
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

int main()
{
    int Matrix[3][3], MatrixTransposed[3][3];

    FillMatrixInOrder(Matrix,3,3);
    cout<<"Matrix Content before Transposing: "<<endl;
    PrintMatrix(Matrix,3,3);

    TransposeMatrix(Matrix,MatrixTransposed,3,3);


    cout<<"Matrix Content after Transposing: "<<endl;
    PrintMatrix(MatrixTransposed,3,3);

    return 0;
}