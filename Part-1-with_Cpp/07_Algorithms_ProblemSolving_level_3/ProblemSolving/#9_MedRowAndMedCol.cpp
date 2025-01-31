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

void GetMidleRow(int Matrix[3][3], int MedRow[3],short Rows, short ColNumbers)
{
    short medRow=round(Rows/2);
    for(int Col=0; Col<ColNumbers; Col++)
    {   
       MedRow[Col]=Matrix[medRow][Col];
        
    }
    
}

void GetMidleCol(int Matrix[3][3], int MedCol[3],short RowNumbers, short Cols)
{

        short medCol=round(Cols/2);
        for(int Row=0; Row<RowNumbers; Row++)
        {   
           MedCol[Row]=Matrix[Row][medCol];
            
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

void PrintArray(int arr[3],short arrLength)
{
    for(int i=0; i< arrLength;i++)
    {
        printf("%0*d    ",2,arr[i]);

    }
    cout<<endl;
}
int main()
{   srand((unsigned)time(NULL));
    int Matrix[3][3], MidleRow[3],MidleCol[3];

    FillMatrixWithRandomNum(Matrix,3,3);
    GetMidleRow(Matrix,MidleRow,3,3);
    GetMidleCol(Matrix,MidleCol,3,3);

    cout<<"Matrix content:"<<endl;
    PrintMatrix(Matrix,3,3);

    cout<<"Midle Row: "<<endl;
    PrintArray(MidleRow,3);

    cout<<"Midle Col: "<<endl;
    PrintArray(MidleCol,3);




    return 0;
}