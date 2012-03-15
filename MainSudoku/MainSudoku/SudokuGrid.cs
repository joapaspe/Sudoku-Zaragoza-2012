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

        
        private class CellTextBox : InkEdit
        {

            int _row;
            int _col;


            

            public int row
            {
                get
                {
                    return _row;
                }

            }

            public int col
            {
                get
                {
                    return _col;

                }

            }


            public CellTextBox(int r, int c, int height)
            {
                _row = r;
                _col = c;
                this.Factoid = "Digit";
                //this.TextAlign = HorizontalAlignment.Center;
                
                //this.Height= height;
                this.SelectionAlignment = HorizontalAlignment.Center;
                
                
                this.Font = new Font("Arial", height/2);
                this.UseMouseForInput = true;
                
                Multiline = false;

                


                //ReadOnly = true;
                //BorderStyle = BorderStyle.None;
                //BackColor = //parnet control back color
                //SelectionChanged += new System.EventHandler(TransparentLabel_SelectionChanged);
                //GotFocus += new System.EventHandler(TransparentLabel_GotFocus);
                //to remove the selection made by user
                
            }
            protected override void OnRecognition(InkEditRecognitionEventArgs e)
            {

                base.OnRecognition(e);
                

            }

            
        }
      

        #region Recognizer
        /*Recognizer Tools*/

        //Recognizers recs;

        //Recognizer reco;
        //RecognizerContext context;
        //InkOverlay inkOverlay;

        #endregion

        public SudokuData mySudoku;
        CellTextBox[,] ctMatrix;


        public SudokuGrid()
        {
            InitializeComponent();
            //TODO: Create the Recognizer Instance
            //recs = new Recognizers();
            
            ctMatrix = new CellTextBox[9,9];
            //reco = recs.GetDefaultRecognizer();
            //context = reco.CreateRecognizerContext();
            //context.Factoid = "DIGIT";
            //inkOverlay = new InkOverlay();
        }

        public void generateControls(SudokuData sudoku){

              // Arrange the buttons in a grid on the form

              this.mySudoku = sudoku;
              int cx = ClientRectangle.Width/9;
              int cy = ClientRectangle.Height/9;

              var margin = new System.Windows.Forms.Padding(2);
              gridLayout.Margin = margin;
              int totalMargin = (gridLayout.Margin.All*8) + margin.All*10;
              EventHandler TxtChg = new EventHandler(CellText_TextChanged);
              InkEditGestureEventHandler TxtGst = new InkEditGestureEventHandler(CellText_Gesture);

              gridLayout.Controls.Clear();

              for( int row = 0; row != sudoku.getSize; ++row ) {

               for( int col = 0; col != sudoku.getSize; ++col ) {
                   
                   
                  CellTextBox ct = new CellTextBox(row, col, cy);
                       
                       
                       //ct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                       
                       //ct.BorderStyle = new BorderStyle();
                  ct.TextChanged += TxtChg;
                  ct.Gesture += TxtGst;

                   if (sudoku[row, col] != -1)
                   {
                       ct.Text = sudoku[row, col].ToString();

                       ct.Enabled = false;
        
                       
                   
                   }
                   ct.Margin = margin;

                   ct.Width = (gridLayout.Width - totalMargin) / 9;
                   ct.Height = (gridLayout.Height - totalMargin) / 9;
                   
                   gridLayout.Controls.Add(ct, col, row);
                   ctMatrix[row, col] = ct;

                   //control.SetBounds(cx * row, cy * col, cx, cy);
                  // this.Controls.Add(control);
                  
            }

            
          

               
    }



        }

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
        private void CellText_Gesture(object sender, Microsoft.Ink.InkEditGestureEventArgs e)
        {

            CellTextBox ct = sender as CellTextBox;

            //MessageBox.Show("Gesture recognized");
            if (e.Gestures[0].Id == ApplicationGesture.Left || e.Gestures[0].Id == ApplicationGesture.Right)
            {
                ct.Text = " ";

            }

        }



        private void CellText_TextChanged(object sender, EventArgs e)
        {
            CellTextBox ct = sender as CellTextBox;

            if (String.IsNullOrWhiteSpace(ct.Text))
            {
                mySudoku[ct.row, ct.col] = -1;
            }
                
            int num = -1;
            bool valid = true;

            try
            {
                num = Int32.Parse(ct.Text);
            }
            catch (Exception exception)
            {
                
                valid = false;
            }
            if (num <= 0 || num > 9)
            {
                valid = false;
                
            }
            if (!valid)
            {

                ct.Text = String.Empty;
                ct.SelectionAlignment = HorizontalAlignment.Center;
                int previewValue = mySudoku[ct.row, ct.col];
                if( previewValue != -1)
                    ct.Text = previewValue.ToString();
                    
                return;
            }

            mySudoku[ct.row, ct.col] = num;
            ct.SelectionAlignment = HorizontalAlignment.Center;
        #endregion

        }

        //private int Recognize()
        //{
        //    context.Strokes = inkOverlay.Ink.Strokes;
        //    int digit = -1;
            
        //    if (context.Strokes.Count == 0) return -1;

        //    RecognitionStatus status = RecognitionStatus.NoError;
        //    //context.Factoid = "DIGIT";
        //    RecognitionResult res = context.Recognize(out status);

        //    if (status == RecognitionStatus.NoError)
        //    {
        //        try
        //        {
        //            digit = Int32.Parse(res.TopAlternate.ToString());
        //        }
        //        catch(Exception e)
        //        {
        //            digit = -1;
        //        }
                

        //        //MessageBox.Show(res.TopAlternate.ToString());
        //        return digit;
        //    }
            
            //return -1;
        //}
    }
}
