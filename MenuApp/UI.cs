using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MenuApp
{
    enum keyCommand
    {
        None,
        Up,
        Down,
        Enter
    }

    public enum MenuItems
    {
        [Description("Menu Item 1.")]
        First,
        [Description("Menu Item 2.")]
        Second,
        [Description("Menu Item 3.")]
        Third
    }

    internal static class UI
    {
        public static string GetValueAsString(this MenuItems environment)
        {
            var field = environment.GetType().GetField(environment.ToString());
            var customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (customAttributes.Length > 0)
            {
                return (customAttributes[0] as DescriptionAttribute).Description;
            }
            else
            {
                return environment.ToString();
            }
        }

        public static void DisplayMenu(string title)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"*************{title}*************\n");
            foreach (MenuItems item in (MenuItems[])Enum.GetValues(typeof(MenuItems)))
            {
                Console.WriteLine($"[ ]{item.GetValueAsString()}");
            }
            Console.WriteLine("[ ]Exit");
        }

        internal static keyCommand ReadKey()
        {
            keyCommand result = keyCommand.None;
            if (Console.KeyAvailable)
            {
                var command = Console.ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.DownArrow:
                        result = keyCommand.Down;
                        break;
                    case ConsoleKey.UpArrow:
                        result = keyCommand.Up;
                        break;
                    case ConsoleKey.Enter:
                        result = keyCommand.Enter;
                        break;
                }
            }
            return result;
        }

        internal static void DrawX(int line, bool delete = false)
        {
            char mark = 'X';
            if (delete) mark = ' ';

            Console.SetCursorPosition(1, line + 2);
            Console.Write("\r[{0}]", mark);
            Console.SetCursorPosition(1, line + 2);
        }

        internal static void Select(int line, bool inProcess)
        {
            string processState = "          ";
            Console.SetCursorPosition(30, line + 2);
            if (inProcess)
            {
                processState = "Processing";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", processState);
            }
            else
            {
                Console.Write("{0}", processState);
            }

            Console.ResetColor();
        }

        internal static void ClearResult(int startLine)
        {
            Console.SetCursorPosition(0, startLine + 4);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        internal static void DisplayResult()
        { 
            Console.Write("Process status:");
            Console.SetCursorPosition(18, Console.CursorTop);
        }

        internal static void DisplayPercentage(int i)
        {
            Console.SetCursorPosition(18, Console.CursorTop);
            Console.Write("{0}%", i * 20);
        }
    }
}
