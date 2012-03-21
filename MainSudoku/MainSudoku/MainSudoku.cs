using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainSudoku
{
    public partial class MainSudokuForm : Form
    {
        /// <summary>
        /// Link to the sudoku data
        /// </summary>
        private SudokuData currentPuzzle;

        /// <summary>
        /// Main Form of the application
        /// </summary>
        public MainSudokuForm()
        {
            InitializeComponent();

            currentPuzzle = new SudokuData();

        }

        /// <summary>
        /// Button event that open a sudoku file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSudoku_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            
            DialogResult res;

            res = opf.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                
                currentPuzzle.loadFromFile(opf.FileName);
                
                this.sudokuGrid1.Hide();
                this.sudokuGrid1.generateControls(currentPuzzle);
                this.sudokuGrid1.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }



        /// <summary>
        /// Button that checks if the sudoku is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkButton_Click(object sender, EventArgs e)
        {
            
            if (currentPuzzle.checkSudoku() == false)
            {
                MessageBox.Show("The sudoku contains mistakes!", "Checking sudoku", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else{
                if(currentPuzzle.Complete())
                    MessageBox.Show("Congratulations! The sudoku puzzle has been succesfully complete.","Checking sudoku", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("The sudoku doesn't contain any mistake", "Checking sudoku", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Button that solves the sudoku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SolveButton_Click(object sender, EventArgs e)
        {
            currentPuzzle.SolveSudoku();

            sudokuGrid1.WriteNumbers();
        }
    }
}
