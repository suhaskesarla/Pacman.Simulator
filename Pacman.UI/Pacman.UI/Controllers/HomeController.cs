using log4net;
using Pacman.Simulator;
using System.Web.Mvc;

namespace Pacman.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        private IPlayPacman _service;
        private ILog _logger;
        public HomeController(IPlayPacman service,ILog logger)
        {
            this._logger = logger;
            this._service = service;
        }
        public ActionResult Index(Pacman.Simulator.Pacman item, string pacmanAction)
        {
            
           
            switch (pacmanAction)
            {
                case "PLACE":
                    {
                        item = _service.Place(item.X, item.Y, item.direction);
                        break;
                    }
                case "MOVE":
                    {
                        item = _service.MovePacMan(item);
                        break;
                    }
                case "LEFT":
                    {
                        item = _service.PositionPacMan(item,Position.LEFT);
                        break;
                    }
                case "RIGHT":
                    {
                        item = _service.PositionPacMan(item, Position.RIGHT);
                        break;
                    }
                default:
                    break;
            }
            ModelState.Clear();
           
            return View("/Views/Home/Index.cshtml",item);
        }


    }
}