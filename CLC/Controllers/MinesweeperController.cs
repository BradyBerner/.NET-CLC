using CLC.Models;
using System;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class MinesweeperController : Controller
    {
        private static Cell[,] grid;
        private static int size;

        public Cell[,] Grid { get => grid; }

        [HttpGet]
        public ActionResult Index()
        {
            size = 9;
            grid = new Cell[size, size];

            for(int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    grid[x, y] = new Cell(x, y);
                }
            }

            return View("Minesweeper");
        }
        
        [HttpPost]
        public ActionResult Click(string cell)
        {
            string[] s = cell.Split(',');

            grid[Int32.Parse(s[0]), Int32.Parse(s[1])].Revealed = !grid[Int32.Parse(s[0]), Int32.Parse(s[1])].Revealed;

            return PartialView("_Minesweeper", grid);
        }

        [OutputCache(Duration = 0)]
        public ActionResult getBoard()
        {
            return PartialView("_Minesweeper", grid);
        }
    }
}