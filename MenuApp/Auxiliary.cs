using System;

namespace MenuApp
{
    public static class Auxiliary
    {
        public static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.SetCursorPosition(0, 10);
            System.Environment.Exit(0);
        }
    }
}
