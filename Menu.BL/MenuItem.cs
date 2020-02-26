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

        public virtual void Run()
        {
            Console.Write("Process status:");
            for (int i = 0; i <= 5; ++i)
            {
                Thread.Sleep(1000);
                Console.Write("\r\t\t{0}%", i * 20);
            }
        }
    }
}