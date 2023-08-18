using System;
using System.Collections.Generic;
using System.Drawing;
using static Colorful.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Menu
    {
        private string _name;
        private Color _color;
        private static List<Menu> _children = new List<Menu>();
        private static int _child_index_selected;
        public Menu(string name, Color color, List<Menu> children)
        {
            _name = name;
            _color = color;
            _children = children;
        }
        public Menu()
        {
            _name = "[]";
            _color = Color.White;
        }
        public void Addchild(Menu child)
        {
            _children.Add(child);
        }
        public void SetColor(Color color)
        {
            _color = color;
        }
        static void Update()
        {
            for (int i = 0; i < _children.Count; i++)
            {
                if (_child_index_selected == i)
                {
                    if (_children[_child_index_selected].Color.GetBrightness() <= 0.5)
                    {

                    }
                    else
                    {
                        WriteLine(menu.Name, menu.Color);
                    }
                }
            }
        }
        public void Stepper(ConsoleKey key)
        {
            Update();
        }
        public void Enter()
        {

        }
        public string Name { get => _name; }
        public Color Color { get => _color; set => _color = value; }
        internal List<Menu> Children { get => _children; }
    }
}
