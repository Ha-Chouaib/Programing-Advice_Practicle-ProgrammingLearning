#include <iostream>
using namespace std;

void HomeWork1()
{   
    // int x[Row][Col];
    int x[3][4]={{1,2,3,4},{5,6,7,8},{9,10,11,12}};

    for(int Row=0; Row <3; Row++)
    {
        for(int Col=0; Col<4;Col++)
        {
            cout<< x[Row][Col] <<" ";
        }
        cout<<endl;
    }
    cout<<endl;
}

//--------------------------------------------

void FillArray(int D[10][10])
{
    for(int Row=0; Row<10; Row++)
        {
            for(int Col=0; Col<10; Col++)
            {
                D[Row][Col]= (Row+1) * (Col+1);
            }
        }
}

void PrintArray(int D[10][10])
{
    for(int i=0; i<10; i++)
        {
            for(int x=0; x<10; x++)
            {
                printf("%0*d ",2,D[i][x]);
            }
            cout<<endl;
        }
}
void HomeWork2()
{   
    int D[10][10];
    FillArray(D);
    PrintArray(D);
}

int main()
{
    HomeWork1();
    HomeWork2();

    return 0;
}