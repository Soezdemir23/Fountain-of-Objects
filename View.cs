using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_Objects
{

    public class Gameboard
    {

        Fields[,] Board { get; set; } = new Fields[4, 4];

        public Gameboard()
        {
            FillBoard();
            DrawBoard();
        }

        private void FillBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (i == 0 && k == 0)
                    {
                        Board[i, k] = new Cavern();
                    }
                    else if (i == 0 && k == 2)
                    {
                        Board[i, k] = new FOO();
                    }
                    else
                    {
                        Board[i, k] = new Empty();
                    }
                }
            }
        }

        /// <summary>
        /// creates a 2d array of tiles
        /// default is one of 4x4
        /// </summary>
        public void DrawBoard()
        {
           for (int i = 0; i < 4; i++)
            {
                
                for (int k = 0; k < 4; k++)
                {
                    Board[i,k].GetLook();
                }
                Console.WriteLine();
            }
        }
    }
}
