using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static MovieSorterApp.Form1;
using System.Drawing.Drawing2D;

namespace MovieSorterApp1
{
    public partial class Popup : Form
    {
        private string moviePath;
        private string metadataPath;

        public Popup(string filePath, string metadataFile)
        {
            InitializeComponent();

            moviePath = filePath;
            metadataPath = metadataFile;
        }

        public class GradientPanel : Panel
        {
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(
                        this.ClientRectangle,
                        Color.FromArgb(0, 0, 0, 0),
                        Color.FromArgb(220, 0, 0, 0),
                        LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }
        }


        private void btn_Return_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void Popup_Load(object sender, EventArgs e)
        {
            string json = File.ReadAllText(metadataPath);

            MovieData movie = JsonSerializer.Deserialize<MovieData>(json);



            pictureBoxPoster.BorderStyle = BorderStyle.FixedSingle;

            pictureBoxPoster.SizeMode = PictureBoxSizeMode.Zoom;

            lblOverview.MaximumSize = new Size(550, 0);
            lblOverview.AutoSize = true;


            lblTitle.Text = movie.Title;

            lblOverview.Text = movie.Overview;

            lblReleaseDate.Text = movie.ReleaseDate + "  • ";

            lblRating.Text = "⭐ " + movie.Rating.ToString("0.0") + "  • ";

            lbl_Genre.Text = movie.Genre;

            lbl_runTime.Text = movie.Runtime + "  • ";

           

            pictureBoxPoster.Image = Image.FromFile(movie.Poster);

            panelBackdrop.BackgroundImageLayout = ImageLayout.Zoom;

            pictureBoxPoster.BorderStyle = BorderStyle.FixedSingle;

            if (File.Exists(movie.Backdrop))
            {
                panelBackdrop.BackgroundImage = Image.FromFile(movie.Backdrop);
                panelBackdrop.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void btn_Watch_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\VideoLAN\VLC\vlc.exe",
             "\"" + moviePath + "\"");
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblRating_Click(object sender, EventArgs e)
        {

        }

        private void lblReleaseDate_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Genre_Click(object sender, EventArgs e)
        {

        }
    }
}
