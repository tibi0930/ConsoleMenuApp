using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MenuApp
{
    public enum MenuItems
    {
        [Description("Menu Item 1.")]
        First,
        [Description("Menu Item 2.")]
        Second,
        [Description("Menu Item 3.")]
        Third
    }
    public static class MenuItem
    {
        public static void SelectCommand(MenuItems selectedMenuItem)
        {
            switch (selectedMenuItem)
            {
                case MenuItems.First:
                    WritePercentage.Run();
                    break;
                case MenuItems.Second:
                    WritePercentage.Run();
                    break;
                case MenuItems.Third:
                    WritePercentage.Run();
                    break;
                default:
                    WritePercentage.Run();
                    break;
            }
        }

        public static string GetValueAsString(this MenuItems environment)
        {
            // get the field 
            var field = environment.GetType().GetField(environment.ToString());
            var customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (customAttributes.Length > 0)
            {
                return (customAttributes[0] as DescriptionAttribute).Description;
            }
            else
            {
                return environment.ToString();
            }
        }
    }
    
}
