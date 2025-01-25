#include<iostream>
#include "clsPerson.h"
#include "clsEmployee.h"
using namespace std;


// Each class on its owne Header File as a Libriry

int main()
{
    clsEmployee Employee(8888,"Chouaib", "Hadadi","G@gmail.com","0976543902","TechLead","SoftEng",99998376);
    
    Employee.print();

    Employee.SendEmail("Hello","How Are You Doing Buddy");
    Employee.SendSMS("Hi Man what's up my nigga how is life ?");

    return 0;
}