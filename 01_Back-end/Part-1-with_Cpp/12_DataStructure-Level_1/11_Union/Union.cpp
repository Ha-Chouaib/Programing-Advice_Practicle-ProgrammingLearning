#include<iostream>
using namespace std;

union U
{
    short ShortVal;
    char CharVal;
    float FloatVal;
};
//The Union Data Type is the Same as the stuct But.
//The Struct Memebrs Each ONe Of the Have Its Owne Memory Space.
//UnLike The Union Members Share The Same Memory Location.

//!\ and we Have To be Carefull When using Union 
int main()
{
    U Un;
    Un.FloatVal=9.09f;

    Un.CharVal='Q';
    cout<<"Char Value: "<<Un.CharVal<<endl;
    cout<<"Float Value: "<<Un.FloatVal<<endl;

    Un.ShortVal=12;
    cout<<"Short Value: "<<Un.ShortVal<<endl;


    return 0;
}