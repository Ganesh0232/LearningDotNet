namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton Design Pattern \n");

            Singleton singleton =  Singleton.GetInstance;
            singleton.SingletonMethod("it is Singletons first instance");
            singleton.SingletonMethod("second Instance");
        }
    }
}