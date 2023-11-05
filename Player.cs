using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
