#include <iostream>
#include <cstdlib>

using namespace std;

//write a program to check if the Matrix is Palindrom or Not.

int GetRandomNum(short From, short To)
{
    return rand()% (To - From + 1) +From;
}

void FillMatrixWithRandomNum(int Matrix[3][3],short Rows, short Cols)
{
    for(int i=0;i<Rows; i++)
    {
        for(int x=0; x<Cols; x++)
        {
            Matrix[i][x]= GetRandomNum(1,100);
        }
    }
}

void PrintMatrix(int Matrix[3][3], short Rows, short Cols)
{
    for(int row=0; row<Rows; row++)
    {
        for(int col=0; col<Cols; col++)
        {   
            printf("%0*d    ",2,Matrix[row][col] );
            
        }
        cout<<endl;
    }
    cout<<endl;
}

bool IsPalindromMatrix(int Matrix[3][3],short Rows,short Cols)
{
    for(short row=0; row <Rows; row++)
    {   
        for(short col=0; col< Cols/2; col++)
        {
            if(Matrix[row][col] != Matrix[row][Cols-1 - col])
                return 0;
        }
    }
    return 1;
}

void ShowResult(int Matrix[3][3],short Rows,short Cols)
{
    IsPalindromMatrix(Matrix,3,3)? cout<<"The Matrix Is Palindrom.\n" : cout<<"Not a Palindrom one\n";
}

int main()
{
    srand((unsigned)time(NULL));
    int Matrix[3][3]={{1,2,1},{4,5,4},{6,7,6}};
    // FillMatrixWithRandomNum(Matrix,3,3);

    cout<<"Matrix Content: "<<endl;
    PrintMatrix(Matrix,3,3);

    ShowResult(Matrix,3,3);


    return 0;
}