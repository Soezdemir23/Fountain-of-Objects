using System.Security.Cryptography;

namespace Fountain_of_Objects
{
    public abstract class Entity
    {
        protected (int, int) Position { get; set; }
        protected string Sign { get; set; }
        protected bool isAlive { get; set; } = true;

        public string GetSign() => Sign;

        public bool GetIsAlive() => isAlive;

        public (int, int) GetPosition() => Position;

        public void GetLook()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Sign);
            Console.ResetColor();
        }

        public void SetPosition((int, int) position)
        {
            this.Position = position;
        }
    }

    public class Player : Entity
    {
        public Player()
        {
            Position = (0, 0);
            Sign = "P";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public bool PitIsNear(Field[,] fields, int squareSize)
        {
            //check base cases:

            // upper left corner
            if (Position.Item1 == 0 && Position.Item2 == 0)
            {
                if (
                    fields[Position.Item1 + 1, Position.Item2] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1, Position.Item2 + 1] is Pit
                )
                {
                    return true;
                }
            } // upper right corner
            else if (Position.Item1 == 0 && Position.Item2 + 1 == squareSize)
            {
                if (
                    fields[Position.Item1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 + 1, Position.Item2] is Pit
                )
                {
                    return true;
                }
            } // lower right corner
            else if (Position.Item1 + 1 == squareSize && Position.Item2 + 1 == squareSize)
            {
                if (
                    fields[Position.Item1 - 1, Position.Item2] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1, Position.Item2 - 1] is Pit
                )
                {
                    return true;
                }
            } // lower left corner
            else if (Position.Item1 + 1 == squareSize && Position.Item2 == 0)
            {
                if (
                    fields[Position.Item1 - 1, Position.Item2] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1, Position.Item2] is Pit
                )
                {
                    return true;
                }
            } // upper edge
            else if (Position.Item1 == 0 && Position.Item2 != 0 && Position.Item2 + 1 != squareSize) // i tried to be more specific here, should I do the same below?
            {
                if (
                    fields[Position.Item1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 + 1, Position.Item2] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1, Position.Item2 + 1] is Pit
                )
                {
                    return true;
                }
            } // right edge
            else if (Position.Item1 != 0 && Position.Item1 + 1 != squareSize && Position.Item2 + 1 == squareSize)
            {
                if (
                    fields[Position.Item1 - 1, Position.Item2] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 + 1, Position.Item2] is Pit
                )
                {
                    return true;
                }
            } // lower edge
            else if (Position.Item1 + 1 == squareSize && Position.Item2+1 != squareSize && Position.Item2 != 0)
            {
                if (
                    fields[Position.Item1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1 - 1, Position.Item2] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1, Position.Item2 - 1] is Pit
                )
                    return true;
            } // left edge
            else if (Position.Item1 != 0 && Position.Item1 + 1 != squareSize && Position.Item2 == 0)
            {
                if (
                    fields[Position.Item1 + 1, Position.Item2] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1 - 1, Position.Item2] is Pit
                )
                    return true;
            } // middle
            else
            {
                if (
                    fields[Position.Item1 + 1, Position.Item2] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1, Position.Item2 + 1] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 - 1, Position.Item2] is Pit
                    || fields[Position.Item1 - 1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1, Position.Item2 - 1] is Pit
                    || fields[Position.Item1 + 1, Position.Item2 - 1] is Pit
                )
                    return true;
            }
            return false;
        }
    }
}
