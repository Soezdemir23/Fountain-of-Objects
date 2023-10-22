using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_Objects
{

    public abstract class TextColoring
    {
        protected ConsoleColor Color { get; set; }
    }

    public class NarrativeText: TextColoring
    {
        public NarrativeText() => Color = ConsoleColor.Magenta;

       
    }

    public class DescriptiveText: TextColoring
    {
        public DescriptiveText() => Color = ConsoleColor.White;
    }

    public class InputText: TextColoring
    {
        private string _input = "";
        public InputText() => Color = ConsoleColor.Yellow;
    
        public void SetInput()
        {
            //I could and maybe should have put this part in NarrativeText.
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("What do you want to do? ");
            Console.ResetColor();
            //this is the important part to get the text
            Console.ForegroundColor = Color;
            _input = Console.ReadLine();
            Console.ResetColor();
        }

        public string GetInput() => _input;
    }


    public class EntranceText: TextColoring
    {
        public EntranceText() => Color = ConsoleColor.Yellow;
    
        public void Entrance()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You see light coming from the cavern entrance.");
            Console.ResetColor();
        }
    }

    public class FountainText: TextColoring
    {
        
        public FountainText() => Color = ConsoleColor.Cyan;
    
        public void FountainDisabled()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You hear water dripping in this room.");
            Console.WriteLine("The Fountain of Objects is here!");
            Console.ResetColor();
        }

        public void FountainEnabled()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You hear the rushing waters from the Fountain of Objects.");            
            Console.WriteLine("It has been reactivated!");
            Console.ResetColor();
        }
    }

    
}
