using System;

namespace MenuApp
{
    internal struct CursorPos
    {
        public int horizontal;
        public int vertical;
    }
    public class Tick
    {
        private CursorPos currentPos;
        private CursorPos previousPos;
        private int menuLength;

        public Tick(int menuLength)
        {
            this.menuLength = menuLength;
            currentPos = new CursorPos();
            currentPos.horizontal = 1;
            currentPos.vertical = 2;
            previousPos = currentPos;
            DrawX(currentPos);
        }

        public int VerticalPosition { get => currentPos.vertical - 2; }

        public void MoveDown()
        {
            if (currentPos.vertical < menuLength + 2)
            {
                DrawX(previousPos, true);
                currentPos.vertical += 1;
            }
            DrawX(currentPos);
        }

        public void MoveUp()
        {
            if (2 < currentPos.vertical)
            {
                DrawX(previousPos, true);
                currentPos.vertical -= 1;
            }
            DrawX(currentPos);
        }

        public void Select(bool inProcess)
        {
            string processState = "          ";
            if (inProcess)
            {
                processState = "Processing";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\r[X]\t\t\t{0}\n", processState);
                SetCursorPosition(0, menuLength + 4);
                Console.Write(new string(' ', Console.WindowWidth));
                SetCursorPosition(0, Console.CursorTop);
            }
            else
            {
                SetCursorPosition(currentPos);
                Console.Write("\r[X]\t\t\t{0}\n", processState);
                SetCursorPosition(currentPos);
            }

            Console.ResetColor();
        }

        private void DrawX(CursorPos position, bool delete = false)
        {
            char mark = 'X';
            if (delete) mark = ' ';

            SetCursorPosition(position);
            Console.Write("\r[{0}]\t\t\t\n", mark);
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
