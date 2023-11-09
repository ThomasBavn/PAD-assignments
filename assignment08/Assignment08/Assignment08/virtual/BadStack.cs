
using System;

namespace MyNamespace
{
    
}

public class BadStack<T>
{
    private T[] _arr;
    private int _count;
    
    public BadStack()
    {
        _arr = new T[2];
        _count = 0;
    }

    public void Push(T n)
    {
        if (_count == _arr.Length)
        {
            ResizeUp();
        }
        
        _arr[_count++] = n;
    }

    public T Pop()
    {
        T toReturn = _arr[--_count ];
        if (_count <= _arr.Length /2)
            ResizeDown();
        return toReturn;
    }

    private void ResizeDown()
    {
        T[] temp = new T[_arr.Length / 2];
        for (int i = 0; i < _count; i++)
        {
            temp[i] = _arr[i];
        }

        _arr = temp;

    }

    private void ResizeUp()
    {
        T[] temp = new T[_arr.Length * 2];
        for (int i = 0; i < _arr.Length; i++)
        {
            temp[i] = _arr[i];
        }

        // _arr is reassigned, the old _arr is left to be garbage collected
        _arr = temp;
    }
}

