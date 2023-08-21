using System;
using System.Drawing;

namespace Menu
{
    internal class Option
    {
        private string _name;
        private Color _color;
        private string _name_into;
        private Action _action;
        private bool _has_action = false;
        public Option(string name, string name_into)
        {
            if (name == "Quit")
            {
                _name = name;
                _color = Color.Red;
                _action = new Action(() => Environment.Exit(0));
                _has_action = true;
            }
            else if (name == "Back")
            {
                _name = name;
                _color = Color.Yellow;
                _name_into = name_into;
            }
            else
            {
                throw new ArgumentException("Can not make option, because invalid \"name\".");
            }
        }
        public Option(string name, Color color)
        {
            _name = name;
            _name_into = _name;
            _color = color;
        }
        public Option(string name, Color color, Action action)
        {
            _name = name;
            _color = color;
            _action = action;
            _has_action = true;
        }
        public string Name { get => _name; }
        public Color Color { get => _color; }
        public string Name_into { get => _name_into; }
        public Action Action { get => _action; }
        public bool Has_action { get => _has_action; }
    }
}