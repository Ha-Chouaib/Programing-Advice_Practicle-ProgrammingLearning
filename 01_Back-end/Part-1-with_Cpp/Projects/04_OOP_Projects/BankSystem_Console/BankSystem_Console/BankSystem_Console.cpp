#include<iostream>
#include"clsLoginScreen.h"


using namespace std;

int main()
{

    while (true)
    {
        if (!clsLoginScreen::DisplayLoginScreen())
        {
            break;
        }
    }

    return 0;
}