using MenuApp.BL;
using System;
using System.Threading;

namespace MenuApp
{
    internal class Terminal
    {
        private string title;
        private Menu menu;
        private Tick x;

        public Terminal(string title, Menu menu)
        {
            this.title = title;
            this.menu = menu;
            Console.Title = title;
        }

        public void Run()
        {
            Console.WriteLine($"*************{title}*************\n");
            foreach (var item in menu.MenuItems)
            {
                Console.WriteLine($"[ ]{item.Name}");
            }
            Console.WriteLine("[ ]Exit");
            RunX();
        }

        private void RunX()
        {
            x = new Tick(menu.MenuItems.Count);

            bool isExit = false;
            while (!isExit)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            x.MoveDown();
                            break;
                        case ConsoleKey.UpArrow:
                            x.MoveUp();
                            break;
                        case ConsoleKey.Enter:
                            {
                                if (x.VerticalPosition == menu.MenuItems.Count)
                                {
                                    Console.SetCursorPosition(0, 10);
                                    isExit = true;
                                    return;
                                }
                                x.Select(true);
                                menu.RunCommand(x.VerticalPosition);
                                while (Console.KeyAvailable)
                                {
                                    Console.ReadKey(true);
                                }
                                x.Select(false);
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


    }
}
