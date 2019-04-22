using CLC.Models;
using System;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class MinesweeperController : Controller
    {
        private static GameService game;
        private static int size;

        public GameService Game { get => game; }

        [HttpGet]
        public ActionResult Index()
        {
            size = 9;

            game = new GameService(size);
            
            return View("Minesweeper");
        }
        
        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult Click(string cell)
        {
            string[] s = cell.Split(',');

            game.playGame(game.Array[Int32.Parse(s[0]), Int32.Parse(s[1])], false);

            return PartialView("_Minesweeper", game);
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult RightClick(int col, int row)
        { 
            game.playGame(game.Array[col, row], true);

            return PartialView("_Minesweeper", game);
        }

        [OutputCache(Duration = 0)]
        public ActionResult getBoard()
        {
            return PartialView("_Minesweeper", game);
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult save()
        {
            Session.Add("game", game);

            return View("Minesweeper");
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult load()
        {
            if(Session["game"] != null)
            {
                game = (GameService)Session["game"];
            }

            return View("Minesweeper");
        }
    }
}