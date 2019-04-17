/*
 * Brady Berner
 * CST-227
 * 12-16-18
 * This is my own work
*/

using CLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLC
{
    public class GameService : Grid
    {
        //List that stores all the cells to be iterated over by the recursive method
        private List<Cell> queue = new List<Cell>();
        //List that stores all the cells that have already been iterated over by the recursive method
        private List<Cell> finished = new List<Cell>();
        //Stopwatch that tracks the time that the game has been running
        private System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
        //Integer that represents the user's current score defaults to -1 unless they win the game
        private int score = -1;


        //constructor that takes int size as an argument and passes that int to the base constructor
        internal GameService(int size) : base(size: size)
        {
            assignLive();
            assignNumbers();
            time.Start();
        }

        public int Score { get => score; }

        //method that assigns a random percentage of cells between 15 and 20 percent as mines
        private void assignLive()
        {
            Random r = new Random();
            int liveNum = (int)Math.Round((Math.Pow(Size, 2) * (r.Next(15, 21) / 100.0)));
            int[] Xselected = new int[liveNum];
            int[] Yselected = new int[liveNum];

            for (int i = 0; i < liveNum; i++)
            {
                Xselected[i] = r.Next(Size);
                Yselected[i] = r.Next(Size);

                if (!Array[Xselected[i], Yselected[i]].Live)
                {
                    Array[Xselected[i], Yselected[i]].makeMine();
                }
                else
                {
                    i--;
                }
            }
        }

        //This method goes through each and every cell in the grid if the cell it's currently on is a mine then the method goes into
        // a second nested for-loop which iterates over the eight surrounding cells and adds one to their surrounding count
        private void assignNumbers()
        {
            foreach (Cell c in Array)
            {
                if (c.Live)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        for (int x = -1; x < 2; x++)
                        {
                            if (x != 0 || y != 0)
                            {
                                try
                                {
                                    Array[(c.Col + x), (c.Row + y)].add();
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }

        //This method goes through the queue of cells and checks the surrounding cells for each of those cells and either reveals them or adds them to queue.
        //This method continually calls upon itself until it ultimatly clears out the entire cell queue thereby revealing all the 0 cells and their immediately
        //bordering numbered cells.
        private void cascade()
        {
            queue = queue.Except(finished).ToList();

            if (queue.Count == 0)
            {
                return;
            }

            int x = queue[0].Col;
            int y = queue[0].Row;
            Array[x, y].reveal();

            for (int y1 = -1; y1 < 2; y1++)
            {
                for (int x1 = -1; x1 < 2; x1++)
                {
                    if (x1 != 0 || y1 != 0)
                    {
                        try
                        {
                            if (!Array[(x + x1), (y + y1)].Revealed && Array[(x + x1), (y + y1)].Surrounding == 0)
                            {
                                queue.Add(new Cell(x + x1, y + y1));
                            }
                            else if (!Array[(x + x1), (y + y1)].Revealed)
                            {
                                Array[(x + x1), (y + y1)].reveal();
                            }
                        }
                        catch { }
                    }
                }
            }

            finished.Add(new Cell(x, y));
            queue.RemoveAt(0);

            if (queue.Count != 0)
            {
                cascade();
            }
        }

        //Method that handles all of the game logic from when a cell is selected by the user clicking on it
        public bool playGame(Cell b, bool righClick)
        {
            if (righClick)
            {
                b.flag();
                return true;
            }

            if (!b.Flagged)
            {
                if (b.Live)
                {
                    foreach (Cell c in Array)
                    {
                        if (c.Flagged)
                        {
                            c.flag();
                        }
                        c.reveal();
                    }

                    time.Stop();
                    //MessageBox.Show("Game Over You Lose");
                    //MessageBox.Show(String.Format("You were playing for {0:mm\\:ss}", time.Elapsed));
                    return false;
                }
                else if (b.Surrounding != 0)
                {
                    b.reveal();
                }
                else
                {
                    queue.Add(b);
                    cascade();
                }

                if (winCheck())
                {
                    //MessageBox.Show("You Win");
                    //MessageBox.Show(String.Format("It took you {0:mm\\:ss} to win", time.Elapsed));
                    return false;
                }
            }

            return true;
        }

        //method iterates over the array and returns false if not every non-mine cell has been revealed otherwise it returns true
        private bool winCheck()
        {

            foreach (Cell c in Array)
            {
                if (!c.Live && !c.Revealed)
                {
                    return false;
                }
            }

            time.Stop();

            String s = String.Format("{0:mm\\:ss}", time.Elapsed);
            s = s.Remove(s.IndexOf(':'), 1);

            score = Int32.Parse(s);

            return true;
        }
    }
}
