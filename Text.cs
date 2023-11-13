namespace Fountain_of_Objects
{
    /// <summary>
    /// Parent class Textcoloring, just assign the color of the Console characters.
    /// </summary>
    public abstract class TextColoring
    {
        protected ConsoleColor Color { get; set; }
    }

    /// <summary>
    /// Self explanatory Narrativetext, that explains what's happening and the intros and game overs.
    /// ConsoleColor is Magenta
    /// </summary>
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

        internal void GetInvalidMovementText()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You tried to move, but couldn't");
            Console.WriteLine("You have to focus on what you have to do");
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
            Console.ForegroundColor = Color;
            Console.WriteLine("It is too quiet, you might be near a pit.");
            Console.ResetColor();
        }

        internal void GetFallingIntoPitText()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
                "You fell into the pit and before you knew it, you splatted onto the ground"
            );
            Console.WriteLine(
                "There were not enough Hero corpses fillin the pit to cushion your fall"
            );
            Console.WriteLine("You died");
            Console.ResetColor();
        }

        internal void GetMaelstormGust()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You entered the room with the ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Maelstorm");
            Console.ForegroundColor = Color;
            Console.WriteLine("The ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Maelstorm");

            Console.ForegroundColor = Color;
            Console.WriteLine(" anticipated you and sucked you into it's eye");
            Console.WriteLine("Like an upwards inverse Tornado it spit you up to the north of you");
            Console.WriteLine("The Storm has moved the opposition direction to hide from you");
            Console.ResetColor();
        }

        internal void GetMaelstormIsNearText()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
                "You feel the cold wind, but there is never been Wind recorded in the Caverns!"
            );
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Maelstorms");
            Console.ForegroundColor = Color;
            Console.WriteLine(" are near!");
            Console.ResetColor();
        }

        internal void GetAmarokIsNearText()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
                "You hear the cacophony of pained voices, snarls, shouts in disharmony"
            );
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Amarok");
            Console.ForegroundColor = Color;
            Console.WriteLine(" are looking for another victim to add to their mass of flesh.");
            Console.ResetColor();
        }

        internal void GetAmarokIsBlownAway(){
            Console.ForegroundColor = Color;
            Console.Write("An ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Amarok");
            Console.ForegroundColor = Color;
            Console.Write(" is being pulled in and spit by a");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Amarok.");
            Console.ResetColor();
        }

        internal void GetAmarokFallingIntoPit(){
            Console.ForegroundColor = Color;
            Console.WriteLine("You hear a distant symphony of confused screaming");
            Console.WriteLine("You hear a loud 'SPLAT' within one of the pits");
            Console.ResetColor();
        }

        internal void GetPlayerGetsEatenByAmaroks(){
            Console.ForegroundColor = Color;
            Console.WriteLine("As you entered the same room as the Amarok, a primal fear has shook you from within!");
            Console.WriteLine("While it walked on 4 legs like a carnivore, that was the only thing that resembled a dog or wolf");
            Console.WriteLine("Mouths where they shouldn't be.");
            Console.WriteLine("Teeth where they shouldn't be.");
            Console.WriteLine("Voices that shouldn't be");
            Console.WriteLine("Faces that shouldn't be.");
            Console.WriteLine("One of the Amarok's faces saw you, and the whole creature directed it's focus on your paralyzed self");
            Console.WriteLine("It started running towards you, faster than what you hunted before.");
            Console.WriteLine("The faces gave away to a maw that opened itself so wide, you could see the beating insides of the creature.");
            Console.WriteLine("Bones and spines, teeth like structures grew from the inside as it jumped on you and seperated your upper body from the reste with a crunch");
            Console.WriteLine("You died, becoming one of the many faces of the amarok, roaming the caverns.");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Descriptive Text is all about Describing important events like where the player is.
    /// White color
    /// </summary>
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

    /// <summary>
    /// InputText is all about the input the player enters
    /// The text is yellow
    /// </summary>
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

    /// <summary>
    /// CavernText is written with yellow color
    /// </summary>
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

    /// <summary>
    /// The FountainColor Text
    /// </summary>
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
