using System.Collections.Generic;
using static Colorful.Console;

namespace Menu
{
    /// <summary>
    /// Represents a Menus type with a list which contains menus.
    /// </summary>
    internal class Menus
    {
        private List<Menu> _menuList;
        private Menu _menu;
        private Menu _backup_menu;
        /// <summary>
        /// Creats a Menus 
        /// </summary>
        /// <param name="menus">A list of Menus.</param>
        public Menus(List<Menu> menus)
        {
            _menuList = menus;
            _menu = _menuList[0];
        }
        /// <summary>
        /// Runs through the list of Menu and their options.
        /// </summary>
        public void Run()
        {
            do
            {           
                if (_menu == null)
                {
                    _menu = _backup_menu;
                }     
                int s = _menu.Stepper();
                if (!_menu.Options[s].Has_action)
                {
                    _backup_menu = _menu;
                    WriteLine(_menu.Options[s].Name_into);
                    _menu = _menuList.Find(x => x.Name == _menu.Options[s].Name_into);
                }
                else
                {
                    _menu.Options[s].Action.Invoke();
                }
            } while (true);
        }
        internal List<Menu> MenuList { get => _menuList; set => _menuList = value; }
    }
}