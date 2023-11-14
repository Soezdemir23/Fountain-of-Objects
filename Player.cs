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

        public void SetIsAlive(bool alive) => isAlive = alive;

        /// <summary>
        /// Returns the position of the entity
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
            Position = position;
        }
    }

    /// <summary>
    /// Player class inheriting from Entity
    /// The Player class is used by the player, duh :)
    /// </summary>
    public class Player : Entity
    {
        private int _arrows = 5;

        /// <summary>
        /// The constructor assigns the position and the Sign of the Player class
        /// when instantiated.
        /// </summary>
        public Player()
        {
            Position = (0, 0);
            Sign = "P";
        }

        public bool CanShootArrow()
        {
            if (_arrows == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShootArrow(){
            if (_arrows > 0 )
            {
                _arrows--;
            }

        }

        public int GetArrows()
        {
            return _arrows;
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
            isAlive = true;
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

    public class Amarok : Entity
    {
        public Amarok((int, int) position)
        {
            Position = position;
            Sign = "Å";
            isAlive = true;
        }

    }
}
