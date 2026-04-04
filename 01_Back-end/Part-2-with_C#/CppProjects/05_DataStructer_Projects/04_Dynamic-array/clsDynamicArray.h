#include<iostream>

using namespace std;

template<class T>
class clsDynamicArray
{   
    
    
protected:
    int _Size=0;
    T* _TempArray;
public:
    T* OriginalArray;

    clsDynamicArray(int Length=0)
    {   
        if(Length < 0)
        {
            Length=0;
        }
        _Size=Length;

        OriginalArray =new T[_Size];
        
    }
    ~clsDynamicArray()
    {
        delete [] OriginalArray;
    }

    bool SetItem(int Index, T Value)
    {   
        if(Index < 0 || _Size < Index) return false;

        OriginalArray[Index]=Value;
        return true;
    }
    int Size()
    {
        return _Size;
    }
    bool IsEmpty()
    {
        return (_Size == 0);
    }
    void print()
    {
        for(int i=0; i<_Size; i++)
        {
            cout<<OriginalArray[i]<<" ";
        }
        cout<<endl;
    }
    void Resize(int NewSize)
    {
        if(NewSize < 0)
        {
            NewSize=0;
        }
        _TempArray = new T [NewSize];

        if(NewSize  < _Size )
        {
            _Size =NewSize;
        }

        for(int i=0; i< _Size; i++)
        {
            _TempArray[i]=OriginalArray[i];
        }
        _Size=NewSize;
        delete [] OriginalArray;
        OriginalArray=_TempArray;
    }

    T GetItem(int Index)
    {
        if(Index< 0 || Index > _Size)return 0;

        return OriginalArray[Index];
    }

    void Reverse()
    {   int Length=0;
        _TempArray=new T[_Size];

        for(int i=_Size-1; i >= 0; i--)
        {
            _TempArray[Length]=OriginalArray[i];
            Length++;
        }

        delete [] OriginalArray;
        OriginalArray=_TempArray;
    }
    void Clear()
    {
        _Size=0;
        _TempArray=new T[0];
        delete[] OriginalArray;
        OriginalArray = _TempArray;
    }

    bool DeleteItemAt(int Index)
    {   
        if(Index<0 || Index > _Size)return false;

        _Size-=1;
        _TempArray=new T[_Size];

        for(int i=0; i< Index; i++)
        {
            _TempArray[i]=OriginalArray[i];
        }
        for(int i=Index +1 ; i < _Size +1; i++)
        {
            _TempArray[i -1] = OriginalArray[i];
        }

        delete [] OriginalArray;
        OriginalArray=_TempArray;
        return true;
    }
    
    bool DeleteFirstItem()
    {
        return DeleteItemAt(0);
    }
    bool DeleteLastItem()
    {
        return DeleteItemAt(_Size -1);
    }
    int Find(T Value)
    {
        for(int i=0; i< _Size; i++)
        {
            if(Value == OriginalArray[i]) return i;
        }
        return -1;
    }

    bool DeleteItem(T Value)
    {
        int Index = Find(Value);
        if(Index == -1)return false;
        return DeleteItemAt(Index);
    }
    bool InsertAt(int Index, T Value)
    {
        if(Index<0 || Index> _Size)return false;
        _Size++;
        _TempArray=new T[_Size];

        for(int i=0; i< Index; i++)
        {
                _TempArray[i]=OriginalArray[i];     
        }

        _TempArray[Index]=Value;

        for(int i= Index; i<_Size-1; i++)
        {
            _TempArray[i+1]=OriginalArray[i];
        }

        delete [] OriginalArray;
        OriginalArray=_TempArray;
        return true;
    }
    
    bool InsertAfter(int Index, T Value)
    {   
        if(Index >= _Size)
            return InsertAt(_Size-1,Value);
        else
            return InsertAt(Index+1,Value);
    }
    bool InsertBefore(int Index, T Value)
    {   
        if(Index < 1)
        {
            return InsertAt(0,Value);
        }else
            return InsertAt(Index-1,Value);
    }
    
    bool InsertAtBeginning(T Value)
    { 
        return InsertAt(0,Value);
    }
    bool InsertAtEnd(T Value)
    {
        return InsertAt(_Size,Value);
    }


};