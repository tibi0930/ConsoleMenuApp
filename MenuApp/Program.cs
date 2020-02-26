using MenuApp.BL;
using System;

namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Auxiliary.myHandler);

            var menu = new Menu();
            menu.AddItem("Menu Item 1.");
            menu.AddItem("Menu Item 2.");
            menu.AddItem("Menu Item 3.");

            var terminal = new Terminal("MENU NAME", menu);
            terminal.Run();

        }
    }
}
