using System.Collections.Generic;
using static Colorful.Console;

namespace Menu
{
    internal class Menus
    {
        private List<Menu> _menuList;
        private Menu _menu;
        private Menu _backup_menu;
        public Menus(List<Menu> menus)
        {
            _menuList = menus;
            _menu = _menuList[0];
        }
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