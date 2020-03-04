using System;
using System.Threading;

namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.DisplayMenu("MENU NAME");

            while (!UI.IsExit)
            {
                keyCommand command = UI.ReadKey();

                switch (command)
                {
                    case keyCommand.Down:
                        UI.MoveDown();
                        break;
                    case keyCommand.Up:
                        UI.MoveUp();
                        break;
                    case keyCommand.Enter:
                        {
                            UI.Enter();
                            switch (UI.GetCurrentElement())
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
                            UI.ProcessFinished();
                        }
                        break;
                }
            }
            UI.ExitMenu();
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
