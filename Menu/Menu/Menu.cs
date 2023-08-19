using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using static Colorful.Console;

namespace Menu
{
    internal class Menu
    {
        private int _depth = 0;
        private string _name;
        private Color _color;
        private Color _color_w_back;
        private static List<Menu> _children = new List<Menu>();
        private static int _child_index_selected = 0;
        private Task _task;
        private bool _has_task = false;
        public Menu(string name, Color color, List<Menu> children)
        {
            _name = name;
            _color = color;
            _children = children;
        }
        public Menu(string name, Color color, Task task)
        {
            _name = name;
            _color = color;
            _task = task;
            _has_task = true;
        }
        public Menu()
        {
            _name = "[]";
            _color = Color.White;
        }
        public Menu(bool mm)
        {
            if (mm)
            {
                _name = "Quit";
                _color = Color.Red;
                _task = new Task(() => Environment.Exit(0));
            }
            else
            {
                _name = "Back";
                _color = Color.Yellow;
            }
        }
        public void Addchild(Menu child)
        {
            _children.Add(child);
        }
        public void SetColor(Color color)
        {
            _color = color;
        }
        public void Update()
        {
            Clear();
            for (int i = 0; i < _children.Count; i++)
            {
                if (_child_index_selected == i)
                {
                    if (_children[_child_index_selected].Color.GetBrightness() <= 0.5)
                    {
                        _color_w_back = Color.White;
                        BackgroundColor = _children[_child_index_selected].Color;
                    }
                    else
                    {
                        BackgroundColor = _children[_child_index_selected].Color;
                        _color_w_back = Color.Black;
                    }
                    WriteLine(_children[i].Name, _children[i].Color_w_back);
                    BackgroundColor = Color.FromArgb(12, 12, 12);
                }
                else
                {
                    WriteLine(_children[i].Name, _children[i].Color);
                }
            }
        }
        public void Stepper(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                if (_child_index_selected == 0)
                {
                    _child_index_selected = _children.Count - 1;
                }
                else
                {
                    _child_index_selected--;
                }
            }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                if (_child_index_selected == _children.Count - 1)
                {
                    _child_index_selected = 0;
                }
                else
                {
                    _child_index_selected++;
                }
            }
            else if (key == ConsoleKey.Enter)
            {
                if (_children[_child_index_selected].Name == "Back")
                {
                    _depth--;
                }
            }
            Update();
        }
        public string Name { get => _name; }
        public Color Color { get => _color; set => _color = value; }
        internal List<Menu> Children { get => _children; }
        public Color Color_w_back { get => _color_w_back; }
        public bool Has_Task { get => _has_task; }
        public Task Task { get => _task; }
    }
}
