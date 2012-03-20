using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace MainSudoku
{

    /// <summary>
    /// This class has the sudoku internal data. This we store the Matrix of numbers and we compute algorithms to solve/check if the sudoku is solved.
    /// </summary>
    public class SudokuData
    {
        
        //private const int SIZE = 9;

        /// <summary>
        ///  A Matrix, usually 9x9, that contains the information of the sudoku.
        /// </summary>
        int [,]userMatrix;
        //public int [,]solMatrix;

        /// <summary>
        /// Internal Matrix, that says if a number is fixed. There are the fixed numbers that have the sudoku at the very beginning.
        /// </summary>
        bool[,] isFixed;

        #region Initialization_Members
        /// <summary>
        /// Creates the sudoku data, but does not load a file.
        /// </summary>
        public SudokuData()
        {
            userMatrix = new int[9,9];
            //solMatrix = new int[SIZE, SIZE];
            isFixed = new bool[9, 9];
               
        }

        /// <summary>
        /// Accesor methods to the data Matrix
        /// </summary>
        /// <param name="row">Row of the number</param>
        /// <param name="col">Column of the number</param>
        /// <returns></returns>
        public int this[int  row, int col]{

            get{
            return userMatrix[row,col];
            }
            set
            {
                userMatrix[row, col] = value;
            }
        }


        /// <summary>
        /// Takes a filename, with a valid sudoku (check syntax), and loads the data information
        /// </summary>
        /// <param name="filename">Route to the file with the sudoku</param>
        public void loadFromFile(string filename)
        {
        
            
            
        using (StreamReader reader = new StreamReader(filename))
	    {
            char l;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    l = (char)reader.Read();
                    if (char.IsDigit(l))
                    {
                        int num = l - '0';
                        this.userMatrix[i,j] = num;
                        //this.solMatrix[i, j] = num;
                        this.isFixed[i, j] = true;
                    }
                    else if (l == '.')
                    {

                        this.userMatrix[i, j] = -1;
                        //this.solMatrix[i, j] = -1;
                        this.isFixed[i, j] = false;
                    }

                   
                }
                //CRLF
                reader.Read();
                reader.Read();
            }
	    
	    
	    }


        }

        /// <summary>
        /// Returns a well formated string with the data of the sudoku
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str="";

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    str += this.userMatrix[i, j] + "\t|\t";
                }
                str += "\n";
            }
            

            return str;
        }
        #endregion

        #region sudoku_checking_tools

        /// <summary>
        /// Checks if the sudoku has any inconsistence.
        /// </summary>
        /// <returns>If the sudoku is stable: True; Else: False</returns>
        public bool checkSudoku()
        {
            
            bool bValidSudoku = true;

            for (int i = 1; i <= 9; i++)
            {
                for (int m = 0; bValidSudoku == true & m < 9; m++)
                {
                    // validar cada fila
                    int nVeces = 0;
                    for (int n = 0; n < 9; n++)
                    {
                        if (this.userMatrix[m, n] == i) nVeces++;
                    }
                    if (nVeces > 1) bValidSudoku = false;
                }
                for (int n = 0; bValidSudoku == true & n < 9; n++)
                {
                    // validar cada columna
                    int nVeces = 0;
                    for (int m = 0; m < 9; m++)
                    {
                        if (this.userMatrix[m, n] == i) nVeces++;
                    }
                    if (nVeces > 1) bValidSudoku = false;
                }
            }
            // validar cada caja
            for (int m = 0; bValidSudoku == true & m < 2; m++)
            {
                for (int n = 0; bValidSudoku == true & n < 2; n++)
                {
                    int x = 1;
                    while (bValidSudoku == true & x <= 9)
                    {
                        int nVeces = 0;
                        for (int i = m * 3; i <= m * 3 + 2; i++)
                        {
                            for (int j = n * 3; j <= n * 3 + 2; j++)
                            {
                                if (this.userMatrix[i, j] == x) nVeces++;
                            }
                        }
                        if (nVeces > 1) bValidSudoku = false;
                        x++;
                    }
                }
            }
            return bValidSudoku;
        }

        /// <summary>
        /// Checks if a single cell of the sudoku is consistent
        /// </summary>
        /// <param name="x">Row of the cell</param>
        /// <param name="y"></param>
        /// <param name="M"></param>
        /// <returns>True if the content of the cell is consistent</returns>
        public bool checkCell(int x, int y)
        {

            int[,] M = this.userMatrix;
            //Check the row
            int times = 0;
            for(int n = 1; n <=9; ++n){
                times = 0;
                for(int j = 0; j < 9; ++j){
                    if (M[x,j] == n){
                        ++times;
                        }
                    if(times > 1)
                        return false;
                }
               }
            
            //Check the column
            
            for(int n = 1; n <=9; ++n){
                times = 0;
                for(int i = 0; i < 9; ++i){
                    if (M[i,y] == n){
                        ++times;
                        }
                    if(times > 1)
                        return false;
                }
               }

            for (int n = 1; n <= 9; ++n)
            {
                times = 0;
                for (int i = (x/3)*3; i < ((x / 3)*3)+3; i++)
                {
                    for (int j = (y/3)*3; j < ((y / 3)*3) + 3; j++)
                    {
                        if (M[i, j] == n) ++times;
                    }

                    if (times > 1)
                        return false;
                }
                
            }
            return true;


            
        }
        /// <summary>
        /// Checks if all the cells are filled. Used to know
        /// </summary>
        /// <returns>If all the cels are file return True. Else returns False</returns>
        public bool Complete()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.userMatrix[i, j] == -1)
                        return false;
                }
            }
            return true;
        }

        #endregion


        #region Sudoku_Solver

        /// <summary>
        /// Backtracking algorithm that solves the sudoku.
        /// </summary>
        /// <param name="x">Row</param>
        /// <param name="y">Column</param>
        /// <returns>Return if is it posible to solve the sudoku</returns>
        private bool BacktrackSolve(int x, int y)
        {


            int[,] M = this.userMatrix;

            if (isFixed[x, y])
            {
               // myLog.WriteLine(String.Format("{0} {1}", x, y));
                if (x == 8 && y == 8)
                {
                    return true;


                }
                else if (x < 8 && y == 8)
                {
                    if (BacktrackSolve(x + 1, 0)) return true;

                }
                else if (x <= 8 && y < 8)
                    if (BacktrackSolve(x, y + 1)) return true;
            }

            else
            {
                for (int n = 1; n <= 9; ++n)
                {
                    //myLog.WriteLine(String.Format("{0} {1} {2}", x, y, n));

                    M[x, y] = n;

                    if (checkCell(x, y))
                    {

                        if (x == 8 && y == 8)
                        {
                            return true;


                        }
                        else if (x < 8 && y == 8)
                        {
                            if (BacktrackSolve(x + 1, 0)) return true;
                            
                        }
                        else if (x <= 8 && y < 8)
                            if (BacktrackSolve(x, y + 1)) return true;

                    }


                }
            }

            if (!isFixed[x, y]) M[x, y] = -1;
            return false;

        }


        /// <summary>
        /// Solves the Sudoku
        /// </summary>
        /// <returns></returns>
        public bool SolveSudoku()
        {

            //Branch and pruning
            if (!this.checkSudoku()) return false;

            return BacktrackSolve(0, 0);



        }

        #endregion



    }
    
}
