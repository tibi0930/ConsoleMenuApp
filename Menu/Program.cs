using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Auxiliary.myHandler);
            Console.WriteLine("**************MENU NAME**************\n\n");

            var MenuItems = new List<string>();
            MenuItems.Add("Menu item 1");
            MenuItems.Add("Menu item 2");
            MenuItems.Add("Menu item 3");
            MenuItems.Add("Exit");

            int index = 2;
            int prevIndex = index;
            char x = ' ';
            bool process = false;
            foreach (var item in MenuItems)
            {
                Console.Write("\r[{0}]{1}\n", x, item);
            }

            x = 'X';
            Console.SetCursorPosition(1, index);
            Console.Write("\r[{0}]", x);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            if (index < MenuItems.Count + 1) { prevIndex = index; index++; }
                            break;
                        case ConsoleKey.UpArrow:
                            if (2 < index) { prevIndex = index; index--; }
                            break;
                        case ConsoleKey.Enter:
                            {
                                ProcessItem(index, MenuItems.Count + 2);
                                process = true;
                                while (Console.KeyAvailable)
                                {
                                    Console.ReadKey(true);
                                }
                            }
                            break;
                    }

                    if (prevIndex != index)
                    {
                        Console.SetCursorPosition(1, prevIndex);
                        x = ' ';
                        Console.Write("\r[{0}]", x);
                        Console.SetCursorPosition(1, index);
                        x = 'X';
                    }

                    //Console.Write("\r[{0}]\t\t\t{1}\n", x, processType);
                }
                else
                {
                    Thread.Sleep(100);
                }

                Console.SetCursorPosition(1, index);
                Console.Write("\r[{0}]\t\t\t\n", x);
                Console.SetCursorPosition(1, index);
            }

        }

        

        public static void ProcessItem(int indexOfX, int indexOfBottom)
        {
            Auxiliary.Display(indexOfX, indexOfX, true);
            Console.SetCursorPosition(0, indexOfBottom + 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("Process status:");
            for (int i = 0; i <= 5; ++i)
            {
                Thread.Sleep(1000);
                Console.Write("\r\t\t{0}%", i * 20);
            }
            Auxiliary.Display(indexOfX, indexOfX, false);
        }
    }
}
