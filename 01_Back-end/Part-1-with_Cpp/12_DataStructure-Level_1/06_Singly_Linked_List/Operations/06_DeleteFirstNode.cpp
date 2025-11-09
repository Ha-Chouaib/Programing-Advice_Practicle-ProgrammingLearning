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

void InserAfter(Node* Prev_Node, int Value)
{
   if(Prev_Node == NULL)
   {
        cout<<"\nThe Given Node Is NULL"<<endl;
        return;
   }
   
    Node* NewNode=new Node();

    NewNode->Value=Value;
    NewNode->Next=Prev_Node->Next;

    Prev_Node->Next=NewNode;

}

void InsertAtEnd(Node* &Head,int Value)
{
    Node* NewNode=new Node();
    NewNode->Value=Value;
    NewNode->Next=NULL;

    if(Head == NULL)
    {
        Head=NewNode;
        return;
    }

    Node* LastNode=Head;
    while(LastNode->Next != NULL)
    {
        LastNode=LastNode->Next;
    }
    LastNode->Next=NewNode;
    return;
}

void DeleteNode(Node *&Head, int Value)
{
    if(Head == NULL)return;

    Node* Prev=Head,*Current=Head;
    if(Head->Value == Value)
    {
        Head= Current->Next;
        delete Current;
        return;
    }
    // Cach The Previous And The Target Node To Delete
    while(Current != NULL && Current->Value != Value)
    {
        Prev=Current;
        Current=Current->Next;
    }

    if(Current == NULL)return;

    Prev->Next=Current->Next;
    delete Current;
    return;
}

void DeleteFirstNode(Node* &Head)
{
    if(Head == NULL)return;

    Node* FisrtNode=Head ;

    Head=FisrtNode->Next;
    delete FisrtNode;
    
    return;
}

void PrintList(Node *Head)
{
    while(Head != NULL)
    {
        cout<< Head->Value <<" ";
        Head=Head->Next;
    }
    cout<<endl;
}

int main()
{   
    Node* Head=NULL;
    InsertAtEnd(Head,1);
    InsertAtEnd(Head,2);
    InsertAtEnd(Head,3);
    InsertAtEnd(Head,4);
    InsertAtEnd(Head,5);
    InsertAtEnd(Head,6);
    InsertAtEnd(Head,7);
    InsertInBeginning(Head,0);
   
    PrintList(Head);

    DeleteFirstNode(Head);
    DeleteFirstNode(Head);

    DeleteNode(Head, 6);

    PrintList(Head);

    return 0;
}

