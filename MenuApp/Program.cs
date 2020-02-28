using System;

namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Auxiliary.myHandler);

            var terminal = new Terminal("MANU NAME");
            terminal.Run();

        }
    }
}
