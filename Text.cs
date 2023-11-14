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
            Console.WriteLine($"You never wanted to enter the caverns.");
            Console.WriteLine($"You never cared for the continuation of the tribe of witches.");
            Console.WriteLine($"They celebrated, celebrated decadently while they literally forced you into the caverns after what they did to you, to them.");
            Console.WriteLine($"You were the only one strong enough to survive the gauntlet and just barely capable enough to survive the tests.");
            Console.WriteLine($"Your father and male friends weren't there to see you off into the caverns.");
            Console.WriteLine($"They were summarily executed, to break and mold you into a utility.");
            Console.WriteLine($"And if they didn't get their head seperated from the neck down,");
            Console.WriteLine($"they were forced to fight you under the influence of drugs, gaslighting, torture and died to give you their strength.");
            Console.WriteLine($"Much to the decadent delight of the witches that assured you with condescending smiles, that they had no choice and it was the law.");
            Console.WriteLine($"You and your sacrificed brethern were given birth for that reason alone, to find the Fountain of Life that once gave life to the outerworld.");
            Console.WriteLine($"They gave you Shatter Arrows and a Bow that could withstand your strength.");
            Console.WriteLine($"Not for your safety and return, but for the profit you are gonna bring to them.");
            Console.WriteLine($"They shoved you into the cavern with spears, wouldn't mind killing you here and now just to birth new men to throw into the mawing pits.");
            Console.WriteLine($"You immediately walked down the Cavern to get it over with and find:" );
            
            Thread.Sleep(2000);
            Console.WriteLine($"The Fountain");
            
            
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
                "While they celebrated your return, it was clear as day that you were to be excommunicated or be sacrificed to the gods."
            );
            Console.WriteLine($"Or whatever reason they could think of to justify their nature.");
            
                Console.WriteLine($"So they can sleep soundly. Just for one moment longer in ignorant, arrogant bliss");
            Console.WriteLine($"After all, that was the sole purpose of your existence. So they could go back to normal.");
            Console.WriteLine("However, when you entered the Caverns you saw so much and went through so many worse trials, that you lost your mental chains that put you down.");
            Console.WriteLine($"And as you emerged back alive from the depths, you gained the will and the power to be your own master.");
            Console.WriteLine($"You wanted to live, when you were in danger. However, here you wished you were dead.");
            Console.WriteLine($"'One last trick', you thought to yourself and leaned back to a backalley's shadow.");
            Console.WriteLine($"Just like that, you vanished from everybody's eyes and from their minds.");
            Console.WriteLine($"You left the tribe and ventured outside into the wilderness.");
            Console.WriteLine($"Making the tribe bereft of a heroic sacrifice to their gods");
            Console.WriteLine($"After all, your life is your own to sacrifice and to live.");
            Console.WriteLine();

            Thread.Sleep(1000);
            Console.WriteLine("A few years later");
            Thread.Sleep(3000);
            Console.WriteLine("You were in a small fort city, in a bar drinking a malt when the news reached your holey ears from selling your services.");
            Console.WriteLine("The tribe that you came from got swallowed by the caverns. You just drank your keg, amused.");
            Console.WriteLine("'A little trick' was all it took for you to exact revenge and all it took was time and distance.");
            Console.WriteLine("You knew your male ancestors smiled on you. And you couldn't care less about the witches.");
            Console.WriteLine($"Their times were over and with the fountain that you left stronger than ever, a new, brighter age began.");
            Thread.Sleep(3000);
            Console.WriteLine($"The age of men.");
            Thread.Sleep(2000);
            Console.WriteLine($"The End");
            
        }

        internal void GetInvalidInputText(string input)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You were confused and tripped a bit, but then catched yourself.");
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
            Console.WriteLine($"You tried to push towards {input.Substring(input.IndexOf(" "))}");
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

        internal void GetAmarokIsBlownAway()
        {
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

        internal void GetAmarokFallingIntoPit()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You hear a distant symphony of confused screaming");
            Console.WriteLine("You hear a loud 'SPLAT' within one of the pits");
            Console.ResetColor();
            
        }

        internal void GetPlayerGetsEatenByAmaroks()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
                "As you entered the same room as the Amarok, a primal fear has shook you from within!"
            );
            Console.WriteLine(
                "While it walked on 4 legs like a carnivore, that was the only thing that resembled a dog or wolf"
            );
            Console.WriteLine("Mouths where they shouldn't be.");
            Console.WriteLine("Teeth where they shouldn't be.");
            Console.WriteLine("Voices that shouldn't be");
            Console.WriteLine("Faces that shouldn't be.");
            Console.WriteLine(
                "One of the Amarok's faces saw you, and the whole creature directed it's focus on your paralyzed self"
            );
            Console.WriteLine(
                "It started running towards you, faster than what you hunted before."
            );
            Console.WriteLine(
                "The faces gave away to a maw that opened itself so wide, you could see the beating insides of the creature."
            );
            Console.WriteLine(
                "Bones and spines, teeth like structures grew from the inside as it jumped on you and seperated your upper body from the reste with a crunch"
            );
            Console.WriteLine(
                "You died, becoming one of the many faces of the amarok, roaming the caverns."
            );
            Console.ResetColor();
        }


        internal string? WhereToShoot(){
            
            while(true){

                Console.ForegroundColor = Color;
                Console.WriteLine("In which direction are you aiming your bow at?");
                Console.WriteLine("north");
                Console.WriteLine("west");
                Console.WriteLine("east");
                Console.WriteLine("south");
                Console.WriteLine("cancel");
                Console.ForegroundColor = ConsoleColor.Yellow;
                var result = Console.ReadLine();
                if (result == "cancel" || result == "north"|| result == "west" || result == "east" || result == "south")
                {
                    return result;
                }
                Console.ForegroundColor = Color;
                Console.WriteLine("You entered something wrong. If you wanted to exit, just type cancel.");
            }
        }

        internal void GetAmarokGotShot()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("You pulled the arrow out of your arrow sheath and readied your bow.");
            Console.WriteLine("As you pulled your bow, the distant Amarok recognized you");
            Console.WriteLine($"It started to run to your direction, not understanding that you will end its suffering");
            Console.WriteLine($"You shot the arrow and it landed on it, piercing through the cancer ridden flesh");
            Console.WriteLine($"Blood sprayed around and it fell dead with a whine of relief");
            Console.ResetColor();
        }

        internal void GetShotMissed()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"You missed the shot and winced as it made a loud 'CLINK.");
            Console.WriteLine($"You KNOW the arrow is broken AND made a loud sound that might have alerted somebody.");
            Console.WriteLine($"You hope it was not heard.");
            Console.ResetColor();
        }

        internal void GetCancelled()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"You decided it was not the right time to draw the arrow and continued to survey your surroundings.");
            Console.ResetColor();
        }

        internal void GetNoArrows()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"You have no arrows left!");
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

        public void WhereAbout((int, int) Position, Player player)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
                $"You are in the room at (Row={Position.Item1}, Column={Position.Item2})."
            );
            Console.WriteLine($"You have {player.GetArrows()} Arrows left");
            
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

    public class SpecialText : TextColoring
    {
       public SpecialText() => Color = ConsoleColor.Blue;


       internal void GetHelp(){
        Console.ForegroundColor = Color;
        Console.WriteLine("CHILD!");
        Console.WriteLine("DON'T FALTER! DON'T GIVE UP EVEN IF YOU ARE DUST!");
        Console.WriteLine($"DON'T LET THESE CACKLING WITCHES RETURN YOU TO US TOO EARLY.");
        Console.WriteLine("EVEN IF WE ARE NOTHING BUT SPIRIT PRISONERS OF THE CAVERN, WE SHALL GUIDE YOU!");
        Console.WriteLine($"");
        Console.WriteLine($"HEED OUR WARNING! IN THE CAVERNS, THOUGHTS FOLLOW ACTIONS.");
        Console.WriteLine($"HOWEVER, WORDS WITH NO MEANING WILL BE YOUR DEMISE!");
        Console.WriteLine($"");
        Console.WriteLine($"IF YOU WISH TO MOVE, THINK OF THESE SENTENCES:");
        

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"");
        Console.WriteLine($"move north");
        Console.WriteLine($"move south");
        Console.WriteLine($"move west");
        Console.WriteLine($"move east");
        Console.WriteLine($"");
        Console.ForegroundColor = Color;
    
        Console.WriteLine($"WE SENSE SHATTER, YOU CARRY A BOW! ALLOW US TO GUIDE YOU HERE TOO:");
        Console.WriteLine($"BEFORE YOU SHOOT, YOU HAVE TO MANIFEST THE WORDS IN YOUR THOUGHTS:");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"");
        Console.WriteLine($"shoot arrow");
        Console.WriteLine($"");
        Console.ForegroundColor = Color;
        
        Console.WriteLine("AFTER MANIFESTING THE THOUGHT, MANIFEST WHERE TO SHOOT:");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"");
        Console.WriteLine($"north");
        Console.WriteLine($"west");
        Console.WriteLine($"east");
        Console.WriteLine($"south");
        Console.WriteLine($"");
        Console.ForegroundColor = Color;
    
        Console.WriteLine($"THAT IS NOT ALL! REMEMBER, YOU CAN'T ACTIVATE THE FOUNTAIN IF YOU DON'T WILL IT!");
        Console.WriteLine($"THE SAME GOES FOR DISABLING AND LEAVING THE CAVERN!");
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"");
        Console.WriteLine($"enable fountain");
        Console.WriteLine($"disable fountain");
        Console.WriteLine($"leave cavern");
        Console.WriteLine($"");
        Console.ForegroundColor = Color;

        Console.WriteLine($"HOW YOU HANDLE THINGS IS YOUR DECISION, DANGER BEGETS FREEDOM IN THE CAVERNS!");
        Console.WriteLine($"YOU ARE NO BORN PRISONER HERE, BUT YOU ARE ALSO NOT SAFE!");
        Console.WriteLine($"BEWARE OF (P)ITS! DON'T FALL INTO THEM!");
        Console.WriteLine($"(M)AELSTORM ARE NOT NECESSARILY ENEMIES, YET COULD KILL YOU IF THEY BLOW YOU INTO A PIT!");
        Console.WriteLine($"BEWARE OF THE (Å)MAROK! FOR THEY ARE THE REMNANTS OF OUR ENTWINED AND CONTORTED FLESH CURSED TO AIMLESSLY WANDER.");
        Console.WriteLine($"AVOID THEIR DIRECT GAZE, FOR YOUR BODY WILL BE PARALYZED BY FEAR AND YOU WILL JOIN US AND THEM!");
        Console.WriteLine($"");

        Console.WriteLine($"SURVIVE AND LEAVE ALIVE BOY! DON'T BECOME ONE OF US AND HOPE THE WITCHES WILL BE MERCIFUL.");
        Console.ResetColor(); 
        
        
        
        
        
        
        

        
        
        

        
        

        
        
        
        
        

        
        
        
        
        
        
        
        
        
        
        
       }
    }
}
