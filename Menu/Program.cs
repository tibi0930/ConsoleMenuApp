using System;
using System.Collections.Generic;
using System.Threading;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************MENU NAME**************\n");

            var MenuItems = new List<string>();
            MenuItems.Add("Menu item 1");
            MenuItems.Add("Menu item 2");
            MenuItems.Add("Menu item 3");
            MenuItems.Add("Exit");

            int index = 2;
            int prevIndex = index;
            char x = ' ';
            string processType = "";
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
                            process = true;
                            break;
                    }

                    if(process) processType = "Processing";
                    else processType = "";

                    if (prevIndex != index)
                    {
                        Console.SetCursorPosition(1, prevIndex);
                        x = ' ';
                        Console.Write("\r[{0}]", x);
                        Console.SetCursorPosition(1, index);
                        x = 'X';                        
                    }

                    //Console.Write("\r[{0}]\t\t\t{1}\n", x, processType);
                    //Write(toWrite, x, y);
                }
                else
                {
                    Thread.Sleep(100);
                }

                Console.SetCursorPosition(1, index);
                Console.Write("\r[{0}]", x);
                Console.SetCursorPosition(1, index);
            }

            
            
            

            

            Console.ReadLine();
        }
    }
}
