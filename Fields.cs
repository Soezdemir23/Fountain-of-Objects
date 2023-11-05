using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_Objects
{
    public abstract class Field
    {
        protected string Look { get; set; }
        protected ConsoleColor Color { get; set; }

        public void GetLook()
        {
            Console.ForegroundColor = Color;
            Console.Write(Look);
            Console.ResetColor();
        }
    }

    public class Empty : Field
    {
        public Empty()
        {
            Look = "E";
            Color = ConsoleColor.DarkGreen;
        }
    }

    public class FOO : Field
    {
        public bool isFound { get; set; }
        public bool IsEnabled { get; set; }

        public FOO()
        {
            Look = "F";
            Color = ConsoleColor.Green;
            IsEnabled = false;
        }

        public void SetEnabled()
        {
            
            if (IsEnabled == false)
            {
            IsEnabled = true;
            Color = ConsoleColor.Cyan;
            }else
            {
                IsEnabled = false;
                Color = ConsoleColor.Green;
            }
        }

        public bool GetEnabled()
        {
            return IsEnabled;
        }
    }

    public class Cavern : Field
    {
        public bool IsEnabled { get; set; }

        public Cavern()
        {
            Look = "C";
            Color = ConsoleColor.DarkGray;
            IsEnabled = false;
        }

        public void SetEnabled()
        {
            IsEnabled = true;
            Color = ConsoleColor.Gray;
        }
    }
}
