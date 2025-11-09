#pragma once
#include<iostream>
#include"../02_Queue_project/clsMyQuueu.h"

using namespace std;

template<class T>
class clsStack : public clsMyQueue<T>
{
public:

    void push(T Item)
    {
        clsMyQueue<T>::_List.InsertAtBeginning(Item);
    }
    T Top()
    {
        return clsMyQueue<T>::Front();
    }
    T Bottom()
    {
        return clsMyQueue<T>::Back();
    }
    
};
