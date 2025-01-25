#include <iostream>
using namespace std;
/*The OverLoading is when you have a groupe of fuctions with the same name.
and they have the same job ether sum or somthing alse.
The combiler distinguish between them by:
## the number of parameters.
## the Type of parameters.
!! if Diplacate a function with the same number and type of parameter 
    even the name and the identifier of those functions is deferent well not accept that.

*/

double Mysum(double a, double b)
{
    return (a+b);
}
double Mysum(double a, double b, double c)
{
    return (a+b + c);
}
int Mysum(int a, int b)
{
    return (a+b);
}
int Mysum(int k, int b, int s)
{
    return (k+b + s);
}
/*int Mysum(int a, int b, int d)// it well show an error here because you add the same numbet and Type int the above function  
{
    return (a+b +d);
}*/

int main()
{
    cout<<Mysum(12.3, 2.3, 3.0)<<endl;
    cout<<Mysum(123, 23, 3) <<endl;
    cout<<Mysum( 2.3, 3.0) <<endl;
    cout<<Mysum( 3, 30) <<endl;

    //That's kinde of polemorfisme the same name has multiFaces.

    return 0;
}