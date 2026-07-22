namespace MovieSorterApp1
{
    partial class Popup
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
            btn_Return = new Button();
            lblTitle = new Label();
            lblOverview = new Label();
            lblReleaseDate = new Label();
            lblRating = new Label();
            pictureBoxPoster = new PictureBox();
            btn_Watch = new Button();
            lbl_Genre = new Label();
            panelBackdrop = new Panel();
            lbl_runTime = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).BeginInit();
            SuspendLayout();
            // 
            // btn_Return
            // 
            btn_Return.BackColor = Color.Transparent;
            btn_Return.FlatAppearance.BorderSize = 0;
            btn_Return.FlatStyle = FlatStyle.Flat;
            btn_Return.ForeColor = Color.White;
            btn_Return.Location = new Point(27, 639);
            btn_Return.Name = "btn_Return";
            btn_Return.Size = new Size(47, 29);
            btn_Return.TabIndex = 0;
            btn_Return.Text = "return";
            btn_Return.UseVisualStyleBackColor = false;
            btn_Return.Click += btn_Return_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.Control;
            lblTitle.Location = new Point(380, 430);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(87, 47);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "title";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblOverview
            // 
            lblOverview.AutoSize = true;
            lblOverview.ForeColor = SystemColors.Control;
            lblOverview.Location = new Point(389, 506);
            lblOverview.Name = "lblOverview";
            lblOverview.Size = new Size(31, 15);
            lblOverview.TabIndex = 2;
            lblOverview.Text = "desc";
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.ForeColor = SystemColors.Control;
            lblReleaseDate.Location = new Point(389, 478);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(66, 15);
            lblReleaseDate.TabIndex = 3;
            lblReleaseDate.Text = "releasedate";
            lblReleaseDate.Click += lblReleaseDate_Click;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.ForeColor = SystemColors.Control;
            lblRating.Location = new Point(519, 478);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(38, 15);
            lblRating.TabIndex = 4;
            lblRating.Text = "rating";
            lblRating.Click += lblRating_Click;
            // 
            // pictureBoxPoster
            // 
            pictureBoxPoster.Location = new Point(40, 129);
            pictureBoxPoster.Name = "pictureBoxPoster";
            pictureBoxPoster.Size = new Size(316, 439);
            pictureBoxPoster.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPoster.TabIndex = 5;
            pictureBoxPoster.TabStop = false;
            // 
            // btn_Watch
            // 
            btn_Watch.BackColor = Color.White;
            btn_Watch.FlatAppearance.BorderSize = 0;
            btn_Watch.FlatStyle = FlatStyle.Flat;
            btn_Watch.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Watch.ForeColor = Color.Black;
            btn_Watch.Location = new Point(538, 626);
            btn_Watch.Name = "btn_Watch";
            btn_Watch.Size = new Size(249, 47);
            btn_Watch.TabIndex = 6;
            btn_Watch.Text = " ▶ PLAY";
            btn_Watch.UseVisualStyleBackColor = false;
            btn_Watch.Click += btn_Watch_Click;
            // 
            // lbl_Genre
            // 
            lbl_Genre.AutoSize = true;
            lbl_Genre.ForeColor = SystemColors.Control;
            lbl_Genre.Location = new Point(565, 478);
            lbl_Genre.Name = "lbl_Genre";
            lbl_Genre.RightToLeft = RightToLeft.No;
            lbl_Genre.Size = new Size(37, 15);
            lbl_Genre.TabIndex = 7;
            lbl_Genre.Text = "genre";
            lbl_Genre.Click += lbl_Genre_Click;
            // 
            // panelBackdrop
            // 
            panelBackdrop.Location = new Point(27, 2);
            panelBackdrop.Name = "panelBackdrop";
            panelBackdrop.Size = new Size(1146, 418);
            panelBackdrop.TabIndex = 8;
            // 
            // lbl_runTime
            // 
            lbl_runTime.AutoSize = true;
            lbl_runTime.ForeColor = SystemColors.ButtonFace;
            lbl_runTime.Location = new Point(464, 478);
            lbl_runTime.Name = "lbl_runTime";
            lbl_runTime.Size = new Size(49, 15);
            lbl_runTime.TabIndex = 9;
            lbl_runTime.Text = "runtime";
            // 
            // Popup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(8, 8, 8);
            ClientSize = new Size(1200, 700);
            Controls.Add(lbl_runTime);
            Controls.Add(lblTitle);
            Controls.Add(lblReleaseDate);
            Controls.Add(pictureBoxPoster);
            Controls.Add(lblOverview);
            Controls.Add(lbl_Genre);
            Controls.Add(btn_Watch);
            Controls.Add(lblRating);
            Controls.Add(btn_Return);
            Controls.Add(panelBackdrop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Popup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Popup";
            Load += Popup_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPoster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Return;
        private Label lblTitle;
        private Label lblOverview;
        private Label lblReleaseDate;
        private Label lblRating;
        private PictureBox pictureBoxPoster;
        private Button btn_Watch;
        private Label lbl_Genre;
        private Panel panelBackdrop;
        private Label lbl_runTime;
    }
}