#include<iostream>
using namespace std;

class Node
{
public:
    Node* Prev;
    Node* Next;
    short Value;
};

void InsertAtBeginning(Node*& Head, short Value)
{
    Node * NewNode= new Node();

    NewNode->Next =Head;
    NewNode->Value=Value;
    NewNode->Prev=NULL;

    if(Head != NULL)
    {
        Head->Prev =NewNode;
    }

    Head = NewNode;

}

Node* Find(Node *Head, short Value)
{
    
    while(Head!= NULL)
    {
        if(Head->Value == Value)
        {
            return Head;
        }
        Head= Head->Next;
    }
    return NULL;
}

void InsertAfter(Node* Current, short Value)
{
    if(Current== NULL)return;
    Node* NewNode=new Node();

    NewNode->Value=Value;
    NewNode->Next =Current->Next;
    NewNode->Prev=Current;

    if(Current->Next != NULL)
    {
        Current->Next->Prev=NewNode;
    }

    Current->Next=NewNode;

}

void InsertAtEnd(Node* Head, short Value)
{
    Node* NewNode= new Node();
    NewNode->Value=Value;
    NewNode->Next=NULL;

    if(Head == NULL)
    {
        NewNode->Prev=NULL;
        Head=NewNode;
    }else
    {
        Node* Current = Head;
        while(Current->Next != NULL)
        {
            Current=Current->Next;
        }

        Current->Next=NewNode;
        NewNode->Prev=Current;
    }
    
}

void DeleteNode(Node *Head, Node* &NodeToDelete)
{
    if(NodeToDelete == NULL || Head ==NULL)return ;
    
    if(Head == NodeToDelete)
    {
        Head=NodeToDelete->Next;
    }

    if(NodeToDelete->Next == NULL)
    {
        NodeToDelete->Prev->Next=NULL;
    }
    if(NodeToDelete->Prev ==NULL)
    {
       NodeToDelete->Next->Prev=NULL;
    }  
    if(NodeToDelete->Prev !=NULL && NodeToDelete->Next != NULL) 
    {
        NodeToDelete->Next->Prev = NodeToDelete->Prev;
        NodeToDelete->Prev->Next=NodeToDelete->Next;
    } 
        
    delete NodeToDelete;
}

void DeleteFirstNode(Node *&Head)
{
    if(Head==NULL)return;
    Node* FirstNode=Head;
    Head=Head->Next;
    if(Head != NULL)
        Head->Prev=NULL;

    delete FirstNode;
}

void PrintList(Node* Head)
{   
    cout<<"NULL <--> ";
    while(Head !=NULL)
    {
        cout<< Head->Value <<" <--> ";
        Head= Head->Next;
    }
    cout<<"NULL"<<endl;
}

int main()
{

    Node* Head = NULL;
    InsertAtBeginning(Head,1);
    InsertAtBeginning(Head,2);
    InsertAtBeginning(Head,3);
    InsertAtBeginning(Head,4);

    PrintList(Head);

    Node* N1=Find(Head,4);

    InsertAfter(N1,400);

    InsertAtEnd(Head,500);
    PrintList(Head);


    N1=Find(Head,500);
    DeleteNode(Head,N1);
    PrintList(Head);

    DeleteFirstNode(Head);
    PrintList(Head);


    
    return 0;
}
