#include<iostream>
using namespace std;

class Node
{
public:
    int Value;
    Node* Next;
};

void InsertInBeginning(Node* &Head, int Value)
{
    //alocation
    Node * New_Node= new Node();

    //Asignement
    New_Node->Value=Value;
    New_Node->Next= Head;

    //Move Head To New Node
    Head =New_Node;
}

void PrintList(Node *Head)
{
    while(Head != NULL)
    {
        cout<< Head->Value <<endl;
        Head=Head->Next;
    }
}

int main()
{   
    Node* Head=NULL;
    InsertInBeginning(Head,1);
    InsertInBeginning(Head,2);
    InsertInBeginning(Head,3);
    InsertInBeginning(Head,4);
    InsertInBeginning(Head,5);
    InsertInBeginning(Head,6);

    PrintList(Head);

    return 0;
}

