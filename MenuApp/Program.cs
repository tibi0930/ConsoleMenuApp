using System;
using System.Threading;

namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuLength = Enum.GetNames(typeof(MenuItems)).Length;
            int currentPos = 0;

            UI.DisplayMenu("MENU NAME");
            UI.DrawX(currentPos);

            bool isExit = false;
            while (!isExit)
            {
                keyCommand command = UI.ReadKey();

                switch (command)
                {
                    case keyCommand.Down:
                        if (currentPos < menuLength)
                        {
                            UI.DrawX(currentPos, true);
                            currentPos++;
                            UI.DrawX(currentPos);
                        }
                        break;
                    case keyCommand.Up:
                        if (0 < currentPos)
                        {
                            UI.DrawX(currentPos, true);
                            currentPos--;
                            UI.DrawX(currentPos);
                        }
                        break;
                    case keyCommand.Enter:
                        {
                            if (currentPos == menuLength)
                            {
                                isExit = true;
                                return;
                            }
                            UI.Select(currentPos, true);
                            UI.ClearResult(menuLength);

                            switch ((MenuItems)currentPos)
                                {
                                    case MenuItems.First:
                                        RunPercentage();
                                        break;
                                    case MenuItems.Second:
                                        RunPercentage();
                                        break;
                                    case MenuItems.Third:
                                        RunPercentage();
                                        break;
                                    default:
                                        RunPercentage();
                                        break;
                                }
                            UI.Select(currentPos, false);
                        }
                        break;
                }
            }
        }
        private static void RunPercentage()
        {
            UI.DisplayResult();
            for (int i = 0; i <= 5; ++i)
            {
                Thread.Sleep(1000);
                UI.DisplayPercentage(i);
            }
        }
    }
}
