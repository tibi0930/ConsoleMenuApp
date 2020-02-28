using System;
using System.Threading;

namespace MenuApp.BL
{
    public class MenuItem
    {
        public string Name { get; }

        public MenuItem(string name)
        {
            Name = name;
        }

        public void Command() { }

        public virtual void Run()
        {
            Console.Write("Process status:");
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(18, Console.CursorTop - 1);
            for (int i = 0; i <= 5; ++i)
            {
                Thread.Sleep(1000);
                Console.SetCursorPosition(18, Console.CursorTop);
                Console.Write("{0}%", i * 20);
            }
        }
    }
}