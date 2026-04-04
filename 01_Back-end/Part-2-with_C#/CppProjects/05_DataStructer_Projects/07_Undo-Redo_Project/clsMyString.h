#pragma once
#include<iostream>
#include<stack>

using namespace std;

class clsMyString
{
    string _Value;
    stack<string> _Undo;
    stack<string> _Redo;


public:

    void SetStr(string Value)
    {   
        _Undo.push(_Value);
        _Value=Value;
        
    }
    string GetStr()
    {
        return _Value;
    }

    void Undo()
    {
        if(! _Undo.empty())
        {
            _Redo.push(_Value);
            _Value= _Undo.top();
            _Undo.pop();
        }

    }
    void Redo()
    {
        if(!_Redo.empty())
        {
            _Undo.push(_Value);
            _Value=_Redo.top();
            _Redo.pop();
        }
    }

};