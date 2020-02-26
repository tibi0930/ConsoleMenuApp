using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu
{
    internal static class Auxiliary
    {
        internal static void Display(int currentIndex, int prevIndex, bool process)
        {
            char x = ' ';
            string processType = " ";
            if (prevIndex != currentIndex)
            {
                Console.SetCursorPosition(1, prevIndex);
                x = ' ';
                Console.Write("\r[{0}]", x);
            }

            Console.SetCursorPosition(1, currentIndex);
            x = 'X';
            if (process)
            {
                processType = "Processing";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\r[{0}]\t\t\t{1}\n", x, processType);
            }
            else
            {
                processType = "          ";
                Console.ResetColor();
                Console.Write("\r[{0}]\t\t\t{1}\n", x, processType);
            }

            Console.SetCursorPosition(1, prevIndex);
            Console.ResetColor();
        }

        internal static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.SetCursorPosition(0, 10);
            System.Environment.Exit(0);
            //Console.ReadKey(false);
        }
    }
}
