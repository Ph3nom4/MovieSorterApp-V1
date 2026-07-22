namespace MovieSorterApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnScan = new Button();
            panel1 = new Panel();
            btn_Minimize = new Button();
            btn_Fullscreen = new Button();
            button3 = new Button();
            button1 = new Button();
            label1 = new Label();
            flowLayoutPanel1 = new NoScrollFlowLayoutPanel();
            label2 = new Label();
            flowLayoutPanel2 = new NoScrollFlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnScan
            // 
            btnScan.FlatAppearance.BorderSize = 0;
            btnScan.FlatAppearance.MouseDownBackColor = Color.Red;
            btnScan.FlatStyle = FlatStyle.Flat;
            btnScan.ForeColor = Color.White;
            btnScan.Location = new Point(232, 26);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(80, 26);
            btnScan.TabIndex = 0;
            btnScan.Text = "Scan Files";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(btn_Minimize);
            panel1.Controls.Add(btn_Fullscreen);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btnScan);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1129, 67);
            panel1.TabIndex = 2;
            // 
            // btn_Minimize
            // 
            btn_Minimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Minimize.BackColor = Color.Transparent;
            btn_Minimize.FlatAppearance.BorderSize = 0;
            btn_Minimize.FlatStyle = FlatStyle.Flat;
            btn_Minimize.ForeColor = SystemColors.Control;
            btn_Minimize.Location = new Point(1036, 1);
            btn_Minimize.Name = "btn_Minimize";
            btn_Minimize.Size = new Size(37, 23);
            btn_Minimize.TabIndex = 5;
            btn_Minimize.Text = "🗕";
            btn_Minimize.UseVisualStyleBackColor = false;
            btn_Minimize.Click += btn_Minimize_Click;
            // 
            // btn_Fullscreen
            // 
            btn_Fullscreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Fullscreen.BackColor = Color.Transparent;
            btn_Fullscreen.FlatAppearance.BorderSize = 0;
            btn_Fullscreen.FlatStyle = FlatStyle.Flat;
            btn_Fullscreen.ForeColor = SystemColors.Control;
            btn_Fullscreen.Location = new Point(1072, 2);
            btn_Fullscreen.Name = "btn_Fullscreen";
            btn_Fullscreen.Size = new Size(32, 23);
            btn_Fullscreen.TabIndex = 4;
            btn_Fullscreen.Text = "□  ";
            btn_Fullscreen.UseVisualStyleBackColor = false;
            btn_Fullscreen.Click += btn_Fullscreen_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(1098, 2);
            button3.Name = "button3";
            button3.Size = new Size(43, 23);
            button3.TabIndex = 3;
            button3.Text = "x";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 9, 20);
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(166, 27);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = false;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(14, 480);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1098, 507);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(14, 108);
            label2.Name = "label2";
            label2.Size = new Size(172, 40);
            label2.TabIndex = 4;
            label2.Text = "Your Movies";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(12, 162);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1080, 294);
            flowLayoutPanel2.TabIndex = 4;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(8, 8, 8);
            ClientSize = new Size(1129, 1012);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScanFlix";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnScan;
        private Panel panel1;
        private Label label1;
        private Button button1;
        private Button button3;
        private NoScrollFlowLayoutPanel flowLayoutPanel1;
        private Label label2;
       private NoScrollFlowLayoutPanel flowLayoutPanel2;
        private Button btn_Minimize;
        private Button btn_Fullscreen;
    }
}
