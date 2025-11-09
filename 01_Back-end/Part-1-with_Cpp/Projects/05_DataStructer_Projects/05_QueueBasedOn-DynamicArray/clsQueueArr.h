#pragma once
#include<iostream>
#include"../04_Dynamic-array/clsDynamicArray.h"

using namespace std;

template<class T>
class clsQueueArr
{

protected:
    clsDynamicArray<T> arr;

public:

    bool push(T Value)
    {
       return arr.InsertAtEnd(Value);
    }
    bool pop()
    {
        return arr.DeleteFirstItem();
    }
    int Size()
    {
        return arr.Size();
    }
    T Front()
    {
        return (T)arr.GetItem(0);
    }
    T Back()
    {
        return (T)arr.GetItem(Size()-1);
    }
    void print()
    {
        arr.print();
    }
    void UpdateItem(int Index,T Value)
    {
        arr.OriginalArray[Index]=Value;
    }
    void InsertAfter(int Index, T Value)
    {
        arr.InsertAfter(Index,Value);
    }
    bool InsertAtFront(T Value)
    {
        return arr.InsertAtBeginning(Value);
    }
    bool InsertAtBack(T Value)
    {
        return arr.InsertAtEnd(Value);
    }
    T GetItem(int Index)
    {
        return arr.GetItem(Index);
    }
    bool IsEmpty()
    {
        return arr.IsEmpty();
    }
    void Clear()
    {
        arr.Clear();
    }

};
