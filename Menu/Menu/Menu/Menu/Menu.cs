using System;
using System.Collections.Generic;
using System.Drawing;
using static Colorful.Console;

namespace Menu
{
    internal class Menu
    {
        private string _name;
        private Color _color;
        private List<Option> _options;
        private int _selected = 0;
        public Menu(string name, Color color, List<Option> options)
        {
            _name = name;
            _color = color;
            _options = options;
        }
        public void Update()
        {
            Clear();
            WriteLine(Name + "\n", Color);
            for (int i = 0; i < Options.Count; i++)
            {
                if (i != Selected)
                {
                    WriteLine("  " + Options[i].Name, Options[i].Color);
                }
                else
                {
                    Color bc = Options[i].Color;
                    Color fc;
                    if (Color.GetBrightness() <= 0.5)
                    {
                        fc = Color.White;
                    }
                    else
                    {
                        fc= Color.Black;
                    }
                    BackgroundColor = bc;
                    WriteLine(Options[i].Name, fc);
                    BackgroundColor = Color.FromArgb(12, 12, 12);
                }                
            }
        }
        public int Stepper()
        {
            ConsoleKey key;
            do
            {
                Update();
                key = ReadKey().Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    if (Selected == 0)
                    {
                        _selected = Options.Count - 1;
                    }
                    else
                    {
                        _selected--;
                    }
                }
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    if (Selected == Options.Count - 1)
                    {
                        _selected = 0;
                    }
                    else
                    {
                        _selected++;
                    }
                }
            } while (key != ConsoleKey.Enter);
            return Selected;
        }
        public string Name { get => _name; }
        public Color Color { get => _color; }
        public int Selected { get => _selected; }
        internal List<Option> Options { get => _options; }
    }
}