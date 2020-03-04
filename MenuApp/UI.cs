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
        private static int currentLine;
        private readonly static int menuLength = Enum.GetNames(typeof(MenuItems)).Length;

        private static bool isExit = false;
        public static bool IsExit => isExit;

        internal static void MoveDown()
        {
            DrawX(currentLine, true);
            currentLine++;
            DrawX(currentLine);
        }

        internal static void MoveUp()
        {
            DrawX(currentLine, true);
            currentLine--;
            DrawX(currentLine);
        }

        internal static void Enter()
        {
            Select(currentLine, true);
            ClearResult(menuLength);
        }

        internal static MenuItems GetCurrentElement()
        {
            return (MenuItems)currentLine;
        }

        internal static void ProcessFinished()
        {
            Select(currentLine, false);
        }

        internal static void ExitMenu()
        {
            Console.SetCursorPosition(0, menuLength + 5);
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
            currentLine = 0;
            DrawX(currentLine);
        }

        internal static keyCommand ReadKey()
        {
            keyCommand result = keyCommand.None;
            if (Console.KeyAvailable)
            {
                var command = Console.ReadKey(true);
                switch (command.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (currentLine < menuLength)
                        {
                            result = keyCommand.Down;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (0 < currentLine)
                        {
                            result = keyCommand.Up;
                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            if (currentLine == menuLength)
                            {
                                isExit = true;
                            }
                            else
                            {
                                result = keyCommand.Enter;
                            }
                        }
                        break;
                }
            }
            return result;
        }

        internal static void DisplayResult()
        { 
            Console.Write("{0} process status:", ((MenuItems)currentLine).GetValueAsString());
            Console.SetCursorPosition(30, Console.CursorTop);
        }

        internal static void DisplayPercentage(int i)
        {
            Console.SetCursorPosition(30, Console.CursorTop);
            Console.Write("{0}%", i * 20);
        }

        #region private methods
        private static void DrawX(int line, bool delete = false)
        {
            char mark = 'X';
            if (delete) mark = ' ';

            Console.SetCursorPosition(1, line + 2);
            Console.Write("\r[{0}]", mark);
            Console.SetCursorPosition(1, line + 2);
        }

        private static void Select(int line, bool inProcess)
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

        private static void ClearResult(int startLine)
        {
            Console.SetCursorPosition(0, startLine + 4);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        private static string GetValueAsString(this MenuItems environment)
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
        #endregion
    }
}
