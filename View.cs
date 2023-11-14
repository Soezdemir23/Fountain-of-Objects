using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_Objects
{
    public class Gameboard
    {
        /// <summary>
        /// creates a 2d array of tiles
        /// It draws a 4x4, 6x6, 8x8 field
        /// </summary>
        public void DrawBoard(
            Field[,] fields,
            Player player,
            Amarok[] amaroks,
            Maelstorm[] maelstorms,
            int squareSize
        )
        {
            for (int i = 0; i < squareSize; i++)
            {
                for (int k = 0; k < squareSize; k++)
                {
                    if (i == player.GetPosition().Item1 && k == player.GetPosition().Item2)
                    {
                        player.GetLook();
                    }
                    else if (SameCoordinate((i, k), maelstorms) == true)
                    {
                        //since we can just get the look of the enemy, we can do this:
                        maelstorms[0].GetLook();
                    }
                    else if (SameCoordinate((i, k), amaroks) == true)
                    {
                        amaroks[0].GetLook();
                    }
                    else
                    {
                        fields[i, k].GetLook();
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Helper function for <see cref="DrawBoard(Field[,], Player, Amarok[], Maelstorm[], int)"/>.
        /// Checks if the given coordinate from DrawBoard is equal to the entity.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool SameCoordinate((int, int) coordinate, Entity[] entities)
        {
            foreach (Entity entity in entities)
            {
                if (entity.GetPosition() == coordinate)
                {
                    return true;
                }
            }
        return false;
        }
    }
}
