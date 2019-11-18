using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Simulator
{
    public interface IPlayPacman
    {
        Pacman Place(int x, int y, Direction direction);
        Pacman MovePacMan(Pacman item);
        Pacman PositionPacMan(Pacman item, Position position);      
    }
}
