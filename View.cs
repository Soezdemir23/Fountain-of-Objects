﻿using System;
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
        public void DrawBoard(Field[,] fields, Player player)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (i == player.GetPosition().Item1 && k == player.GetPosition().Item2)
                    {
                        player.GetLook();
                    }
                    else
                    {
                        fields[i, k].GetLook();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
