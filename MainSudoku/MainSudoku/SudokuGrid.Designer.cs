namespace MainSudoku
{
    partial class SudokuGrid
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // gridLayout
            // 
            this.gridLayout.ColumnCount = 9;
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.gridLayout.Location = new System.Drawing.Point(15, 16);
            this.gridLayout.Name = "gridLayout";
            this.gridLayout.RowCount = 9;
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.Size = new System.Drawing.Size(460, 400);
            this.gridLayout.TabIndex = 0;
            // 
            // SudokuGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gridLayout);
            this.Name = "SudokuGrid";
            this.Size = new System.Drawing.Size(495, 429);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel gridLayout;
    }
}
