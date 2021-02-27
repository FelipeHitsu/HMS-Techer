using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class ConsolePrint
    {
        public static void Print(string text, ConsoleColor textColor)
        {
            ConsoleColor defaultTextColor = Console.ForegroundColor;

            Console.ForegroundColor = textColor;

            Console.Write(text);

            Console.ForegroundColor = defaultTextColor;

        }
        public static void Print(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            ConsoleColor defaultTextColor = Console.ForegroundColor;
            ConsoleColor defaultBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;

            Console.Write(text);

            Console.ForegroundColor = defaultTextColor;
            Console.BackgroundColor = defaultBackgroundColor;
        }
    }
}
