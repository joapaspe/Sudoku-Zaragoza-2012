namespace MainSudoku
{
    partial class MainSudokuForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadSudoku = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.SolveButton = new System.Windows.Forms.Button();
            this.sudokuGrid1 = new MainSudoku.SudokuGrid();
            this.SuspendLayout();
            // 
            // LoadSudoku
            // 
            this.LoadSudoku.Location = new System.Drawing.Point(714, 57);
            this.LoadSudoku.Name = "LoadSudoku";
            this.LoadSudoku.Size = new System.Drawing.Size(203, 39);
            this.LoadSudoku.TabIndex = 0;
            this.LoadSudoku.Text = "LoadSudoku";
            this.LoadSudoku.UseVisualStyleBackColor = true;
            this.LoadSudoku.Click += new System.EventHandler(this.LoadSudoku_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(714, 342);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(203, 43);
            this.checkButton.TabIndex = 3;
            this.checkButton.Text = "Check Sudoku";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(714, 412);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(203, 43);
            this.SolveButton.TabIndex = 4;
            this.SolveButton.Text = "Solve Sudoku";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // sudokuGrid1
            // 
            this.sudokuGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sudokuGrid1.Location = new System.Drawing.Point(12, 12);
            this.sudokuGrid1.Name = "sudokuGrid1";
            this.sudokuGrid1.Size = new System.Drawing.Size(696, 515);
            this.sudokuGrid1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 539);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.sudokuGrid1);
            this.Controls.Add(this.LoadSudoku);
            this.Name = "Form1";
            this.Text = "Sudoku Puzzle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadSudoku;
        private SudokuGrid sudokuGrid1;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button SolveButton;
    }
}

