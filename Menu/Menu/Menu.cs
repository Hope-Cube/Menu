using System;
using System.Collections.Generic;
using System.Drawing;
using static Colorful.Console;

namespace Menu
{
    /// <summary>
    /// Represents a Menu with a title, color, and options.
    /// </summary>
    internal class Menu
    {
        private string _name;
        private Color _color;
        private List<Option> _options;
        private int _selected = 0;

        /// <summary>
        /// Creats a Menu with 3 parameters.
        /// </summary>
        /// <param name="name">The Menu's title.</param>
        /// <param name="color">The Menu's title's color.</param>
        /// <param name="options">A options list which contains Menu's options.</param>
        public Menu(string name, Color color, List<Option> options)
        {
            _name = name;
            _color = color;
            _options = options;
        }
        /// <summary>
        /// Updates/Writes out the Menu.
        /// </summary>
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
        /// <summary>
        /// Steps through the options with up/down arrows and/or w/s.
        /// </summary>
        /// <returns>The selected option's index.</returns>
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