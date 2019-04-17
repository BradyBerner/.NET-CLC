using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC.Models
{
    public class Grid
    {
        private Cell[,] grid;
        private int size;

        public Grid(int size)
        {
            this.size = size;
            grid = new Cell[size, size];

            for(int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    grid[x, y] = new Cell(x, y);
                }
            }
        }

        public int Size { get => size; }
        public Cell[,] Array { get => grid; }
    }
}