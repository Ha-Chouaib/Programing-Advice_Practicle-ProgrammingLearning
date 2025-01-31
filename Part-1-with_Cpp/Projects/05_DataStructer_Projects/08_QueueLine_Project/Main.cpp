#include<iostream>
#include"clsQueueLine.h"

using namespace std;

int main()
{
    clsQueueLine PaybillsQueue("A0",10);

    PaybillsQueue.IssueTicket();
    PaybillsQueue.IssueTicket();
    PaybillsQueue.IssueTicket();

    PaybillsQueue.PrintInfo();

    PaybillsQueue.PrintTicketsLineRTL();
    PaybillsQueue.PrintTicketsLineLTR();

    PaybillsQueue.PrintAllTickets();
    
    cout<<"After Sreving 1 Client"<<endl;
    PaybillsQueue.ServeNextClient();
    PaybillsQueue.PrintInfo();
    cout<<"\nAppend 3 More Tickets"<<endl;
    PaybillsQueue.IssueTicket();
    PaybillsQueue.IssueTicket();
    PaybillsQueue.IssueTicket();

    PaybillsQueue.PrintInfo();

    PaybillsQueue.PrintTicketsLineRTL();
    PaybillsQueue.PrintTicketsLineLTR();

    PaybillsQueue.PrintAllTickets();

    return 0;
}