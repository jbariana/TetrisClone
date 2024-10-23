using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }


        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        //constructor
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        //checks if a certain point is inside the grid 
        //point is > 0 and is lower than max value for row and column
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        //checks if a point is empty currently
        //is inside the grid and has a value of 0
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        //checks if a current row is full by returning false if any column in that row is empty
        // otherwise returns true
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //checks if a row is empty by returning false if any of the columns in that row are not 0
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r,c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //clears row by looping through all columns on a given row and setting it equal to 0
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        //moves rows down by a set value
        private void MoveRowDown(int r, int numRows)
        {
            //loops through whole row
            for(int c = 0; c < Columns; c++)
            {
                //sets row numRows down from current equal to current row
                grid[r+numRows, c] = grid[r, c];

                //clears current row
                grid[r, c] = 0;
            }
        }

        //implements clearing logic
        public int ClearFullRows()
        {
            int cleared = 0;

            //goes through all rows
            for (int r = Rows-1; r >=0; r--)
            {
                //if row is full, clear and increment clear
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                //if row is not full and we have cleared rows, move current row down
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
