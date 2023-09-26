using System;
using System.Collections.Generic;
using System.Text;

class TestQueue
{
    private readonly Stack<int> mainStack = new Stack<int>();
    private readonly Stack<int> tempStack = new Stack<int>();

    public void Push(int v)
    {
        mainStack.Push(v);
    }

    public int Pop()
    {
        while (mainStack.Count != 0)
        {
            tempStack.Push(mainStack.Pop());
        }

        var result = tempStack.Pop();

        while (tempStack.Count != 0)
        {
            mainStack.Push(tempStack.Pop());
        }

        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        while (mainStack.Count != 0)
        {
            tempStack.Push(mainStack.Pop());
        }

        while (tempStack.Count != 0)
        {
            sb.Append(tempStack.Peek());
            sb.Append(" ");

            mainStack.Push(tempStack.Pop());
        }

        return sb.ToString();
    }
}

class Program
{
    static void Main()
    {
        TestQueue q = new TestQueue();

        for (var i = 0; i < 10; i++)
        {
            q.Push(i * 10);
        }

        Console.WriteLine($"{q} - queue");

        for (var i = 0; i < 10; i++)
        {
            var element = q.Pop();

            Console.WriteLine($"{q, -30} - queue, after deleted:{element}");
        }

        Console.ReadLine();
    }
}