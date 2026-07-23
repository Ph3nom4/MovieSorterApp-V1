namespace MovieSorterApp1
{
    partial class Movies
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_All = new Button();
            btn_Minimize = new Button();
            btn_Fullscreen = new Button();
            button3 = new Button();
            btnScan = new Button();
            button1 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            btn_Minimized = new Button();
            btn_Full = new Button();
            btn_Exit = new Button();
            tb_Search = new TextBox();
            label2 = new Label();
            flowMovies = new NoScrollFlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_All
            // 
            btn_All.BackColor = Color.Transparent;
            btn_All.FlatAppearance.BorderSize = 0;
            btn_All.FlatAppearance.MouseDownBackColor = Color.Red;
            btn_All.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_All.FlatStyle = FlatStyle.Flat;
            btn_All.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_All.ForeColor = SystemColors.Control;
            btn_All.Location = new Point(233, 28);
            btn_All.Name = "btn_All";
            btn_All.Size = new Size(75, 23);
            btn_All.TabIndex = 6;
            btn_All.Text = "Movies";
            btn_All.UseVisualStyleBackColor = false;
            // 
            // btn_Minimize
            // 
            btn_Minimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Minimize.BackColor = Color.Transparent;
            btn_Minimize.FlatAppearance.BorderSize = 0;
            btn_Minimize.FlatStyle = FlatStyle.Flat;
            btn_Minimize.ForeColor = SystemColors.Control;
            btn_Minimize.Location = new Point(1985, 1);
            btn_Minimize.Name = "btn_Minimize";
            btn_Minimize.Size = new Size(37, 23);
            btn_Minimize.TabIndex = 5;
            btn_Minimize.Text = "🗕";
            btn_Minimize.UseVisualStyleBackColor = false;
            // 
            // btn_Fullscreen
            // 
            btn_Fullscreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Fullscreen.BackColor = Color.Transparent;
            btn_Fullscreen.FlatAppearance.BorderSize = 0;
            btn_Fullscreen.FlatStyle = FlatStyle.Flat;
            btn_Fullscreen.ForeColor = SystemColors.Control;
            btn_Fullscreen.Location = new Point(2021, 2);
            btn_Fullscreen.Name = "btn_Fullscreen";
            btn_Fullscreen.Size = new Size(32, 23);
            btn_Fullscreen.TabIndex = 4;
            btn_Fullscreen.Text = "□  ";
            btn_Fullscreen.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(2047, 2);
            button3.Name = "button3";
            button3.Size = new Size(43, 23);
            button3.TabIndex = 3;
            button3.Text = "x";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnScan
            // 
            btnScan.FlatAppearance.BorderSize = 0;
            btnScan.FlatAppearance.MouseDownBackColor = Color.Red;
            btnScan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnScan.FlatStyle = FlatStyle.Flat;
            btnScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScan.ForeColor = Color.White;
            btnScan.Location = new Point(309, 27);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(80, 26);
            btnScan.TabIndex = 0;
            btnScan.Text = "Scan Files";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 9, 20);
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(166, 27);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(19, 16);
            label1.Name = "label1";
            label1.Size = new Size(134, 37);
            label1.TabIndex = 0;
            label1.Text = "SCANFLIX";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(btn_Minimized);
            panel1.Controls.Add(btn_Full);
            panel1.Controls.Add(btn_Exit);
            panel1.Controls.Add(btn_All);
            panel1.Controls.Add(btn_Minimize);
            panel1.Controls.Add(btn_Fullscreen);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btnScan);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1149, 67);
            panel1.TabIndex = 3;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // btn_Minimized
            // 
            btn_Minimized.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Minimized.BackColor = Color.Transparent;
            btn_Minimized.FlatAppearance.BorderSize = 0;
            btn_Minimized.FlatStyle = FlatStyle.Flat;
            btn_Minimized.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Minimized.ForeColor = SystemColors.Control;
            btn_Minimized.Location = new Point(1054, 1);
            btn_Minimized.Name = "btn_Minimized";
            btn_Minimized.Size = new Size(32, 23);
            btn_Minimized.TabIndex = 9;
            btn_Minimized.Text = "🗕";
            btn_Minimized.UseVisualStyleBackColor = false;
            btn_Minimized.Click += btn_Minimized_Click_1;
            // 
            // btn_Full
            // 
            btn_Full.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Full.BackColor = Color.Transparent;
            btn_Full.FlatAppearance.BorderSize = 0;
            btn_Full.FlatStyle = FlatStyle.Flat;
            btn_Full.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Full.ForeColor = SystemColors.Control;
            btn_Full.Location = new Point(1092, 2);
            btn_Full.Name = "btn_Full";
            btn_Full.Size = new Size(32, 23);
            btn_Full.TabIndex = 8;
            btn_Full.Text = "□  ";
            btn_Full.UseVisualStyleBackColor = false;
            btn_Full.Click += btn_Full_Click_1;
            // 
            // btn_Exit
            // 
            btn_Exit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.FlatAppearance.BorderSize = 0;
            btn_Exit.FlatStyle = FlatStyle.Flat;
            btn_Exit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Location = new Point(1118, 3);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(43, 23);
            btn_Exit.TabIndex = 7;
            btn_Exit.Text = "x";
            btn_Exit.UseVisualStyleBackColor = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // tb_Search
            // 
            tb_Search.BackColor = Color.FromArgb(8, 8, 8);
            tb_Search.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_Search.ForeColor = SystemColors.Window;
            tb_Search.Location = new Point(271, 142);
            tb_Search.Multiline = true;
            tb_Search.Name = "tb_Search";
            tb_Search.Size = new Size(653, 36);
            tb_Search.TabIndex = 10;
            tb_Search.TextChanged += tb_Search_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(19, 129);
            label2.Name = "label2";
            label2.Size = new Size(172, 40);
            label2.TabIndex = 5;
            label2.Text = "Your Movies";
            // 
            // flowMovies
            // 
            flowMovies.AutoScroll = true;
            flowMovies.Location = new Point(19, 208);
            flowMovies.Name = "flowMovies";
            flowMovies.Size = new Size(1098, 764);
            flowMovies.TabIndex = 4;
            flowMovies.Paint += flowMovies_Paint;
            // 
            // Movies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(8, 8, 8);
            ClientSize = new Size(1149, 1012);
            Controls.Add(flowMovies);
            Controls.Add(tb_Search);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Movies";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movies";
            Load += Movies_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_All;
        private Button btn_Minimize;
        private Button btn_Fullscreen;
        private Button button3;
        private Button btnScan;
        private Button button1;
        private Label label1;
        private Panel panel1;
        private Button button2;
        private Button button4;
        private Button btn_Exit;
        private Button btn_Minimized;
        private Button btn_Full;
        private TextBox tb_Search;
        private Label label2;
        private NoScrollFlowLayoutPanel flowMovies;
    }
}