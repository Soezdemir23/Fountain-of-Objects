using System.Reflection.Metadata;
using Fountain_of_Objects;

namespace Logic
{
    /// <summary>
    /// The Game Class contains all the logical parts of the game and fuses them
    /// together in the constructor as it is instantiated.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Player object
        /// </summary>
        private Player _player = new();

        /// <summary>
        /// Maelstorm Array is fully instantiated after the <
        /// Can be null, logically will never happen inside the game
        /// </summary>
        private Maelstorm[]? _maelstorms;

        /// <summary>
        /// Just like Maelstorm Array, the size and instantiation of the array is determined in the <see cref="FillBoard(Field[,], int)"/> method
        /// </summary>
        private Amarok[]? _amaroks;

        /// <summary>
        /// The field where the game takes place.
        /// Can be nullable, never gonna happen after asking the player for the size
        /// of the board.
        /// </summary>
        private Field[,]? _fields;

        /// <summary>
        /// Responsible to draw the gameboard for the user
        /// </summary>
        private Gameboard _gameboard = new Gameboard();

        /// <summary>
        /// The squareSize is used throughout the program in order to make logical checks.
        /// </summary>
       private int _squareSize;

        /// <summary>
        /// Sets Boardsize and assigns the length of the board to squareSize.
        /// Then starts the game.
        /// </summary>
        public Game()
        {
            _squareSize = SetBoardSize();
            Console.Clear();
            StartGame();
        }

        /// <summary>
        /// Asks the player what size the board should be.
        /// s: 4x4
        /// m: 6x6
        /// l: 8x8
        /// returns the size of the square's length and fully instantiates <see cref="fields"/>
        ///
        /// </summary>
        /// <returns>squareSize that is determining the rest of the game's logic</returns>
        private int SetBoardSize()
        {
            Console.WriteLine("How big should the board be?");
            Console.WriteLine("s for small: 4x4 sized");
            Console.WriteLine("m for medium: 6x6 sized");
            Console.WriteLine("l for large: 8x8 sized");

            //why couldn't I use a switch statement here?
            do
            {
                var input = Console.ReadLine().ToLower();
                if (input == "s")
                {
                    _fields = new Field[4, 4];
                    return 4;
                }
                else if (input == "m")
                {
                    _fields = new Field[6, 6];
                    return 6;
                }
                else if (input == "l")
                {
                    _fields = new Field[8, 8];
                    return 8;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            } while (true);
            // this is not necessary more readable. the heck is this?
        }

        /// <summary>
        /// Fills the board with necessary <see cref="Field"/> types.
        /// Also sets the enemies and pits in the field based on the squareSize value.
        /// </summary>
        /// <param name="fields">the instantiated 2d fields array</param>
        /// <param name="squareSize">the length of the 2d fields array</param>
        private void FillBoard(Field[,] fields, int squareSize)
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
                fields[1, 1] = new Pit();
                fields[2, 3] = new Pit();

                Array.Resize(ref _maelstorms, 1);
                _maelstorms[0] = new Maelstorm((0, 1));

                Array.Resize(ref _amaroks, 1);
                _amaroks[0] = new Amarok((2, 2));
            }
            else if (squareSize == 6)
            {
                fields[1, 1] = new Pit();
                fields[4, 5] = new Pit();
                fields[5, 4] = new Pit();

                Array.Resize(ref _amaroks, 2);
                _amaroks[0] = new Amarok((1, 4));
                _amaroks[1] = new Amarok((2, 3));

                Array.Resize(ref _maelstorms, 2);
                _maelstorms[0] = new Maelstorm((1, 2));
                _maelstorms[1] = new Maelstorm((3, 4));
            }
            else if (squareSize == 8)
            {
                fields[2, 1] = new Pit();
                fields[4, 2] = new Pit();
                fields[4, 5] = new Pit();
                fields[5, 4] = new Pit();
                fields[5, 2] = new Pit();
                fields[0, 4] = new Pit();

                Array.Resize(ref _amaroks, 3);
                _amaroks[0] = new Amarok((1, 4));
                _amaroks[1] = new Amarok((2, 3));
                _amaroks[2] = new Amarok((3, 5));

                Array.Resize(ref _maelstorms, 3);
                _maelstorms[0] = new Maelstorm((1, 4));
                _maelstorms[1] = new Maelstorm((5, 0));
                _maelstorms[2] = new Maelstorm((3, 4));
            }
        }

        /// <summary>
        /// Starts the game by filling the board with enemies and fields.
        /// Gives an intro, draws the map, explains where the player is.
        /// Draws the map, checks for surrounding pits, enemies and other notable
        /// events.
        /// </summary>
        private void StartGame()
        {
            FillBoard(_fields, _squareSize);
            new NarrativeText().Intro();

            while (true)
            {
                new DescriptiveText().WhereAbout(_player.GetPosition(), _player);
                if (_player.GetPosition() == (0, 0))
                {
                    new CavernText().Entrance();
                }
                else if (_player.GetPosition() == (0, _squareSize / 2))
                {
                    FOO fountain = (FOO)_fields[0, _squareSize / 2];
                    if (_fields[0, _squareSize / 2] is FOO && fountain.GetEnabled() == false)
                    {
                        new FountainText().FountainFoundDisabled();
                    }
                    else if (_fields[0, _squareSize / 2] is FOO && fountain.GetEnabled() == true)
                    {
                        new FountainText().FountainFoundEnabled();
                    }
                }
                else if (_fields[_player.GetPosition().Item1, _player.GetPosition().Item2] is Pit)
                {
                    new NarrativeText().GetFallingIntoPitText();
                    break;
                }

                // draw the maelstorma and also the amarok
                _gameboard.DrawBoard(_fields, _player, _amaroks, _maelstorms, _squareSize);
                // check if the player is on a boundary to pit fields, or it blows up in our face
                if (EntityIsSensingFields(_fields, _squareSize, typeof(Pit), _player) == true)
                {
                    new NarrativeText().GetPitIsNearText();
                }

                //check for Enemies around the player
                EntityIsNear(_amaroks);
                EntityIsNear(_maelstorms);


                while (true)
                {
                    var input = new InputText().GetInput();
                    //first validate input for movement
                    bool validatedInput = ValidateInputMovement(input);
                    if (validatedInput == true)
                    {
                        //here we should first check if the player actually stepped into a room with a maelstrom
                        foreach (Maelstorm monster in _maelstorms)
                        {
                            if (_player.GetPosition() == monster.GetPosition())
                            {
                                BlowEntityAway(monster, _player);
                            }
                        }
                        foreach (Amarok amarok in _amaroks)
                        {
                            if (_player.GetPosition() == amarok.GetPosition())
                            {
                                new NarrativeText().GetPlayerGetsEatenByAmaroks();
                                return;
                            }
                        }

                        break;
                    }
                    else if (validatedInput == false)
                    {
                        new DescriptiveText().WhereAbout(_player.GetPosition(), _player);

                        _gameboard.DrawBoard(_fields, _player, _amaroks, _maelstorms, _squareSize);
                        string result = ValidateInputInteraction(input);
                        switch (result)
                        {
                            case "win game":
                            case "lose game":
                                return;
                            case "fountain enabled":
                            case "fountain disabled":
                                break;
                            case "shot":
                                new NarrativeText().GetAmarokGotShot();
                                
                                break;
                            case "missed":
                                new NarrativeText().GetShotMissed();
                                break;
                            case "cancelled":
                                new NarrativeText().GetCancelled();
                                break;
                            case "no arrows":
                                new NarrativeText().GetNoArrows();
                                break;
                            case "help":
                                new SpecialText().GetHelp();
                                break;
                            default:
                                if (input.Contains("move") || input.Contains("mov"))
                                {
                                    new NarrativeText().GetInvalidMovementText();
                                }
                                else
                                {
                                    new NarrativeText().GetInvalidInputText(input);
                                }
                                break;
                        }
                    }
                    //then add a for each for the amaroks, since they move
                    // could be extracted into their own method and then simplified again.
                    new DescriptiveText().WhereAbout(_player.GetPosition(), _player);

                    _gameboard.DrawBoard(_fields,_player,_amaroks,_maelstorms,_squareSize);
                    AmarokBehavior();
                
                }
               
            }
        }


        /// <summary>
        /// The Amarok's movement and subsequent consequences of it doing so are handled here.
        /// The Amarok moves.
        /// The Amarok gets blasted away by the Maelstorm
        /// The Amarok dies from falling into a pit
        /// </summary>
        private void AmarokBehavior()
        {
            foreach (var amarok in _amaroks)
            {
                int x = amarok.GetPosition().Item1;
                int y = amarok.GetPosition().Item2;
                // x position:
                //randomize if the amarok walks negative or positive
                //if 0 => negative
                var xRandom = new Random().Next(1);
                if (xRandom == 0)
                {
                    //if x-1 is < 0, then do the opposite and add
                    if (x - 1 < 0)
                    {
                        x += 1;
                    }
                    else
                    {
                        x -= 1;
                    }
                }// if 1 => positive
                else
                {
                    if (x + 1 > _squareSize - 1)
                    {
                        x -= 1;
                    }
                    else
                    {
                        x += 1;
                    }
                }

                var yRandom = new Random().Next(1);
                if (yRandom == 0)
                {
                    //if x-1 is < 0, then do the opposite and add
                    if (y - 1 < 0)
                    {
                        y += 1;
                    }
                    else
                    {
                        y -= 1;
                    }
                }// if 1 => positive
                else
                {
                    if (y + 1 > _squareSize - 1)
                    {
                        y -= 1;
                    }
                    else
                    {
                        y += 1;
                    }
                }
                // now set it to the amarok
                amarok.SetPosition((x, y));
                //now Blow Amarok away if they are near maelstorms
                foreach (var maelstorm in _maelstorms)
                {
                    if (maelstorm.GetPosition() == amarok.GetPosition())
                    {
                        new NarrativeText().GetAmarokIsBlownAway();
                        BlowEntityAway(maelstorm, amarok);
                    }
                }
                if (_fields[x, y] is Pit)
                {
                    new NarrativeText().GetAmarokFallingIntoPit();
                    // let's do some iterative mutating to get rid of the "dead" Amarok
                    Amarok[] newAmarokList = new Amarok[_amaroks.Length - 1];
                    // there should be an easier way without using Lists I hope. works like te filter in JS
                    int count = 0;
                    for (int i = 0; i < _amaroks.Length; i++)
                    {
                        // the amarok is already in the coordinate where the pit i
                        // we just have to filter it out into that new array
                        // then overwrite amaroks with that one.
                        if (_amaroks[i].GetPosition() != (x, y))
                        {
                            newAmarokList[count] = _amaroks[i];
                        }
                    }
                    _amaroks = newAmarokList;
                }
            }
        }

        /// <summary>
        /// Validates input regarding interacting with the world.
        /// Caverns, Fountains
        ///
        /// </summary>
        /// <param name="input">the input the player entered</param>
        /// <returns>the result to be further analyzed</returns>
        private string ValidateInputInteraction(string input)
        {
            FOO fountain = (FOO)_fields[0, _squareSize / 2];
            switch (input)
            {
                // leave the cavern if player is at the entrance, if the fountain is enabled, the player wins
                // otherwise the player loses
                // otherwise tell the player the field is not the entrance
                case "leave cavern":
                    if (_player.GetPosition() == (0, 0))
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
                    if (_player.GetPosition() == (0, _squareSize / 2))
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
                    if (_player.GetPosition() == (0, _squareSize / 2))
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
                case "shoot arrow":
                    string direction = new NarrativeText().WhereToShoot();
                    var x = _player.GetPosition().Item1;
                    var y = _player.GetPosition().Item2;
                    bool shot = false;
                    if (_player.CanShootArrow() == true)
                    {


                    if (direction == "north"){
                        // if this was a single amarok, we could just check and break out.
                        // but we are having an amarok array
                        // if it is found, immediately set amarok.IsAlive to false and break;
                        foreach (var amarok in _amaroks)
                        {
                            // go through each field up to north
                            for (int i = x; i >= 0; i--)
                            {
                                // if there is an amarok that is in that direction, set the amarok isAlive to falses
                                // get out of the loop
                                if ((i,y) == amarok.GetPosition())
                                {
                                    amarok.SetIsAlive(false);
                                    shot = true;
                                    break;
                                }
                            }
                            //if that amarok isAlive property is false: break out of this foreach loop
                            if (amarok.GetIsAlive() == false) break;
                        }
                    }
                    else if (direction == "south")
                    {
                        // if this was a single amarok, we could just check and break out.
                        // but we are having an amarok array
                        // if it is found, immediately set amarok.IsAlive to false and break;
                        foreach (var amarok in _amaroks)
                        {
                            // go through each field up to north
                            for (int i = x; i < _squareSize; i++)
                            {
                                // if there is an amarok that is in that direction, set the amarok isAlive to falses
                                // get out of the loop
                                if ((i,y) == amarok.GetPosition())
                                {
                                    amarok.SetIsAlive(false);
                                    shot = true;
                                    break;
                                }
                            }
                            //if that amarok isAlive property is false: break out of this foreach loop
                            if (amarok.GetIsAlive() == false) break;
                        }
                      
                    }
                    else if (direction == "west")
                    {                        

                        // if this was a single amarok, we could just check and break out.
                        // but we are having an amarok array
                        // if it is found, immediately set amarok.IsAlive to false and break;
                        foreach (var amarok in _amaroks)
                        {
                            // go through each field up to north
                            for (int i = y; i >= 0; i--)
                            {
                                // if there is an amarok that is in that direction, set the amarok isAlive to falses
                                // get out of the loop
                                if ((x,i) == amarok.GetPosition())
                                {
                                    amarok.SetIsAlive(false);
                                    shot = true;
                                    break;
                                }
                            }
                            //if that amarok isAlive property is false: break out of this foreach loop
                            if (amarok.GetIsAlive() == false) break;
                        }
                    }
                    else if (direction == "east")
                    {
                        // if this was a single amarok, we could just check and break out.
                        // but we are having an amarok array
                        // if it is found, immediately set amarok.IsAlive to false and break;
                        foreach (var amarok in _amaroks)
                        {
                            // go through each field up to north
                            for (int i = y; i < _squareSize; i++)
                            {
                                // if there is an amarok that is in that direction, set the amarok isAlive to falses
                                // get out of the loop
                                if ((i,y) == amarok.GetPosition())
                                {
                                    amarok.SetIsAlive(false);
                                    shot = true;
                                    break;
                                }
                            }
                            //if that amarok isAlive property is false: break out of this foreach loop
                            if (amarok.GetIsAlive() == false) break;
                        }
                    }

                      // if it got shot, then go into this body to remove it from the array
                        if(shot == true){
                            // remove by one, since arrows aren't gibbing weapons
                            Amarok[] newAmarok = new Amarok[_amaroks.Length-1];
                            //now cycle through amaroks and add any amarok still alive to the new array.
                            int count = 0;
                            for (int i = 0; i < _amaroks.Length; i++)
                            {
                                if (_amaroks[i].GetIsAlive() != false){
                                    newAmarok[count] = _amaroks[i];
                                    count++;
                                }
                            }
                            // assign the newAmarok to amaroks.
                            _amaroks = newAmarok;

                            _player.ShootArrow();
                            return "shot";
                        }
                        else if(direction == "cancel")
                        {
                            return "cancelled";
                        }
                        else 
                        {
                            _player.ShootArrow();
                            return "missed";
                        }
                    }return "no arrows";
                // catch all for invalid input
                case "help":
                    return "help";
                default:
                    return "invalid default";
            }
        }

        /// <summary>
        /// Validates input regarding movement.
        /// Also corrects them with the <see cref="IsEntityInGameField(ValueTuple{int, int}, int)"/>
        /// method.
        /// If it is valid, the player may move.
        /// If not, the player's movement is rolled back within the 2d array's coordinates.
        ///
        /// </summary>
        /// <param name="input">the player's input</param>
        /// <returns>true for correct movement, false for incorrect movement</returns>
        private bool ValidateInputMovement(string input)
        {
            switch (input)
            {
                case "move north":
                    _player.SetPosition(
                        (_player.GetPosition().Item1 - 1, _player.GetPosition().Item2)
                    );
                    if (IsEntityInGameField(_player.GetPosition(), _squareSize) == true)
                    {
                        return true;
                    }
                    else
                    {
                        _player.SetPosition(
                            (_player.GetPosition().Item1 + 1, _player.GetPosition().Item2)
                        );
                        new NarrativeText().GetInvalidInputBounds(input);
                        return false;
                    }
                case "move south":
                    _player.SetPosition(
                        (_player.GetPosition().Item1 + 1, _player.GetPosition().Item2)
                    );
                    if (IsEntityInGameField(_player.GetPosition(), _squareSize) == true)
                    {
                        return true;
                    }
                    else
                    {
                        _player.SetPosition(
                            (_player.GetPosition().Item1 - 1, _player.GetPosition().Item2)
                        );
                        new NarrativeText().GetInvalidInputBounds(input);
                        return false;
                    }

                case "move west":
                    _player.SetPosition(
                        (_player.GetPosition().Item1, _player.GetPosition().Item2 - 1)
                    );
                    if (IsEntityInGameField(_player.GetPosition(), _squareSize) == true)
                    {
                        return true;
                    }
                    else
                    {
                        _player.SetPosition(
                            (_player.GetPosition().Item1, _player.GetPosition().Item2 + 1)
                        );
                        new NarrativeText().GetInvalidInputBounds(input);
                        return false;
                    }
                case "move east":
                    _player.SetPosition(
                        (_player.GetPosition().Item1, _player.GetPosition().Item2 + 1)
                    );
                    if (IsEntityInGameField(_player.GetPosition(), _squareSize) == true)
                    {
                        return true;
                    }
                    else
                    {
                        _player.SetPosition(
                            (_player.GetPosition().Item1, _player.GetPosition().Item2 - 1)
                        );
                        new NarrativeText().GetInvalidInputBounds(input);
                        return false;
                    }
                default:
                    return false;
            }
        }

        /// <summary>
        /// Checks if the player's coordinates are within the 2d-array.
        ///
        /// </summary>
        /// <param name="tuple">player's coordinates</param>
        /// <param name="squareSize">the length of the gameworld</param>
        /// <returns>Whether the player is moving further than the edge or not</returns>
        private bool IsEntityInGameField((int, int) tuple, int squareSize)
        {
            if (tuple.Item1 < 0 || tuple.Item1 > squareSize - 1)
            {
                return false;
            }
            else if (tuple.Item2 < 0 || tuple.Item2 > squareSize - 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// If the player enters the same room as a Maelstorm creature,
        /// the player is being blown away to the north east.
        /// The Maelstorm monster moves to the opposite direction.
        /// </summary>
        /// <param name="maelstorm">the maelstorm </param>
        /// <param name="player"></param>
        private void BlowEntityAway(Maelstorm maelstorm, Entity entity)
        {
            entity.SetPosition(
                (
                    entity.GetPosition().Item1 - 1 <= 0
                        ? _squareSize - 1
                        : entity.GetPosition().Item1 - 1,
                    entity.GetPosition().Item2 + 2 > _squareSize - 1
                        ? (entity.GetPosition().Item2 + 2) % (_squareSize - 1)
                        : entity.GetPosition().Item2 + 2
                )
            );

            maelstorm.SetPosition(
                (
                    maelstorm.GetPosition().Item1 + 1 > _squareSize - 1
                        ? 0
                        : maelstorm.GetPosition().Item1 + 1,
                    maelstorm.GetPosition().Item2 - 2 < 0
                        ? _squareSize - 1
                        : (maelstorm.GetPosition().Item2 - 2) % _squareSize
                )
            );
        }


        /// <summary>
        /// Checks if the player and the other entity child class are near each other
        /// Checks for adjacent fields/ coordinates.
        /// Differentiates between Maelstorm and Amarok
        /// </summary>
        /// <param name="entities">Enemy Entities as arrays</param>
        private void EntityIsNear(Entity[] entities)
        {
            foreach (var entity in entities)
            {
                if (
                    (
                        _player.GetPosition().Item1 + 1 == entity.GetPosition().Item1
                        || _player.GetPosition().Item1 - 1 == entity.GetPosition().Item1
                        || _player.GetPosition().Item1 == entity.GetPosition().Item1
                    )
                    && (
                        _player.GetPosition().Item2 + 1 == entity.GetPosition().Item2
                        || _player.GetPosition().Item2 - 1 == entity.GetPosition().Item2
                        || _player.GetPosition().Item2 == entity.GetPosition().Item2
                    )
                )
                //maelstorm is
                {
                    if (entity is Maelstorm)
                    {
                        new NarrativeText().GetMaelstormIsNearText();
                    }
                    else if (entity is Amarok)
                    {
                        new NarrativeText().GetAmarokIsNearText();
                    }
                }
            }
        }



        

        /// <summary>
        /// Entities need to be able to sense Field objects in a 2d Array without blowing up in our faces.
        
        /// </summary>
        /// <param name="fields">the 2d-array that the player has to reside in</param>
        /// <param name="squareSize">the length of a square to check base cases</param>
        /// <param name="field">The type of the field the player is checking for</param>
        /// <returns>
        /// Returns true if the player finds a Field type that he needs to be wary of.
        /// Else returns false.
        /// </returns>
        private bool EntityIsSensingFields(Field[,] fields, int squareSize, Type field, Entity entity)
        {
            //check base cases:

            // upper left corner
            if (entity.GetPosition().Item1 == 0 && entity.GetPosition().Item2 == 0)
            {
                if (
                    fields[entity.GetPosition().Item1 + 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 + 1].GetType()
                        == field
                )
                {
                    return true;
                }
            } // upper right corner
            else if (
                entity.GetPosition().Item1 == 0
                && entity.GetPosition().Item2 + 1 == squareSize
            )
            {
                if (
                    fields[entity.GetPosition().Item1, entity.GetPosition().Item2 - 1].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1 + 1, entity.GetPosition().Item2].GetType()
                        == field
                )
                {
                    return true;
                }
            } // lower right corner
            else if (
                entity.GetPosition().Item1 + 1 == squareSize
                && entity.GetPosition().Item2 + 1 == squareSize
            )
            {
                if (
                    fields[entity.GetPosition().Item1 - 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 - 1].GetType()
                        == field
                )
                {
                    return true;
                }
            } // lower left corner
            else if (
                entity.GetPosition().Item1 + 1 == squareSize
                && entity.GetPosition().Item2 == 0
            )
            {
                if (
                    fields[entity.GetPosition().Item1 - 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2].GetType()
                        == field
                )
                {
                    return true;
                }
            } // upper edge
            else if (
                entity.GetPosition().Item1 == 0
                && entity.GetPosition().Item2 != 0
                && entity.GetPosition().Item2 + 1 != squareSize
            )
            {
                if (
                    fields[entity.GetPosition().Item1, entity.GetPosition().Item2 - 1].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1 + 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 + 1].GetType()
                        == field
                )
                {
                    return true;
                }
            } // right edge
            else if (
                entity.GetPosition().Item1 != 0
                && entity.GetPosition().Item1 + 1 != squareSize
                && entity.GetPosition().Item2 + 1 == squareSize
            )
            {
                if (
                    fields[entity.GetPosition().Item1 - 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 - 1].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1 + 1, entity.GetPosition().Item2].GetType()
                        == field
                )
                {
                    return true;
                }
            } // lower edge
            else if (
                entity.GetPosition().Item1 + 1 == squareSize
                && entity.GetPosition().Item2 + 1 != squareSize
                && entity.GetPosition().Item2 != 0
            )
            {
                if (
                    fields[entity.GetPosition().Item1, entity.GetPosition().Item2 + 1].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1 - 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 - 1].GetType()
                        == field
                )
                    return true;
            } // left edge
            else if (
                entity.GetPosition().Item1 != 0
                && entity.GetPosition().Item1 + 1 != squareSize
                && entity.GetPosition().Item2 == 0
            )
            {
                if (
                    fields[entity.GetPosition().Item1 + 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 + 1].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1 - 1, entity.GetPosition().Item2].GetType()
                        == field
                )
                    return true;
            } // middle
            else
            {
                if (
                    fields[entity.GetPosition().Item1 + 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 + 1].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 + 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1 - 1, entity.GetPosition().Item2].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 - 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                    || fields[entity.GetPosition().Item1, entity.GetPosition().Item2 - 1].GetType()
                        == field
                    || fields[
                        entity.GetPosition().Item1 + 1,
                        entity.GetPosition().Item2 - 1
                    ].GetType() == field
                )
                    return true;
            }
            return false;
        }
    }
    
}
