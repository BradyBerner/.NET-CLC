/*
 * Brady Berner
 * CST-227
 * 12-16-18
 * This is my own work
*/

namespace CLC.Models
{
    public class Cell
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
        private string image = "clicked.png";
        //bool that denotes whether the cell has been flagged or not
        private bool flagged;
        private bool revealed = false;

        //constructor that takes the column and row as integer arguments
        internal Cell(int col, int row)
        {
            this.col = col;
            this.row = row;
        }

        //Getters for all properties of the cell aside from the image string
        public bool Live { get => live; }
        public int Row { get => row; }
        public int Col { get => col; }
        public int Surrounding { get => surrounding; }
        public string Image { get => image; }
        public bool Flagged { get => flagged; }
        public bool Revealed { get => revealed; }

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
                revealed = true;
                //if (image != null)
                //{
                //    Bitmap img = new Bitmap(image);
                //    BackgroundImage = new Bitmap(img, Width, Height);
                //}
            }
        }

        //Method that flags or unflags the cell depending on the current state of the cell
        internal void flag()
        {
            if (flagged)
            {
                image = "static.png";
            }
            else
            {
                image = "flag.png";
            }

            flagged = !flagged;
        }

        public string toString()
        {
            return col + "," + row;
        }
    }
}
