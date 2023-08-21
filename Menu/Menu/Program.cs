using System;
using System.Collections.Generic;
using System.Drawing;
using static Colorful.Console;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Option option0 = new Option("Play", Color.Orange);
            Option option1 = new Option("Settings", Color.Green);
            Option option2 = new Option("About", Color.Blue);
            Option option3 = new Option("Eh", Color.Cyan);
            Option option4 = new Option("Quit", "");
            List<Option> options0 = new List<Option>() { option0, option1, option2, option3, option4 };

            Menu mainMenu = new Menu("Main", Color.White, options0);
            
            option0 = new Option("Play.1", Color.Orange);
            option1 = new Option("Play.2", Color.Orange);
            option2 = new Option("Play.3", Color.Orange);
            option3 = new Option("Play.4", Color.Orange);
            option4 = new Option("Back", "Main");
            Option option5 = new Option("Quit", "");
            options0 = new List<Option>() { option0, option1, option2, option3, option4, option5 };

            Menu playMenu = new Menu("Play", Color.Orange, options0);

            option0 = new Option("Settings.1", Color.Green, new Action(() => Beep(100, 100)));
            option1 = new Option("Settings.2", Color.Green, new Action(() => Beep(500, 100)));
            option2 = new Option("Settings.3", Color.Green, new Action(() => Beep(750, 100)));
            option3 = new Option("Settings.4", Color.Green, new Action(() => Beep(1000, 100)));
            option4 = new Option("Back", "Main");
            option5 = new Option("Quit", "");
            options0 = new List<Option>() { option0, option1, option2, option3, option4, option5 };

            Menu settingsMenu = new Menu("Settings", Color.Green, options0);

            option0 = new Option("Nem lehet használni!", Color.Red);
            option1 = new Option("Back", "Main");
            option2 = new Option("Quit", "");
            options0 = new List<Option>() { option0, option1, option2 };

            Menu aboutMenu = new Menu("About", Color.Blue, options0);

            Menus menus = new Menus(new List<Menu>() { mainMenu, playMenu, settingsMenu, aboutMenu });
            menus.Run();
                        
            ReadKey();
        }
    }
}
