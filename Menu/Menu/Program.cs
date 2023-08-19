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
            System.Console.CursorVisible = false;
            CursorVisible = false;
            List<Menu> menulist = new List<Menu>();
            menulist.Add(new Menu("01", Color.White, new List<Menu>() { new Menu("1.1", Color.White, new List<Menu>()), new Menu("1.2", Color.White, new List<Menu>()), new Menu(false)}));
            menulist.Add(new Menu("02", Color.White, new List<Menu>() { new Menu("2.1", Color.White, new List<Menu>()), new Menu("2.2", Color.White, new List<Menu>()), new Menu(false)}));
            menulist.Add(new Menu("03", Color.White, new List<Menu>() { new Menu("3.1", Color.White, new List<Menu>()), new Menu("3.2", Color.White, new List<Menu>()), new Menu(false)}));
            menulist.Add(new Menu(true));
            //Menu menu = new Menu("Main", Color.FromArgb(0,255,255), menulist);
            //menu.Update();
            //while (true)
            //{
            //    ConsoleKey key = ReadKey(true).Key;
            //    menu.Stepper(key);
            //}
            Menus menus = new Menus(menulist);
            while (true)
            {
                menus.Step();
            }
        }
    }
}
