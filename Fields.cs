using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_Objects
{
    public abstract class Fields
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
    public class Empty : Fields
    {
        public Empty()
        {
            Look = "E";
            Color = ConsoleColor.DarkGreen;
        }
    }
    public class FOO : Fields
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
            IsEnabled = true;
            Color = ConsoleColor.Cyan;
        }
    }
    public class Cavern : Fields
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
