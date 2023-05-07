using System.Collections.Immutable;

namespace ImmutableStack_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //stackDemo();
            QueueDemo();
            Console.ReadLine();
            
            //Console.WriteLine("Hello, World!");
        }

        private static void QueueDemo()
        {
            var q = ImmutableQueue<int>.Empty;
            q = q.Enqueue(32);
            q = q.Enqueue(132);

         //   PrintOutCollection(q);

            int first = q.Peek();

            Console.WriteLine("Last Item : "+first);
            q = q.Dequeue(out first);
            Console.WriteLine($"Last item : {first};\n Last after pop {q.Peek()}");
        }

        private static void stackDemo()
        {
           var stack = ImmutableStack<int>.Empty;

            stack = stack.Push(1);
            stack = stack.Push(2);

            int last = stack.Peek();
            Console.WriteLine($"Last Item : {last}");

            stack = stack.Pop(out last);

            Console.WriteLine($"Last item : {last} \nLast item after pop :  {stack.Peek()}");
        }
    }
}