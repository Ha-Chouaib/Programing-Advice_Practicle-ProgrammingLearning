#pragma once
#include<iostream>

using namespace std;

template<class T>
class clsDblLinkedList
{
protected:
    int _Size=0;
    
public:

    class Node
    {
    public:
        Node * Next, *Prev;
        T Value;
    };
    
    Node *Head =NULL;

    void InsertAtBeginning(T Value)
    {
        Node* NewNode= new Node();

        NewNode->Next= Head;
        NewNode->Value=Value;
        NewNode->Prev=NULL;

        if(Head != NULL)
        {
            Head->Prev =NewNode;
        }
        Head = NewNode;
        _Size++;
    }

    Node *FindNode( T Value)
    {
        Node *Current=Head;
        while(Current != NULL)
        {
            if(Current->Value == Value)
            {
                    return Current;
            }
            Current=Current->Next;
        }
        return NULL;
    }

    void InsertAfter(Node* &Current, T Value)
    {
        if(Current == NULL)return;
        Node *NewNode = new Node();

        NewNode->Value=Value;
        NewNode->Prev=Current;
        NewNode->Next=Current->Next;

        
        if(Current->Next != NULL)
        {
            Current->Next->Prev= NewNode;
        }
        Current->Next=NewNode;
        _Size++;
        
    }
    
    void InsertAtEnd(T Value)
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
            Node *LastNode= Head;
            while(LastNode->Next != NULL)
            {
                LastNode = LastNode->Next;
            }
            NewNode->Prev=LastNode;
            LastNode->Next=NewNode;
        }
        _Size++;
        
    }

    void DeleteNode(Node *&NodeToDelete)
    {
        if(NodeToDelete == NULL || Head ==NULL)return ;
    
        if(Head == NodeToDelete)
        {
            Head=NodeToDelete->Next;
        }       
        NodeToDelete->Next->Prev = NodeToDelete->Prev;
        NodeToDelete->Prev->Next=NodeToDelete->Next;
        
        delete NodeToDelete;
        _Size--;
    }

    void DeleteFirstNode()
    {
        if(Head == NULL)return;
        Node *FirstNode=Head;
        Head=FirstNode->Next;
        if(Head != NULL)
            Head->Prev=NULL;

        delete FirstNode;
        _Size--;

    }

    void DeleteLastNode()
    {
        if(Head == NULL)return ;

        if(Head->Next == NULL)
        {
            delete Head;
            Head=NULL;
            return;
        }

        Node *LastNode = Head;
        while (LastNode->Next != NULL)
        {
            LastNode=LastNode->Next;  
        }

        LastNode->Prev->Next=NULL;

        delete LastNode;
        _Size--;
        
    }

    void PrintList()
    {   
        cout<<endl;
        Node* Current =Head;
        while(Current != NULL)
        {
            cout<< Current->Value <<" ";
            Current= Current->Next;
        }
        cout<<endl;
    }

    int Size()
    {
        return  _Size;
    }
    bool IsEmpty()
    {
        return (_Size == 0);
    }
    void Clear()
    {
        while(Head != NULL)
        {
            while( _Size > 0)
            {
                DeleteFirstNode();
            }
        }
    }
    void Reverse()
    {
        Node *Temp=nullptr;
        Node* Current =Head;
        while (Current != nullptr)
        {
            Temp = Current->Prev;
            Current->Prev=Current->Next;
            Current->Next=Temp;
            Current = Current->Prev;

        }
        if(Temp != nullptr)
        {
            Head =Temp->Prev;
        }
        
    }
    Node *GetNode(int Index)
    {   
        if(Index > _Size-1 || Index <0)return NULL;
        
        int Counter=0;
        Node* Current=Head;
        while(Current != NULL && Current->Next != NULL)
        {
            if(Counter == Index)
                break;
            Current=Current->Next;
            Counter++;
        }
        return Current;
    }
    T GetItem(int Index)
    {
        return (T) GetNode(Index)->Value ;
    }
    bool UpdateItem(int Index, T NewValue)
    {
        Node * Target = GetNode(Index);
        if(Target != NULL)
        {
            Target->Value =NewValue;
            return true;
        }
        return false;
    }
    void InsertAfter(int Index,T Value)
    {
        Node* AddNode=GetNode(Index);
        if(AddNode != NULL)
        {
            InsertAfter(AddNode,Value);
        }
    }


};

