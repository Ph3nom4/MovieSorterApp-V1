namespace MovieSorterApp1
{
    partial class MainPage
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
            components = new System.ComponentModel.Container();
            flowLayoutPanel2 = new NoScrollFlowLayoutPanel();
            label2 = new Label();
            lblHeroTitle = new Label();
            lblHeroGenre = new Label();
            lblHeroOverview = new Label();
            btnPlay = new Button();
            btnDetails = new Button();
            label1 = new Label();
            panel1 = new Panel();
            pbhero = new PictureBox();
            heroTimer = new System.Windows.Forms.Timer(components);
            flowLayoutPanel3 = new NoScrollFlowLayoutPanel();
            panelMain = new NoScrollPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbhero).BeginInit();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Location = new Point(3, 54);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(933, 290);
            flowLayoutPanel2.TabIndex = 11;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(6, 11);
            label2.Name = "label2";
            label2.Size = new Size(243, 40);
            label2.TabIndex = 6;
            label2.Text = "Recently Watched";
            // 
            // lblHeroTitle
            // 
            lblHeroTitle.AutoSize = true;
            lblHeroTitle.BackColor = Color.Transparent;
            lblHeroTitle.FlatStyle = FlatStyle.Flat;
            lblHeroTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeroTitle.ForeColor = SystemColors.Control;
            lblHeroTitle.Location = new Point(88, 270);
            lblHeroTitle.Name = "lblHeroTitle";
            lblHeroTitle.Size = new Size(298, 65);
            lblHeroTitle.TabIndex = 0;
            lblHeroTitle.Text = "lblHeroTitle";
            // 
            // lblHeroGenre
            // 
            lblHeroGenre.AutoSize = true;
            lblHeroGenre.BackColor = Color.Transparent;
            lblHeroGenre.FlatStyle = FlatStyle.Flat;
            lblHeroGenre.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeroGenre.ForeColor = SystemColors.Control;
            lblHeroGenre.Location = new Point(88, 347);
            lblHeroGenre.Name = "lblHeroGenre";
            lblHeroGenre.Size = new Size(135, 30);
            lblHeroGenre.TabIndex = 0;
            lblHeroGenre.Text = "lblHeroGenre";
            // 
            // lblHeroOverview
            // 
            lblHeroOverview.AutoSize = true;
            lblHeroOverview.BackColor = Color.Transparent;
            lblHeroOverview.FlatStyle = FlatStyle.Flat;
            lblHeroOverview.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeroOverview.ForeColor = SystemColors.Control;
            lblHeroOverview.Location = new Point(88, 401);
            lblHeroOverview.Name = "lblHeroOverview";
            lblHeroOverview.Size = new Size(152, 25);
            lblHeroOverview.TabIndex = 3;
            lblHeroOverview.Text = "lblHeroOverview";
            lblHeroOverview.Click += lblHeroOverview_Click;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlay.BackColor = Color.Transparent;
            btnPlay.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlay.Location = new Point(620, 462);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(139, 44);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "▶ PLAY";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnDetails
            // 
            btnDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDetails.Location = new Point(780, 471);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(114, 35);
            btnDetails.TabIndex = 2;
            btnDetails.Text = "DETAILS";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(14, 359);
            label1.Name = "label1";
            label1.Size = new Size(145, 40);
            label1.TabIndex = 8;
            label1.Text = "Top Rated";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDetails);
            panel1.Controls.Add(btnPlay);
            panel1.Controls.Add(lblHeroTitle);
            panel1.Controls.Add(lblHeroGenre);
            panel1.Controls.Add(lblHeroOverview);
            panel1.Controls.Add(pbhero);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(936, 575);
            panel1.TabIndex = 9;
            // 
            // pbhero
            // 
            pbhero.Dock = DockStyle.Fill;
            pbhero.Location = new Point(0, 0);
            pbhero.Name = "pbhero";
            pbhero.Size = new Size(936, 575);
            pbhero.SizeMode = PictureBoxSizeMode.CenterImage;
            pbhero.TabIndex = 0;
            pbhero.TabStop = false;
            // 
            // heroTimer
            // 
            heroTimer.Enabled = true;
            heroTimer.Interval = 8000;
            heroTimer.Tick += timer1_Tick;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel3.AutoScroll = true;
            flowLayoutPanel3.Location = new Point(3, 410);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(933, 292);
            flowLayoutPanel3.TabIndex = 11;
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.Controls.Add(label2);
            panelMain.Controls.Add(flowLayoutPanel3);
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(flowLayoutPanel2);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 575);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(936, 760);
            panelMain.TabIndex = 11;
            panelMain.Paint += panelMain_Paint;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(8, 8, 8);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            Name = "MainPage";
            Size = new Size(936, 1335);
            Load += MainPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbhero).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NoScrollFlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private PictureBox pbhero;
        private Button btnDetails;
        private Button btnPlay;
        private Label lblHeroOverview;
        private Label lblHeroGenre;
        private Label lblHeroTitle;
        private System.Windows.Forms.Timer heroTimer;
        private NoScrollFlowLayoutPanel flowlayoutPanel1;
        private NoScrollFlowLayoutPanel flowLayoutPanel3;
        private NoScrollPanel panelMain;

        
    }
}
