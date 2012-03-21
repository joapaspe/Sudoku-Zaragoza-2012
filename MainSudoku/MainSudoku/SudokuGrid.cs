using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace MainSudoku
{
    public partial class SudokuGrid : UserControl
    {

        #region InkEdit Control
        /// <summary>
        /// InkEdit Modified control for the Sudoku Control
        /// </summary>
        private class CellTextBox : InkEdit
        {
            #region Control_Variables
            /// <summary>
            /// We store the row information of the control
            /// </summary>
            int _row;
            /// <summary>
            /// We store the column information of the control
            /// </summary>
            int _col;
                       
            /// <summary>
            /// Accesor to the row of the control
            /// </summary>
            public int row
            {
                get
                {
                    return _row;
                }

            }
            /// <summary>
            /// Accesor to the column of the control
            /// </summary>
            public int col
            {
                get
                {
                    return _col;

                }

            }

            #endregion

            /// <summary>
            /// Constructor of the control
            /// </summary>
            /// <param name="r"></param>
            /// <param name="c"></param>
            /// <param name="height"></param>
            public CellTextBox(int r, int c, int height)
            {
                _row = r;
                _col = c;

                //Control design information
                this.SelectionAlignment = HorizontalAlignment.Center;
                Multiline = false;
                this.Font = new Font("Arial", height / 2);
                

                ///TODO:
                this.Factoid = "Digit";
                this.UseMouseForInput = true;
                
           }
            /// <summary>
            /// Recognition Event
            /// </summary>
            /// <param name="e"></param>
            protected override void OnRecognition(InkEditRecognitionEventArgs e)
            {

                base.OnRecognition(e);
                

            }

            
        }
        #endregion

        /// <summary>
        /// A link to the sudoku data
        /// </summary>
        public SudokuData mySudoku;

        /// <summary>
        /// Matrix with the controls
        /// </summary>
        CellTextBox[,] ctMatrix;

        /// <summary>
        /// Constructor of the sudoku grid. This not draw any cell.
        /// </summary>
        public SudokuGrid()
        {
            InitializeComponent();
            ctMatrix = new CellTextBox[9,9];

        }

        /// <summary>
        ///  Arrange the buttons in a grid on the form
        /// </summary>
        /// <param name="sudoku">Sudoku Object with data</param>
        public void generateControls(SudokuData sudoku){
                  

              this.mySudoku = sudoku;

              #region size_and_look
              int cx = ClientRectangle.Width/9;
              int cy = ClientRectangle.Height/9;

              var margin = new System.Windows.Forms.Padding(2);
              gridLayout.Margin = margin;
              int totalMargin = (gridLayout.Margin.All*8) + margin.All*10;
              #endregion

              #region Handler_events
              EventHandler TxtChg = new EventHandler(CellText_TextChanged);
              InkEditGestureEventHandler TxtGst = new InkEditGestureEventHandler(CellText_Gesture);
              InkEditRecognitionEventHandler TxtRcg = new InkEditRecognitionEventHandler(CellText_Recognize);
              #endregion

              gridLayout.Controls.Clear();

              // Adding controls to the grid
              for( int row = 0; row != 9; ++row ) {

               for( int col = 0; col != 9; ++col ) {
                   
                  CellTextBox ct = new CellTextBox(row, col, cy);
                   
                  ct.TextChanged += TxtChg;
                  ct.Gesture += TxtGst;
                  ct.Recognition += TxtRcg;
                   
                   if (sudoku[row, col] != -1)
                   {
                       ct.Text = sudoku[row, col].ToString();

                       ct.Enabled = false;

                   }

                   #region Layout
                   ct.Margin = margin;
                   ct.Width = (gridLayout.Width - totalMargin) / 9;
                   ct.Height = (gridLayout.Height - totalMargin) / 9;
                   #endregion

                   gridLayout.Controls.Add(ct, col, row);
                   ctMatrix[row, col] = ct;
                   
                                     
            }

            
          

               
    }



        }
        /// <summary>
        /// Method that draw the numbers of the Matrix data into the controls
        /// </summary>
        public void WriteNumbers()
        {
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; j++)
                {
                    
                    ctMatrix[i, j].Text = mySudoku[i, j].ToString();
                }
            }

        }
        #region CellText_Events

        /// <summary>
        /// Event that detect gestures on the sudoku cell control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellText_Gesture(object sender, Microsoft.Ink.InkEditGestureEventArgs e)
        {
            //TODO: Detect some Gestures and apply actions to this gestures
            // For example if the gesture is ApplicationGestureLeft or Right, erase the content of the cell
            

        }

        /// <summary>
        /// Event that are launched when text is recognized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellText_Recognize(object sender, InkEditRecognitionEventArgs e)
        {
            CellTextBox ct = sender as CellTextBox;


        }

        /// <summary>
        /// Event that is launched when the text of the cell is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellText_TextChanged(object sender, EventArgs e)
        {
            //TODO this event is launched when the content of the Cell changes.
            // When somebody write by keyboard or by hand a number in the cell this function should to check if the introduced text is correct
            // Then you have to asign the value (if correct) to the sudoku Matrix that is used to compute the solution: mySudoku[ct.row,ct.col]
            CellTextBox ct = sender as CellTextBox;

            // If the cell is blanc put -1 (number that represents that is blank cell)
            if (String.IsNullOrWhiteSpace(ct.Text))
            {
                mySudoku[ct.row, ct.col] = -1;
            }
                
            
            ct.SelectionAlignment = HorizontalAlignment.Center;
        #endregion

        }

        private void SudokuGrid_Load(object sender, EventArgs e)
        {

        }

    }
}
