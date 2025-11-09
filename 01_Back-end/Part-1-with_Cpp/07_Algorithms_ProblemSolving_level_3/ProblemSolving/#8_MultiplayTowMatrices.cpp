#include <iostream>
#include <cstdlib>
#include <iomanip>
using namespace std;

//write a program to fill  TOw 3x3 Matrix with random numbers
//->Then Multipay them into the thied matrix and print it.

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

void MultiplayTowMatrixs(int Matrix1[3][3], int Matrix2[3][3], int MultMatrix[3][3], short Rows,short Cols)
{
    for(short row=0; row<Rows; row++)
    {
        for(short col=0; col<Cols; col++)
        {
            MultMatrix[row][col]= Matrix1[row][col] * Matrix2[row][col];
        }
    }
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
    int Matrix1[3][3],Matrix2[3][3],Matrix3[3][3];

    FillMatrixWithRandomNum(Matrix1,3,3);
    FillMatrixWithRandomNum(Matrix2,3,3);
    MultiplayTowMatrixs(Matrix1,Matrix2,Matrix3,3,3);

    cout<<"Matrix 1"<<endl;
    PrintMatrix(Matrix1,3,3);

    cout<<"Matrix 2:"<<endl;
    PrintMatrix(Matrix2,3,3);

    cout<<"(Matrix 1) x (Matrix 2):"<<endl;
    PrintMatrix(Matrix3,3,3);



    return 0;
}
