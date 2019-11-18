using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Pacman.Simulator.Tests
{
    [TestClass]
    public class PlayPacmanTests
    {
        private static ILog _Logger;

        [TestInitialize]
        public void Initalize()
        {
            _Logger = (new Mock<ILog>()).Object;
        }

        [TestMethod]
        public void Place_RangeTest_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = sut.Place(4, 4, Direction.NORTH);
            Assert.AreEqual(pacmanItem.X, 4);
        }

        [TestMethod]
        public void Place_OutOfRangeTest_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = sut.Place(8, 7, Direction.NORTH);
            Assert.AreNotEqual(pacmanItem.X, 8);
        }

        [TestMethod]
        public void MovePacMan_ValidNorthMove_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.NORTH };
            var movedItem = sut.MovePacMan(pacmanItem);
            Assert.AreNotEqual(pacmanItem.X, 1);
        }

        [TestMethod]
        public void MovePacMan_ValidEastMove_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 1, Y = 1, direction = Direction.EAST };
            var movedItem = sut.MovePacMan(pacmanItem);
            Assert.AreEqual(pacmanItem.X, 2);
        }

        [TestMethod]
        public void MovePacMan_ValidSouthMove_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 2, Y = 2, direction = Direction.SOUTH };
            var movedItem = sut.MovePacMan(pacmanItem);
            Assert.AreEqual(pacmanItem.Y, 1);
        }

        [TestMethod]
        public void MovePacMan_ValidWestMove_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 3, Y = 3, direction = Direction.WEST };
            var movedItem = sut.MovePacMan(pacmanItem);
            Assert.AreEqual(pacmanItem.X, 2);
        }

        [TestMethod]
        public void MovePacMan_InvalidValidMove_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 1, Y = 1, direction = Direction.NORTH };
            var movedItem = sut.MovePacMan(pacmanItem);
            Assert.AreNotEqual(pacmanItem.Y, 1);
        }

        [TestMethod]
        public void PositionPacMan_NorthLeft_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.NORTH };
            var movedItem = sut.PositionPacMan(pacmanItem,Position.LEFT);
            Assert.AreEqual(pacmanItem.direction, Direction.WEST);
        }

        [TestMethod]
        public void PositionPacMan_WestLeft_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.WEST };
            var movedItem = sut.PositionPacMan(pacmanItem, Position.LEFT);
            Assert.AreEqual(pacmanItem.direction, Direction.SOUTH);
        }

        [TestMethod]
        public void PositionPacMan_SouthLeft_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.SOUTH };
            var movedItem = sut.PositionPacMan(pacmanItem, Position.LEFT);
            Assert.AreEqual(pacmanItem.direction, Direction.EAST);
        }

        [TestMethod]
        public void PositionPacMan_EastLeft_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.EAST };
            var movedItem = sut.PositionPacMan(pacmanItem, Position.LEFT);
            Assert.AreEqual(pacmanItem.direction, Direction.NORTH);
        }

        [TestMethod]
        public void PositionPacMan_EastRight_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.EAST };
            var movedItem = sut.PositionPacMan(pacmanItem, Position.RIGHT);
            Assert.AreEqual(pacmanItem.direction, Direction.SOUTH);
        }

        [TestMethod]
        public void PositionPacMan_NorthRight_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.NORTH };
            var movedItem = sut.PositionPacMan(pacmanItem, Position.RIGHT);
            Assert.AreEqual(pacmanItem.direction, Direction.EAST);
        }

        [TestMethod]
        public void PositionPacMan_SouthRight_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.SOUTH };
            var movedItem = sut.PositionPacMan(pacmanItem, Position.RIGHT);
            Assert.AreEqual(pacmanItem.direction, Direction.WEST);
        }

        [TestMethod]
        public void PositionPacMan_WestRight_Pass()
        {
            PlayPacman sut = new PlayPacman(_Logger);
            var pacmanItem = new Pacman() { X = 0, Y = 0, direction = Direction.WEST };
            var movedItem = sut.PositionPacMan(pacmanItem, Position.RIGHT);
            Assert.AreEqual(pacmanItem.direction, Direction.NORTH);
        }



    }
}
