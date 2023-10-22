using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain_of_Objects
{
    public abstract class Entity
    {
        protected Tuple<int, int> Position { get; set; }
        protected string Sign { get; set; }
        protected bool isAlive { get; set; }

        
    }

    public class Player : Entity
    {
        public Player()
        {
            Position = new Tuple<int, int>(0, 0);
            Sign = "P";
            isAlive = true;
        }
    }


}
