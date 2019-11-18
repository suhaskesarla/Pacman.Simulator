using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Simulator
{
    public class Pacman 
    {         
        public Pacman()
        {
            X = 0;
            Y = 0;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Direction direction { get; set; }

        public virtual Pacman Report(Pacman item)
        {
            return item;
        }
    }
}
