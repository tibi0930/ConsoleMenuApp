using System;
using System.ComponentModel;
using System.Threading;

namespace MenuApp
{
    internal struct CursorPos
    {
        public int horizontal;
        public int vertical;
        internal CursorPos(int hor = 0, int ver = 0)
        {
            horizontal = hor;
            vertical = ver;
        }
    }
    public class Terminal
    {
        private CursorPos currentPos;
        private CursorPos previousPos;
        private int menuLength;
        private string title;

        public Terminal(string title)
        {
            this.title = title;
            Console.Title = title;
            menuLength = Enum.GetNames(typeof(MenuItems)).Length;
            currentPos = new CursorPos();
        }

        public void Run()
        {
            Console.WriteLine($"*************{title}*************\n");
            foreach (MenuItems item in (MenuItems[]) Enum.GetValues(typeof(MenuItems)))
            {
                Console.WriteLine($"[ ]{item.GetValueAsString()}");
            }
            Console.WriteLine("[ ]Exit");
            RunX();
        }

        private void RunX()
        {
            currentPos.horizontal = 1;
            currentPos.vertical = 2;
            previousPos = currentPos;
            DrawX(currentPos);
            bool isExit = false;
            while (!isExit)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            MoveDown();
                            break;
                        case ConsoleKey.UpArrow:
                            MoveUp();
                            break;
                        case ConsoleKey.Enter:
                            {
                                if (VerticalPosition() == menuLength)
                                {
                                    SetCursorPosition(0, 10);
                                    isExit = true;
                                    return;
                                }
                                Select(true);
                                //Exception handling here
                                MenuItem.SelectCommand(SelectedMenuItem());
                                while (Console.KeyAvailable)
                                {
                                    Console.ReadKey(true);
                                }
                                Select(false);
                            }
                            break;
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        private int VerticalPosition() { return currentPos.vertical - 2; }

        private MenuItems SelectedMenuItem()
        {
            return (MenuItems)Enum.GetValues(typeof(MenuItems)).GetValue(VerticalPosition());
        }

        private void MoveDown()
        {
            if (currentPos.vertical < menuLength + 2)
            {
                DrawX(previousPos, true);
                currentPos.vertical += 1;
            }
            DrawX(currentPos);
        }

        private void MoveUp()
        {
            if (2 < currentPos.vertical)
            {
                DrawX(previousPos, true);
                currentPos.vertical -= 1;
            }
            DrawX(currentPos);
        }

        private void Select(bool inProcess)
        {
            string processState = "          ";
            SetCursorPosition(30, currentPos.vertical);
            if (inProcess)
            {
                processState = "Processing";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", processState);
                SetCursorPosition(0, menuLength + 4);
            }
            else
            {
                Console.Write("{0}", processState);
                SetCursorPosition(currentPos);
            }

            Console.ResetColor();
        }

        private void DrawX(CursorPos position, bool delete = false)
        {
            char mark = 'X';
            if (delete) mark = ' ';

            SetCursorPosition(position);
            Console.Write("\r[{0}]", mark);
            SetCursorPosition(position);
        }

        private void SetCursorPosition(CursorPos position)
        {
            Console.SetCursorPosition(position.horizontal, position.vertical);
        }

        private void SetCursorPosition(int horizontal, int vertical)
        {
            Console.SetCursorPosition(horizontal, vertical);
        }

    }
}
