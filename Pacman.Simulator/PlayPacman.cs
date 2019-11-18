using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Pacman.Helper;

namespace Pacman.Simulator
{
    public class PlayPacman : IPlayPacman
    {
        private ILog _Logger;


        public PlayPacman(ILog logger)
        {
            _Logger = logger;
        }

        public Pacman Place(int x, int y, Direction direction)
        {
            int maxRange = 0;
            int minRange = 0;
            Pacman item = new Pacman();
            if (int.TryParse(ConfigurationHelper.GetConfigurations(Constants.MaximumRange), out maxRange) && int.TryParse(ConfigurationHelper.GetConfigurations(Constants.MinimumRange), out minRange))
            {
                
                try
                {
                    if (Enumerable.Range(minRange, maxRange+1).Contains(x) && Enumerable.Range(minRange, maxRange+1).Contains(y))
                    {
                        item.X = x;
                        item.Y = y;
                        item.direction = direction;
                        return item;
                    }
                }
                catch (Exception ex)
                {

                    _Logger.Error(string.Format("Place: Message {0} ,Stacktrace {1} ", ex.ToString(), ex.StackTrace.ToString()));
                    return null;

                }
            }
            return item;

        }

        public Pacman PositionPacMan(Pacman item, Position position)
        {
            Pacman pacmanItem = item;

            try
            {
                if (position == Position.LEFT)
                {
                    pacmanItem.direction = PositionLeft(item.direction);
                }
                else
                {
                    pacmanItem.direction = PositionRight(item.direction);
                }
            }
            catch (Exception ex)
            {

                _Logger.Error(string.Format("PositionPacMan: Message {0} ,Stacktrace {1} ", ex.ToString(), ex.StackTrace.ToString()));
                return pacmanItem;
            }

            return pacmanItem;

        }

        public Pacman MovePacMan(Pacman item)
        {
            int maxRange = 0;
            int minRange = 0;

            if (int.TryParse(ConfigurationHelper.GetConfigurations(Constants.MaximumRange), out maxRange) && int.TryParse(ConfigurationHelper.GetConfigurations(Constants.MinimumRange), out minRange))
            {
                try
                {
                    switch (item.direction)
                    {
                        case Direction.NORTH:
                            if (item.Y >= minRange && item.Y < maxRange)
                            {
                                item.Y = item.Y + 1;
                                return item;
                            }
                            break;
                        case Direction.SOUTH:
                            if (item.Y > minRange && item.Y <= maxRange)
                            {
                                item.Y = item.Y - 1;
                                return item;
                            }
                            break;
                        case Direction.EAST:
                            if (item.X >= minRange && item.X < maxRange)
                            {
                                item.X = item.X + 1;
                                return item;
                            }
                            break;
                        case Direction.WEST:
                            if (item.X > minRange && item.X <= maxRange)
                            {
                                item.X = item.X - 1;
                                return item;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {

                    _Logger.Error(string.Format("PositionPacMan: Message {0} ,Stacktrace {1} ", ex.ToString(), ex.StackTrace.ToString()));
                    return item;
                }
            }
            return item;
        }


        private Direction PositionRight(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    direction = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    direction = Direction.WEST;
                    break;
                case Direction.EAST:
                    direction = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    direction = Direction.NORTH;
                    break;
            }
            return direction;
        }

        private static Direction PositionLeft(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    direction = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    direction = Direction.EAST;
                    break;
                case Direction.EAST:
                    direction = Direction.NORTH;
                    break;
                case Direction.WEST:
                    direction = Direction.SOUTH;
                    break;
            }
            return direction;
        }
    }
}
