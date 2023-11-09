using System;

public class TestClass{
    public static void Main(string[] args)
    {
        Console.ReadLine();
        var stack = new BadStack<int>();

        // arr gets Length of 10000
        for (int i = 0; i < 1000000; i++)
        {
            stack.Push(i);
        }
    
        // Push and pop a lot of time to cause a lot of resizing
        for (int i = 0; i < 1000000; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < 499999; j++)
                {
                    stack.Pop();
                }
            }
            else
            {
                for (int j = 0; j < 499999; j++)
                {
                    stack.Push(j);
                }
            }
        }

    }

}