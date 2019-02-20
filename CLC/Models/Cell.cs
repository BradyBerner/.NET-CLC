/*
 * Brady Berner
 * CST-227
 * 12-16-18
 * This is my own work
*/

using System.Drawing;
using System.Web.UI.WebControls;

namespace CLC.Models
{
    public class Cell : Button
    {
        //bool that denotes whether the cell is a mine or not
        private bool live = false;
        //int that records the row the cell is in
        private int row = -1;
        //int that records the column the cell is in
        private int col = -1;
        //int that represents the number of mines in the immediate vicinity of the cell
        private int surrounding = 0;
        //string that stores the filepath for the image to be displayed on the cell
        private string image;
        //bool that denotes whether the cell has been flagged or not
        private bool flagged;
        private bool revealed = false;

        //constructor that takes the column and row as integer arguments
        internal Cell(int col, int row)
        {
            this.col = col;
            this.row = row;
            Height = 50;
            Width = 50;
        }

        //Getters for all properties of the cell aside from the image string
        internal bool Live { get => live; }
        public int Row { get => row; }
        public int Col { get => col; }
        internal int Surrounding { get => surrounding; }
        internal bool Flagged { get => flagged; }
        public bool Revealed { get => revealed; set => revealed = value; }

        //Method that takes another cell as an argument and checks to see if the other cell and the calling cell are located in the same place
        internal bool isSame(Cell c)
        {
            if (row == c.row && col == c.col)
            {
                return true;
            }

            return false;
        }

        //Method adds one to the count of surrounding mines and sets the appropriate image string
        internal void add()
        {
            if (!live)
            {
                surrounding++;
                image = surrounding.ToString() + ".png";
            }
        }

        //Method that turnes the cell into a mine cell and sets the image accordingly
        internal void makeMine()
        {
            live = true;
            image = "mine.png";
            //Text = "M";
        }

        //Method that reveals the cell by displaying the appropriate image unless the cell is flagged
        internal void reveal()
        {
            if (!flagged)
            {
                Enabled = false;
                BackColor = Color.DarkGray;
                if (image != null)
                {
                    //TODO:: Add in image mapping to the button
                }
            }
        }

        //Method that flags or unflags the cell depending on the current state of the cell
        internal void flag()
        {
            if (flagged)
            {
                //TODO:: Remove image here
            }
            else
            {
                //TODO:: Set background image to flag image
            }

            flagged = !flagged;
        }
    }
}
