using System.Collections.Generic;

namespace MenuApp.BL
{
    public class Menu
    {
        private List<MenuItem> menuItems;

        public Menu()
        {
            menuItems = new List<MenuItem>();
        }

        public List<MenuItem> MenuItems { get => menuItems; }

        public void AddItem(string name)
        {
            menuItems.Add(new MenuItem(name));
        }

        public void RunCommand(int index)
        {
            menuItems[index].Run();
        }
    }
}
