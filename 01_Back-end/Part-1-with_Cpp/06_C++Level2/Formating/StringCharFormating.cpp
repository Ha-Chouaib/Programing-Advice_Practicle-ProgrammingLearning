#include <iostream>
using namespace std;


// first of all the formating not supported strings  support only the char.

int main()
{
    char Name[]="Chouaib hadadi";
    char School[]="Programing advice";

    printf("Hello \"%s\" wellcome to the \"%s\" univercity :)\n",Name ,School);

    char o='R';
    printf("setting the width of character:%*c\n",1,o);
    printf("setting the width of character:%*c\n",2,o);
    printf("setting the width of character:%*c\n",3,o);
    printf("setting the width of character:%*c\n",4,o);
    printf("setting the width of character:%*c\n",5,o);
    return 0;
}