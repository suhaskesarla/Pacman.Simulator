using System;
using System.Web.Mvc;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pacman.Simulator;
using Pacman.UI.Controllers;

namespace Pacman.UI.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private static ILog _Logger;
        private IPlayPacman _service;

        [TestInitialize]
        public void Initalize()
        {
            _Logger = (new Mock<ILog>()).Object;
            _service = (new Mock<IPlayPacman>()).Object;
        }
        [TestMethod]
        public void Index_PacmanPlace_Pass()
        {
            HomeController sut = new HomeController(_service,_Logger);
            string pacmanAction = "PLACE";
            var pacmanItem = new Simulator.Pacman() { X = 1, Y = 0, direction = Direction.NORTH };
            var result = sut.Index(pacmanItem, pacmanAction) as ViewResult;
            Assert.AreEqual(true,result.ViewName.Contains("Index"));
        }
    }
}
