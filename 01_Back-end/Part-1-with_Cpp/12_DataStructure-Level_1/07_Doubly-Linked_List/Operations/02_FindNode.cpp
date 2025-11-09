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

void PrintList(Node* Head)
{   
    cout<<"NULL<-->";
    while(Head !=NULL)
    {
        cout<< Head->Value <<"<-->";
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

    Node* N1=Find(Head,0);
    (N1 != NULL) ?cout<<"\nItem In The Linst :)\n" : cout<<"\nItem NOT Found :(\n";
    N1=Find(Head,2);
    (N1 != NULL) ?cout<<"\nItem In The Linst :)\n" : cout<<"\nItem NOT Found :(\n";
    
    return 0;
}
