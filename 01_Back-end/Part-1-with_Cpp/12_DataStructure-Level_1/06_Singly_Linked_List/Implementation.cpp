#include<iostream>
using namespace std;

class Node
{
public:
    int Value;
    Node *Next;
};


int main()
{
    Node *Head;
    
    Node *Node1=NULL;
    Node *Node2=NULL;
    Node *Node3=NULL;

    // Alocate Nodes In The Heap
    Node1= new Node();
    Node2= new Node();
    Node3= new Node();
    
    //Assign Value Values;
    Node1->Value=1;
    Node2->Value=2;
    Node3->Value=3;

    //Connect Nodes:
    Node1->Next=Node2;
    Node2->Next=Node3;
    Node3->Next=NULL;

    //Print The Linked List.
    Head = Node1;

    while(Head != NULL)
    {
        cout<< Head->Value <<endl;
        Head = Head->Next;
    }
    
    return 0;
}