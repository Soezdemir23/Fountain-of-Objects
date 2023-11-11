/// <summary>
/// This namespace contains classes for the Fountain of Objects game.
/// </summary>
namespace Fountain_of_Objects
{
    /// <summary>
    /// The class Entity is the skeleton of the next children classes:
    /// <list type="bullet">
    /// - Player
    /// - Amarok
    /// - Maelstorm
    /// </listend>
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// The Position of the Entity
        /// </summary>
        protected (int, int) Position { get; set; }

        /// <summary>
        /// The look of the Entity, or the representation of the object.
        /// </summary>
        protected string Sign { get; set; }

        /// <summary>
        /// Is a check for later when the player has to
        /// fight or the enemy dies
        /// </summary>
        protected bool isAlive { get; set; } = true;

        /// <summary>
        /// Returns the representation of the Entity object as a string
        /// </summary>
        /// <returns>The look of the object</returns>
        public string GetSign() => Sign;

        /// <summary>
        /// Get if the Entity is alive
        /// </summary>
        /// <returns>the aliveness of the character</returns>
        public bool GetIsAlive() => isAlive;

        /// <summary>
        /// Returns the
        /// </summary>
        /// <returns></returns>
        public (int, int) GetPosition() => Position;

        /// <summary>
        /// Get the look of the Entity object. Should be overwritten.
        ///
        /// Class children are inheriting from it to differentiate from each other.
        /// </summary>
        public virtual void GetLook()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Sign);
            Console.ResetColor();
        }
        /// <summary>
        /// Set the position of the player in the grid
        /// </summary>
        /// <param name="position">a (int,int) tuple</param>
        public void SetPosition((int, int) position)
        {
            this.Position = position;
        }
    }
    /// <summary>
    /// Player class inheriting from Entity
    /// The Player class is used by the player, duh :)
    /// </summary>
    public class Player : Entity
    {
        /// <summary>
        /// The constructor assigns the position and the Sign of the Player class
        /// when instantiated.
        /// </summary>
        public Player()
        {
            Position = (0, 0);
            Sign = "P";
        }

        /// <summary>
        /// This function should be moved to the Program.cs site tbh.
        /// </summary>
        /// <param name="fields">the 2d-array that the player has to reside in</param>
        /// <param name="squareSize">the length of a square to check base cases</param>
        /// <param name="field">The type of the field the player is checking for</param>
        /// <returns>
        /// Returns true if the player finds a Field type that he needs to be wary of.
        /// Else returns false.
        /// </returns>
        public bool IsNear(Field[,] fields, int squareSize, Type field)
        {
            //check base cases:

            // upper left corner
            if (Position.Item1 == 0 && Position.Item2 == 0)
            {
                if (
                    fields[Position.Item1 + 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 + 1].GetType() == field
                )
                {
                    return true;
                }
            } // upper right corner
            else if (Position.Item1 == 0 && Position.Item2 + 1 == squareSize)
            {
                if (
                    fields[Position.Item1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2].GetType() == field
                )
                {
                    return true;
                }
            } // lower right corner
            else if (Position.Item1 + 1 == squareSize && Position.Item2 + 1 == squareSize)
            {
                if (
                    fields[Position.Item1 - 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 - 1].GetType() == field
                )
                {
                    return true;
                }
            } // lower left corner
            else if (Position.Item1 + 1 == squareSize && Position.Item2 == 0)
            {
                if (
                    fields[Position.Item1 - 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1, Position.Item2].GetType() == field
                )
                {
                    return true;
                }
            } // upper edge
            else if (Position.Item1 == 0 && Position.Item2 != 0 && Position.Item2 + 1 != squareSize) // i tried to be more specific here, should I do the same below?
            {
                if (
                    fields[Position.Item1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 + 1].GetType() == field
                )
                {
                    return true;
                }
            } // right edge
            else if (
                Position.Item1 != 0
                && Position.Item1 + 1 != squareSize
                && Position.Item2 + 1 == squareSize
            )
            {
                if (
                    fields[Position.Item1 - 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2].GetType() == field
                )
                {
                    return true;
                }
            } // lower edge
            else if (
                Position.Item1 + 1 == squareSize
                && Position.Item2 + 1 != squareSize
                && Position.Item2 != 0
            )
            {
                if (
                    fields[Position.Item1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 - 1].GetType() == field
                )
                    return true;
            } // left edge
            else if (Position.Item1 != 0 && Position.Item1 + 1 != squareSize && Position.Item2 == 0)
            {
                if (
                    fields[Position.Item1 + 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2].GetType() == field
                )
                    return true;
            } // middle
            else
            {
                if (
                    fields[Position.Item1 + 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 + 1].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2].GetType() == field
                    || fields[Position.Item1 - 1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1, Position.Item2 - 1].GetType() == field
                    || fields[Position.Item1 + 1, Position.Item2 - 1].GetType() == field
                )
                    return true;
            }
            return false;
        }
    }
    /// <summary>
    /// The Maelstrom also inherits from the Entity
    /// Unlike the player, it's skill has been transferred to the Logic part.
    /// </summary>
    public class Maelstorm : Entity
        {
            /// <summary>
            /// Unlike the Player entity, the starting point can be custom here
            /// That makes it easier to place them
            /// </summary>
            /// <param name="position">(int,int) inside the game map</param>
        public Maelstorm((int, int) position)
        {
            Position = position;
            Sign = "M";
        }
/// <summary>
/// Get the look of the Maelstorm, it is 'M' in Blue
/// </summary>
        public override void GetLook()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Sign);
            Console.ResetColor();
        }
    }
}
