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
        /// default is one of 4x4
        /// </summary>
        public void DrawBoard(
            Field[,] fields,
            Player player,
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
                    else
                    {
                        fields[i, k].GetLook();
                    }
                }
                Console.WriteLine();
            }
        }

        public bool SameCoordinate((int, int) coordinate, Maelstorm[] maelstorms)
        {
            foreach (Maelstorm item in maelstorms)
            {
                if (item.GetPosition() == coordinate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
