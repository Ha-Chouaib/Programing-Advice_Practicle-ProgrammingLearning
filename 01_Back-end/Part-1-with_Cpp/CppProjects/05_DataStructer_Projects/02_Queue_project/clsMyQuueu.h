#pragma once
#include<iostream>
#include"../01_DoublyLinkedList_Project/clsDblLinkedList.h"

using namespace std;

template<class T>
class clsMyQueue
{

protected:
    clsDblLinkedList <T> _List;

public:

    void push(T Item)
{
    _List.InsertAtEnd(Item);
}
    void pop()
{
    _List.DeleteFirstNode();
}
    int Size()
{
    return _List.Size();
}
    T Front()
{
    return (T)_List.GetItem(0);
}
    T Back()
{
    return (T) _List.GetItem(Size() -1);
}
    void print()
{
    _List.PrintList();
}
    T IsEmpty()
    {
        return _List.IsEmpty();
    }

    T GetItem(int Index)
    {
        return _List.GetItem(Index);
    }
    void UpdateItem(int Index,T Value)
    {
        _List.UpdateItem(Index,Value);
    }
    void InsertAfter(int Index, T Value)
    {
        _List.InsertAfter(Index, Value);
    }
    void InsertAtFront(T Value)
    {
        _List.InsertAtBeginning(Value);
    }
    void InsertAtBack(T Value)
    {
        _List.InsertAtEnd(Value);
    }
    void Clear()
    {
        _List.Clear();
    }



};