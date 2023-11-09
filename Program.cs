// See https://aka.ms/new-console-template for more information
using Fountain_of_Objects;

//Should I first prototype the logic on the main method?


Player player = new();
Field[,] fields = new Field[4, 4];

static void FillBoard(Field[,] fields, int squareSize)
{
    for (int i = 0; i < squareSize; i++)
    {
        for (int k = 0; k < squareSize; k++)
        {
            if (i == 0 && k == 0) // can stay like this
            {
                fields[i, k] = new Cavern();
            }
            else if (i == 0 && k == squareSize / 2) // so basically s=> 0,2 m=> 0,3 l=> 0,4
            {
                fields[i, k] = new FOO();
            }
            else
            {
                fields[i, k] = new Empty();
            }
        }
    }

    // 1,2,4 and the squares are 4,6,8
    if (squareSize == 4)
    {
        fields[1,1] = new Pit();
        fields[2,3] = new Pit();
    }
    else if (squareSize == 6)
    {
        
        fields[1,1] = new Pit();
        fields[4,5] = new Pit();
        fields[5,4] = new Pit();
        
    }
    else if (squareSize == 8)
    {
        fields[2,1] = new Pit();
        fields[4,2] = new Pit();
        fields[4, 5] = new Pit();
        fields[5, 4] = new Pit();
        fields[5, 2] = new Pit();
        fields[0,4] = new Pit();
    }
}

//Ask the player how big the board should be:
// then change the gameboard accordingly


Console.WriteLine("How big should the board be?");
Console.WriteLine("s for small: 4x4 sized");
Console.WriteLine("m for medium: 6x6 sized");
Console.WriteLine("l for large: 8x8 sized");

//why couldn't I use a switch statement here?
do
{
    var input = Console.ReadLine();
    if (input == "s")
    {
        fields = new Field[4, 4];
        break;
    }
    else if (input == "m")
    {
        fields = new Field[6, 6];
        break;
    }
    else if (input == "l")
    {
        fields = new Field[8, 8];
        break;
    }
    else
    {
        Console.WriteLine("Invalid input, please try again.");
    }
} while (true); // this is not necessary more readable. the heck is this?

//since the board is a square, we can simply cast int into it with no problems for further customization
int squareSize = (int)Math.Sqrt(fields.Length);

Gameboard gameboard = new Gameboard();
FillBoard(fields, squareSize);

new NarrativeText().Intro();

while (true)
{
    new DescriptiveText().WhereAbout(player.GetPosition());
    if (player.GetPosition() == (0, 0))
    {
        new CavernText().Entrance();
    }
    else if (player.GetPosition() == (0, squareSize / 2))
    {
        FOO fountain = (FOO)fields[0, squareSize / 2];
        if (fields[0, squareSize / 2] is FOO && fountain.GetEnabled() == false)
        {
            new FountainText().FountainFoundDisabled();
        }
        else if (fields[0, squareSize / 2] is FOO && fountain.GetEnabled() == true)
        {
            new FountainText().FountainFoundEnabled();
        }
    }else if (fields[player.GetPosition().Item1, player.GetPosition().Item2] is Pit)
    {
        new NarrativeText().GetFallingIntoPitText();
        break;
    }

    gameboard.DrawBoard(fields, player, squareSize);
    if (player.PitIsNear(fields, squareSize) == true)
    {
        new NarrativeText().GetPitIsNearText();
    }

    while (true)
    {
        var input = new InputText().GetInput();
        //first validate input for movement
        bool validatedInput = ValidateInputMovement(input);
        if (validatedInput == true)
        {
            break;
        }
        else if (validatedInput == false)
        {
            string result = ValidateInputInteraction(input);
            switch (result)
            {
                case "win game":
                case "lose game":
                    return;
                case "fountain enabled":
                case "fountain disabled":
                    break;
                default:
                    if (
                        input.Contains("move east")
                        || input.Contains("move west")
                        || input.Contains("move south")
                        || input.Contains("move north")
                    ) { }
                    else
                    {
                        new NarrativeText().GetInvalidInputText(input);
                    }
                    break;
            }
        }
        //then validate for interactions.
    }
}

///<summary>
/// return
///</summary>
string ValidateInputInteraction(string input)
{
    FOO fountain = (FOO)fields[0, squareSize / 2];
    switch (input)
    {
        // leave the cavern if player is at the entrance, if the fountain is enabled, the player wins
        // otherwise the player loses
        // otherwise tell the player the field is not the entrance
        case "leave cavern":
            if (player.GetPosition() == (0, 0))
            {
                if (fountain.GetEnabled())
                {
                    new NarrativeText().GetLeaveCavernEnabledFountain();
                    return "win game";
                }
                else if (fountain.GetEnabled() == false)
                {
                    new NarrativeText().GetLeaveCavernDisabledFountain();
                    return "lose game";
                }
                return "left";
            }
            else
            {
                new NarrativeText().GetInvalidInputInteractionCavern();
                return "invalid input";
            }

        // enable fountain if player is at the fountain
        //  if it is already enabled, tell the player it is already enabled
        //  if it is disabled, enable it
        // tell player the field is not the fountain
        case "enable fountain":
            if (player.GetPosition() == (0, squareSize / 2))
            {
                if (fountain.GetEnabled() == true)
                {
                    new NarrativeText().GetInvalidInputEnableFountain();
                    return "invalid input";
                }
                else
                {
                    fountain.SetEnabled();
                    new FountainText().FountainEnabled();
                    return "fountain enabled";
                }
            }
            else
            {
                new NarrativeText().GetInvalidInputOutsideFountain();
                return "invalid input";
            }

        // disable fountain if player is at the fountain
        //  if it is already disabled, tell the player it is already disabled
        //  if it is enabled, disable it
        // tell player the field is not the fountain
        case "disable fountain":
            if (player.GetPosition() == (0, squareSize / 2))
            {
                if (fountain.GetEnabled() == true)
                {
                    fountain.SetEnabled();
                    new FountainText().FountainDisabled();
                    return "fountain disabled";
                }
                else
                {
                    new NarrativeText().GetInvalidInputDisableFountain();
                    return "invalid input";
                }
            }
            else
            {
                new NarrativeText().GetInvalidInputOutsideFountain();
                return "invalid input";
            }

        // catch all for invalid input
        default:
            return "invalid default";
    }
}

//
bool ValidateInputMovement(string input)
{
    switch (input)
    {
        case "move north":
            player.SetPosition((player.GetPosition().Item1 - 1, player.GetPosition().Item2));
            if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
            {
                return true;
            }
            else
            {
                player.SetPosition((player.GetPosition().Item1 + 1, player.GetPosition().Item2));
                new NarrativeText().GetInvalidInputBounds(input);
                return false;
            }
        case "move south":
            player.SetPosition((player.GetPosition().Item1 + 1, player.GetPosition().Item2));
            if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
            {
                return true;
            }
            else
            {
                player.SetPosition((player.GetPosition().Item1 - 1, player.GetPosition().Item2));
                new NarrativeText().GetInvalidInputBounds(input);
                return false;
            }

        case "move west":
            player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 - 1));
            if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
            {
                return true;
            }
            else
            {
                player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 + 1));
                new NarrativeText().GetInvalidInputBounds(input);
                return false;
            }
        case "move east":
            player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 + 1));
            if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
            {
                return true;
            }
            else
            {
                player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 - 1));
                new NarrativeText().GetInvalidInputBounds(input);
                return false;
            }
        default:
            return false;
    }
}

// EntityInGameField:
// if the item1 - 1 < 0 or item1 +
// same if for item2
// return false
bool IsEntityInGameField((int, int) tuple, int squareSize)
{
    if (tuple.Item1 < 0 || tuple.Item1 > squareSize)
    {
        return false;
    }
    else if (tuple.Item2 < 0 || tuple.Item2 > squareSize)
    {
        return false;
    }
    else
    {
        return true;
    }
}
