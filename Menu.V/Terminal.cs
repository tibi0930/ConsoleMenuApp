using System;
using System.Collections.Generic;
using System.Text;
using MenuApp.BL;

namespace MenuApp
{
    internal class Terminal
    {
        private string title;
        public string Title 
        { 
            get
            {
                return $"*************{title}*************\n";
            }
        }
        private Menu menu;
        public Terminal(string title, Menu menu)
        {
            this.title = title;
            this.menu = menu;
        }

        public void Run()
        {
            Console.Write(Title);
            foreach (var item in menu.MenuItems)
            {
                Console.WriteLine($"[ ]{item.Name}");
            }
            Console.WriteLine("[ ]Exit");
        }
    }
}
