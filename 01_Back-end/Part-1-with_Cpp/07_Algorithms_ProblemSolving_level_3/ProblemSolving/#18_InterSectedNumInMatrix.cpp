#include <iostream>
#include <cstdlib>
#include <limits>
#include <iomanip>
using namespace std;

//write a program to check if the Given number exist on the matrix or not.

int GetRandomNum(short From, short To)
{
    return rand()% (To - From + 1) +From;
}

short ReadNumberInRange(short From, short To, string MSG)
{
    int Num=0;
    do
    {   cout<< MSG <<endl;
        cin>>Num;
        while(cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');
            cout<<"\nplease enter an Integer."<<endl;
            cin>>Num;
        }

    } while (From > Num || To < Num);
    
    return Num;
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
            printf("%0*d    ",2,Matrix[Row][Col] );
            
        }
        cout<<endl;
    }
    cout<<endl;
}

bool IsNumExistInMatrix(short NumToSearch,int Matrix[3][3], short Rows, short Cols)
{
    for(int Row=0; Row<Rows; Row++)
    {
        for(int Col=0; Col<Cols; Col++)
        {   
           if(NumToSearch == Matrix[Row][Col])
                return 1; 
        }
    }
    return 0;
}


void CommonNumsBetween2Matrices(int Matrix1[3][3], int Matrix2[3][3], short Rows,short Cols)
{   
    short CommonNum=0;
    for(int row=0; row<Rows; row++)
    {
        for(int col=0; col<Cols; col++)
        {   
            CommonNum=Matrix1[row][col];
            if(IsNumExistInMatrix(CommonNum,Matrix2,3,3))
                cout<< setw(3) << CommonNum <<"     ";
        }   
    }
    
}

int main()
{   
    srand((unsigned)time(NULL));
    int Matrix1[3][3]={{8,8,3},{6,7,4},{3,4,6}},Matrix2[3][3]={{8,5,2},{0,1,0},{3,4,6}};
    // FillMatrixWithRandomNum(Matrix1,3,3);
    // FillMatrixWithRandomNum(Matrix2,3,3);


    cout<<"Matrix1: "<<endl;
    PrintMatrix(Matrix1,3,3);

    cout<<"Matrix2: "<<endl;
    PrintMatrix(Matrix2,3,3);

    cout<<"InterSected Numbers are:"<<endl;
    CommonNumsBetween2Matrices(Matrix1,Matrix2,3,3);
    

    
    return 0;
}