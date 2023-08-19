using System;
using System.Collections.Generic;
using static Colorful.Console;

namespace Menu
{
    internal class Menus
    {
        private List<Menu> _menus;
        private int _current_depth = 0;
        public Menus(List<Menu> menus)
        {
            _menus = menus;
        }
        public void AddMenu(Menu menu)
        {
            _menus.Add(menu);
        }
        public void Step()
        {
            Menu menu = _menus[_current_depth];
            menu.Update();
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                if (menu.Has_Task)
                {
                    menu.Task.Start();
                }
                else
                {
                    _current_depth++;
                }
            }
            else
            {
                menu.Stepper(key);
            }
        }
        public int Current_depth { get => _current_depth; }
        internal List<Menu> Menus_ { get => _menus; }
    }
}
