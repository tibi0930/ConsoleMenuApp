using System;
using MenuApp.BL;

namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.AddItem("Menu Item 1.");
            menu.AddItem("Menu Item 2.");
            menu.AddItem("Menu Item 3.");

            var terminal = new Terminal("Menu name", menu);
            terminal.Run();
        }
    }
}
