using System.Diagnostics;

namespace MultiThreading
{
    public class Program
    {
        static void Task1()
        {
           // lock.(this)
            Console.WriteLine("Task1 started");
            for (int num = 0; num <= 100; num++)
            {
                Console.WriteLine($"Task1 : {num}");
            }
            Thread.Sleep( 1000 );
            Console.WriteLine("Task1 ended");
        }
         void Task2()
        {
            //lock.(this)
            Console.WriteLine("Task2 started");
            for (int num = 0; num <= 100; num++)
            {
                Console.WriteLine($"Task2 : {num}");
            }
            Thread.Sleep(1000);
            Console.WriteLine("Task2 ended");
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Process.Start("notepad.exe");
            //Process.Start("c:\\tmp\\HelloWorld.txt");
            Console.WriteLine("Main Thread started");
            Program t2 = new Program();
            Thread task2 = new Thread(t2.Task2);
            task2.Start();
            Thread t1 = new Thread(Task1); // To intiate thread
            t1.Start(); // To start a thread
            Thread.Sleep(1000);// To put Thread insleep
            task2.Join();
            task2.Priority = ThreadPriority.Highest; // To set priority
            Task1();
         
          t1.Join();// To make the Main thread  end after ending the end of t1 thread
            t1.Abort(); //To abort or end threa t1 which is Task1
            Console.WriteLine("Main Thread exited");
        }
    }
}