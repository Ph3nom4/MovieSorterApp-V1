namespace MovieSorterApp1
{
    partial class MoviesPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowMovies = new NoScrollFlowLayoutPanel();
            tb_Search = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // flowMovies
            // 
            flowMovies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowMovies.AutoScroll = true;
            flowMovies.Location = new Point(15, 164);
            flowMovies.Name = "flowMovies";
            flowMovies.Size = new Size(1098, 764);
            flowMovies.TabIndex = 11;
            flowMovies.Paint += flowMovies_Paint;
            // 
            // tb_Search
            // 
            tb_Search.BackColor = Color.FromArgb(8, 8, 8);
            tb_Search.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_Search.ForeColor = SystemColors.Window;
            tb_Search.Location = new Point(267, 98);
            tb_Search.Multiline = true;
            tb_Search.Name = "tb_Search";
            tb_Search.Size = new Size(653, 36);
            tb_Search.TabIndex = 13;
            tb_Search.TextChanged += tb_Search_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(34, 94);
            label1.Name = "label1";
            label1.Size = new Size(172, 40);
            label1.TabIndex = 12;
            label1.Text = "Your Movies";
            // 
            // MoviesPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(8, 8, 8);
            Controls.Add(flowMovies);
            Controls.Add(tb_Search);
            Controls.Add(label1);
            Name = "MoviesPage";
            Size = new Size(1129, 1012);
            Load += MoviesPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NoScrollFlowLayoutPanel flowMovies;
        private TextBox tb_Search;
        private Label label1;
    }
}
