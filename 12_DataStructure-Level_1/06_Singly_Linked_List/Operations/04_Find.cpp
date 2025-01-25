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

Node *Find(Node *Head, int Value)
{
    while(Head != NULL)
    {
        if(Value == Head->Value)
            return Head;
        Head= Head->Next;
    }
    return NULL;
}

void PrintList(Node *Head)
{
    while(Head != NULL)
    {
        cout<< Head->Value <<" ";
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

    Find(Head, 3)!=NULL? cout<<"\nFound\n" : cout<<"\nNOT Found\n";

    return 0;
}

