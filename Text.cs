using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_Objects
{
    public abstract class TextColoring
    {
        protected ConsoleColor Color { get; set; }
    }

    public class NarrativeText : TextColoring
    {
        public NarrativeText() => Color = ConsoleColor.Magenta;

        public void Intro()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You entered the Caverns to find the Fountain of Objects.");
            Thread.Sleep(1000);
            Console.WriteLine("Find it.");
            Thread.Sleep(400);
            Console.WriteLine("Activate it");
            Thread.Sleep(400);
            Console.WriteLine("Leave the Caverns");
            Thread.Sleep(800);
            Console.WriteLine("Alive");
            Console.ResetColor();
        }

        public void End()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You were able to leave the caverns.");
            Console.WriteLine(
                "While they celebrated your return, it was immediately clear that they were gonna dispose and forget about your deeds."
            );
            Console.WriteLine("Soon, you were to be sacrificed and forgotten.");
            Console.WriteLine(
                "Oh, how their expressions changed when you brought the caverns with you and unleashed it upon them."
            );
            Console.WriteLine(
                "Their comatose existence of blind expectations, sending you down to the cavern so they could go back to sleep for another day on the mattress of corpses."
            );
            Console.WriteLine(
                "Why burn down the village when they expelled you to go sacrifice yourself for them to feel the warmth, if you can bath in their blood and guts instead?"
            );
            Console.WriteLine("\nThis time, you really won and you stayed alive.");
        }

        internal void GetInvalidInputText(string input)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You were delirious and didn't know what you thought.");
            Console.WriteLine("I, the narrator, have noted down what you tried: " + input);
            Console.WriteLine("You are still in the same room.");
            Console.ResetColor();
        }

        internal void GetInvalidInputBounds(string input)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You tried to push towards " + input.Substring(input.IndexOf(" ")));
            Console.WriteLine("However, the wall doesn't budge despite your best efforts");
            Console.ResetColor();
        }

        internal void GetInvalidInputEnableFountain()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You tried enabling the fountain");
            Console.WriteLine("However, the fountain is already enabled");
            Console.ResetColor();
        }

        internal void GetInvalidInputDisableFountain()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You tried disabling the fountain");
            Console.WriteLine("However, the fountain is already disabled");
            Console.ResetColor();
        }

        internal void GetInvalidInputOutsideFountain()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
                "You tried to interact with the fountain from outside the fountain room"
            );
            Console.WriteLine(
                "However, you can only enable or disable the fountain from inside the fountain room"
            );
            Console.ResetColor();
        }

        internal void GetLeaveCavernEnabledFountain()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You left the caverns.");
            Console.WriteLine("You were able to activate the Fountain of Objects.");
            Console.WriteLine("You won!");
            Console.WriteLine("You left a changed man, a shell of what you used to be.");
            Console.ResetColor();
        }

        internal void GetLeaveCavernDisabledFountain()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You left the caverns.");
            Console.WriteLine("You were not able to activate the Fountain of Objects.");
            Console.WriteLine("You lose");
            Console.ResetColor();
        }

        internal void GetInvalidInputInteractionCavern()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You tried to leave the cavern");
            Console.WriteLine("However, you can only leave it if you are back in the entrance.");
            Console.ResetColor();
        }

        internal void GetInvalidInteractionFountain()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You tried to interact with the fountain");
            Console.WriteLine("However, you have to interact directly with it.");
            Console.ResetColor();
        }

        internal void GetPitIsNearText()
        {
            Console.ForegroundColor= Color;
            Console.WriteLine("It is too quiet, you might be near a pit.");
            Console.ResetColor();
        }

        internal void GetFallingIntoPitText()
        {
            Console.ForegroundColor= Color;
            Console.WriteLine("You fell into the pit and before you knew it, you splatted onto the ground");
            Console.WriteLine("There were not enough Hero corpses fillin the pit to cushion your fall");
            Console.WriteLine("You died");
            Console.ResetColor();

        }
    }

    public class DescriptiveText : TextColoring
    {
        public DescriptiveText() => Color = ConsoleColor.White;

        public void WhereAbout((int, int) Position)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
                $"You are in the room at (Row={Position.Item1}, Column={Position.Item2})."
            );
            Console.ResetColor();
        }
    }

    public class InputText : TextColoring
    {
        public InputText() => Color = ConsoleColor.Yellow;

        public string GetInput()
        {
            //I could and maybe should have put this part in NarrativeText.
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("What do you want to do? ");
            Console.ResetColor();
            //this is the important part to get the text
            Console.ForegroundColor = Color;
            var input = Console.ReadLine();
            Console.ResetColor();

            return input;
        }
    }

    public class CavernText : TextColoring
    {
        public CavernText() => Color = ConsoleColor.Yellow;

        public void Entrance()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You see light coming from the cavern entrance.");
            Console.ResetColor();
        }
    }

    public class FountainText : TextColoring
    {
        public FountainText() => Color = ConsoleColor.Cyan;

        public void FountainDisabled()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You hear the rushing water getting less");
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

        internal void FountainFoundDisabled()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You hear water dripping in this room.");
            Console.WriteLine("The Fountain of Objects is here!");
            Console.ResetColor();
        }

        internal void FountainFoundEnabled()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You hear the rushing waters from the Fountain of Objects.");
            Console.WriteLine("It has been reactivated!");
            Console.ResetColor();
        }
    }
}
