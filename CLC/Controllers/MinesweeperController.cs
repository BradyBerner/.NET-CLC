using CLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class MinesweeperController : Controller
    {
        private static Cell[,] grid;
        private static int size;

            // GET: Minesweeper
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

            return View("Minesweeper", grid);
        }
        
        public ActionResult Click(string cell)
        {
            string[] s = cell.Split(',');

            grid[Int32.Parse(s[0]), Int32.Parse(s[1])].Revealed = !grid[Int32.Parse(s[0]), Int32.Parse(s[1])].Revealed;

            return View("Minesweeper", grid);
        }
    }
}