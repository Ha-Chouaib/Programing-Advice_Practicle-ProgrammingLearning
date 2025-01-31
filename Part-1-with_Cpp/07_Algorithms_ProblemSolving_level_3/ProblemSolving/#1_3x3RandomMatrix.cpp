
//Write a program to fill 3x3 random Matrix with random numbers;

#include<iostream>
#include<cstdlib>
#include<iomanip>
using namespace std;

int GetRandomNumber(int From, int To)
{
    return rand() % (To - From +1) +From;
}

void FillMatrixWithRandNums(int matrix[3][3],short ROWs, short COLs)
{
    for(int Row=0; Row<ROWs; Row++)
    {
        for(int Col=0; Col<COLs; Col++)
        {
            matrix[Row][Col]=GetRandomNumber(1,100);
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
    srand((unsigned)time(NULL));

    int Matrix[3][3];
    FillMatrixWithRandNums(Matrix,3,3);

    cout<<"The Matrix Array elements: "<<endl;
    PrintMatrix(Matrix, 3, 3);


    return 0;
}