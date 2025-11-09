#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <cmath>
using namespace std;

//write a program to fill a 3x3 Matrix with random numbers
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

int main()
{   srand((unsigned)time(NULL));
    int Matrix[3][3];

    FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"MatrexElement: "<<endl;
    PrintMatrix(Matrix,3,3);

    cout<<"Matrix Sum= "<<SumOfMatrix(Matrix,3,3) <<endl;

    return 0;
}