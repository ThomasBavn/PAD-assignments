
using System;

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
        if (_count < _arr.Length /2)
            ResizeDown();
        return toReturn;
    }

    private void ResizeDown()
    {
        T[] temp = new T[_arr.Length / 2];
        for (int i = 0; i < _arr.Length; i++)
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

public class TestClass{
public void Main(string[] args)
{
    Console.ReadLine();
    var stack = new BadStack<int>();

    // arr gets Length of 10000
    for (int i = 0; i < 10000; i++)
    {
        stack.Push(i);
    }
    
    // arr gets resized down to size of 5000 where all entries are filled out
    for (int i = 0; i < 5001; i++)
    {
        stack.Pop();
    }
    
    // Continuously push and pop to force resizing for each iteration
    for (int i = 0; i < 1000; i++)
    {
        if (i % 2 == 0)
        {
            stack.Push(i);
        }
        else
        {
            stack.Pop();
        }
    }

}

}