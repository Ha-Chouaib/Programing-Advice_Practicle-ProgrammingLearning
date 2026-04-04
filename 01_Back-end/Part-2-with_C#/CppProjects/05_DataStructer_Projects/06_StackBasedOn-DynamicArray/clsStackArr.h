#pragma once
#include<iostream>
#include"../05_QueueBasedOn-DynamicArray/clsQueueArr.h"

using namespace std;

template<class T>

class clsStackArr : public clsQueueArr<T>
{
public:
    void push(T Value)
    {
        clsQueueArr<T>::arr.InsertAtEnd(Value);
    }
    void pop()
    {
        clsQueueArr<T>::arr.DeleteLastItem();
    }
    T Top()
    {
        return clsQueueArr<T>::Front();
    }
    T Bottom()
    {
        return clsQueueArr<T>::Back();
    }

};