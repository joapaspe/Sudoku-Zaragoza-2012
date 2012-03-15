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
    public partial class Form1 : Form
    {

        private SudokuData currentPuzzle;

        public Form1()
        {
            InitializeComponent();

            currentPuzzle = new SudokuData();

        }

        private void LoadSudoku_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            
            DialogResult res;

            res = opf.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                //TODO: Show Spin
                currentPuzzle.loadFromFile(opf.FileName);
                //MessageBox.Show(currentPuzzle.ToString());
                this.sudokuGrid1.Hide();
                this.sudokuGrid1.generateControls(currentPuzzle);
                this.sudokuGrid1.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }



        private void inkEdit1_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void SolveButton_Click(object sender, EventArgs e)
        {
            currentPuzzle.SolveSudoku();

            sudokuGrid1.WriteNumbers();
        }
    }
}
