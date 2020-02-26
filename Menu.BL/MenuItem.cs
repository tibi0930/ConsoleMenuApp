namespace MenuApp.BL
{
    public class MenuItem
    {
        public string Name { get; }

        public MenuItem(string name)
        {
            Name = name;
        }

        public virtual void Run()
        {
            
        }
    }
}