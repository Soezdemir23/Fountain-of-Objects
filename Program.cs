// // See https://aka.ms/new-console-template for more information
// using Fountain_of_Objects;

// //Should I first prototype the logic on the main method?


// Player player = new();
// Maelstrom[] maelstroms = new Maelstrom[2];
// Field[,] fields = new Field[4, 4];


// //since the board is a square, we can simply cast int into it with no problems for further customization
// int squareSize = (int)Math.Sqrt(fields.Length);

// Gameboard gameboard = new Gameboard();

// static void FillBoard(Field[,] fields, int squareSize)
// {
//     for (int i = 0; i < squareSize; i++)
//     {
//         for (int k = 0; k < squareSize; k++)
//         {
//             if (i == 0 && k == 0) // can stay like this
//             {
//                 fields[i, k] = new Cavern();
//             }
//             else if (i == 0 && k == squareSize / 2) // so basically s=> 0,2 m=> 0,3 l=> 0,4
//             {
//                 fields[i, k] = new FOO();
//             }
//             else
//             {
//                 fields[i, k] = new Empty();
//             }
//         }
//     }

//     // 1,2,4 and the squares are 4,6,8
//     if (squareSize == 4)
//     {
//         fields[1, 1] = new Pit();
//         fields[2, 3] = new Pit();

//     }
//     else if (squareSize == 6)
//     {

//         fields[1, 1] = new Pit();
//         fields[4, 5] = new Pit();
//         fields[5, 4] = new Pit();

//         maelstroms[0] = new Maelstrom((1, 2));
//     }
//     else if (squareSize == 8)
//     {
//         fields[2, 1] = new Pit();
//         fields[4, 2] = new Pit();
//         fields[4, 5] = new Pit();
//         fields[5, 4] = new Pit();
//         fields[5, 2] = new Pit();
//         fields[0, 4] = new Pit();

//         Maelstrom maelstrom1 = new Maelstrom((1, 4));
//         Maelstrom maelstrom2 = new Maelstrom((5, 0));
//     }
// }

// //Ask the player how big the board should be:
// // then change the gameboard accordingly


// Console.WriteLine("How big should the board be?");
// Console.WriteLine("s for small: 4x4 sized");
// Console.WriteLine("m for medium: 6x6 sized");
// Console.WriteLine("l for large: 8x8 sized");

// //why couldn't I use a switch statement here?
// do
// {
//     var input = Console.ReadLine();
//     if (input == "s")
//     {
//         fields = new Field[4, 4];
//         break;
//     }
//     else if (input == "m")
//     {
//         fields = new Field[6, 6];
//         break;
//     }
//     else if (input == "l")
//     {
//         fields = new Field[8, 8];
//         break;
//     }
//     else
//     {
//         Console.WriteLine("Invalid input, please try again.");
//     }
// } while (true); // this is not necessary more readable. the heck is this?


// FillBoard(fields, squareSize);




// void BlowPlayerAway(Maelstrom maelstrom, Player player)
// {
//     //the coordinates are like a ring in discrete math that I had once in college
//     //if you go over the outer bounds, it returns back on the other side
//     //so 6 is the max range of the ring we add 9 it results in 3
//     // what examples of ring calculation exists?
//     // (4+3) % 6 = 1
//     // (3-4) % 6 = -1
//     // We need to wrap these calculations in absolute value.
//     // we also need to take into account that the coordinate system starts at zero.
//     //
//     //fist we check for north, aka y axis, which is Item1
//     player.SetPosition((
//         Math.Abs(player.GetPosition().Item1 + 1) % (squareSize - 1),
//         Math.Abs(player.GetPosition().Item2 + 2) % (squareSize - 1)
//     ));

//     maelstrom.SetPosition((
//         Math.Abs(maelstrom.GetPosition().Item1 - 1) % (squareSize - 1),
//         Math.Abs(maelstrom.GetPosition().Item2 - 2) % (squareSize - 1)
//     ));
// }



// ///<summary>
// /// return
// ///</summary>
// string ValidateInputInteraction(string input)
// {
//     FOO fountain = (FOO)fields[0, squareSize / 2];
//     switch (input)
//     {
//         // leave the cavern if player is at the entrance, if the fountain is enabled, the player wins
//         // otherwise the player loses
//         // otherwise tell the player the field is not the entrance
//         case "leave cavern":
//             if (player.GetPosition() == (0, 0))
//             {
//                 if (fountain.GetEnabled())
//                 {
//                     new NarrativeText().GetLeaveCavernEnabledFountain();
//                     return "win game";
//                 }
//                 else if (fountain.GetEnabled() == false)
//                 {
//                     new NarrativeText().GetLeaveCavernDisabledFountain();
//                     return "lose game";
//                 }
//                 return "left";
//             }
//             else
//             {
//                 new NarrativeText().GetInvalidInputInteractionCavern();
//                 return "invalid input";
//             }

//         // enable fountain if player is at the fountain
//         //  if it is already enabled, tell the player it is already enabled
//         //  if it is disabled, enable it
//         // tell player the field is not the fountain
//         case "enable fountain":
//             if (player.GetPosition() == (0, squareSize / 2))
//             {
//                 if (fountain.GetEnabled() == true)
//                 {
//                     new NarrativeText().GetInvalidInputEnableFountain();
//                     return "invalid input";
//                 }
//                 else
//                 {
//                     fountain.SetEnabled();
//                     new FountainText().FountainEnabled();
//                     return "fountain enabled";
//                 }
//             }
//             else
//             {
//                 new NarrativeText().GetInvalidInputOutsideFountain();
//                 return "invalid input";
//             }

//         // disable fountain if player is at the fountain
//         //  if it is already disabled, tell the player it is already disabled
//         //  if it is enabled, disable it
//         // tell player the field is not the fountain
//         case "disable fountain":
//             if (player.GetPosition() == (0, squareSize / 2))
//             {
//                 if (fountain.GetEnabled() == true)
//                 {
//                     fountain.SetEnabled();
//                     new FountainText().FountainDisabled();
//                     return "fountain disabled";
//                 }
//                 else
//                 {
//                     new NarrativeText().GetInvalidInputDisableFountain();
//                     return "invalid input";
//                 }
//             }
//             else
//             {
//                 new NarrativeText().GetInvalidInputOutsideFountain();
//                 return "invalid input";
//             }

//         // catch all for invalid input
//         default:
//             return "invalid default";
//     }
// }

// //
// bool ValidateInputMovement(string input)
// {
//     switch (input)
//     {
//         case "move north":
//             player.SetPosition((player.GetPosition().Item1 - 1, player.GetPosition().Item2));
//             if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
//             {
//                 return true;
//             }
//             else
//             {
//                 player.SetPosition((player.GetPosition().Item1 + 1, player.GetPosition().Item2));
//                 new NarrativeText().GetInvalidInputBounds(input);
//                 return false;
//             }
//         case "move south":
//             player.SetPosition((player.GetPosition().Item1 + 1, player.GetPosition().Item2));
//             if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
//             {
//                 return true;
//             }
//             else
//             {
//                 player.SetPosition((player.GetPosition().Item1 - 1, player.GetPosition().Item2));
//                 new NarrativeText().GetInvalidInputBounds(input);
//                 return false;
//             }

//         case "move west":
//             player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 - 1));
//             if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
//             {
//                 return true;
//             }
//             else
//             {
//                 player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 + 1));
//                 new NarrativeText().GetInvalidInputBounds(input);
//                 return false;
//             }
//         case "move east":
//             player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 + 1));
//             if (IsEntityInGameField(player.GetPosition(), squareSize) == true)
//             {
//                 return true;
//             }
//             else
//             {
//                 player.SetPosition((player.GetPosition().Item1, player.GetPosition().Item2 - 1));
//                 new NarrativeText().GetInvalidInputBounds(input);
//                 return false;
//             }
//         default:
//             return false;
//     }
// }

// // EntityInGameField:
// // if the item1 - 1 < 0 or item1 +
// // same if for item2
// // return false
// bool IsEntityInGameField((int, int) tuple, int squareSize)
// {
//     if (tuple.Item1 < 0 || tuple.Item1 > squareSize)
//     {
//         return false;
//     }
//     else if (tuple.Item2 < 0 || tuple.Item2 > squareSize)
//     {
//         return false;
//     }
//     else
//     {
//         return true;
//     }
// }

using Logic;

Game game = new Game();
