using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieSorterApp1
{
    public partial class MainPage : UserControl
    {

        private List<MovieData> movies = new(); // hero banner 
        private Random rnd = new Random();

        private int heroIndex = 0;

        public MainPage()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }


        private MovieData currentHeroMovie;


        public class MovieData // metadata
        {
            public string Title { get; set; }

            public string MoviePath { get; set; }

            public string Poster { get; set; }

            public string Backdrop { get; set; }

            public string Overview { get; set; }

            public string ReleaseDate { get; set; }

            public double Rating { get; set; }

            public string Genre { get; set; }

            public string Runtime { get; set; }
        }


        public async Task LoadMovies()
        {

            movies.Clear();

            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel4.Controls.Clear();


            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();

            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            int recentCount = 0;

            string metadataFolder = Path.Combine(
                Application.StartupPath,
                "Cache",
                "Metadata");

            if (!Directory.Exists(metadataFolder))
                return;

            string[] files = Directory.GetFiles(metadataFolder, "*.json")
                .OrderByDescending(File.GetCreationTime).ToArray();


            foreach (string metadataFile in files)
            {
                string json = await File.ReadAllTextAsync(metadataFile);

                MovieData movie =
                    JsonSerializer.Deserialize<MovieData>(json);

                movies.Add(movie);



                if (movie == null)
                    continue;


                if (recentCount < 10) // recent added 
                {
                    CreateMovieCard(
                        movie.Title,
                        movie.MoviePath,
                        movie.Poster,
                        flowLayoutPanel4);

                    recentCount++;
                }


            }

            var recentMovies =
          movies.OrderByDescending(m => File.GetLastAccessTime(m.MoviePath)).Take(10);

            var topRated = movies.OrderByDescending(m => m.Rating).Take(10);


            foreach (var movie in recentMovies)
            {
                CreateMovieCard(
                    movie.Title,
                    movie.MoviePath,
                    movie.Poster,
                    flowLayoutPanel3);
            }

            foreach (var movie in topRated)
            {
                CreateMovieCard(
                    movie.Title,
                    movie.MoviePath,
                    movie.Poster,
                    flowLayoutPanel2);
            }

            

         

          




           




           

            flowLayoutPanel3.ResumeLayout(true);
            flowLayoutPanel2.ResumeLayout(true);

            if (movies.Count > 0)
            {
                heroIndex = rnd.Next(movies.Count);
                ShowHero(movies[heroIndex]);

                heroTimer.Start();
            }

            UpdateMovieCount();
        }


        private void UpdateMovieCount()
        {
            lblMovieCount.Text = $"🎬 {movies.Count} Movies";
        }

        private void Card_MouseEnter(object sender, EventArgs e) // mouse anim
        {
            Control control = (Control)sender;

            Panel card = control as Panel;

            if (card == null)
                card = control.Parent as Panel;

            if (card == null)
                return;

            card.Top -= 8;
            card.BorderStyle = BorderStyle.Fixed3D;
        
        }

        private void Card_MouseLeave(object sender, EventArgs e) // mouse anim 
        {
            Control control = (Control)sender;

            Panel card = control as Panel;

            if (card == null)
                card = control.Parent as Panel;

            if (card == null)
                return;

            card.Top += 8;
            card.BorderStyle = BorderStyle.FixedSingle;
            
        }


        private async void MainPage_Load(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.None;

            flowLayoutPanel3.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel3.WrapContents = false;
            flowLayoutPanel3.AutoScroll = true;


            flowLayoutPanel2.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.AutoScroll = true;


            flowLayoutPanel4.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel4.WrapContents = false;
            flowLayoutPanel4.AutoScroll = true;


            await LoadMovies();



        }

        private Image CreateHeroImage(string imagePath)
        {
            if (!File.Exists(imagePath))
                return null;

            Image source = Image.FromFile(imagePath);

            Bitmap result = new Bitmap(
            Math.Max(1, pbhero.ClientSize.Width),
            Math.Max(1, pbhero.ClientSize.Height));

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                float scale = Math.Max(
                    (float)pbhero.Width / source.Width,
                    (float)pbhero.Height / source.Height);

                int drawWidth = (int)(source.Width * scale);
                int drawHeight = (int)(source.Height * scale);

                int x = (pbhero.Width - drawWidth) / 2;
                int y = (pbhero.Height - drawHeight) / 2;

                g.DrawImage(source, x, y, drawWidth, drawHeight);

                // Dark overlay


                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, result.Width, result.Height),
                    Color.FromArgb(220, Color.Black),
                    Color.FromArgb(20, Color.Black),
                    LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(brush, 0, 0, result.Width, result.Height);
                }
            }

            source.Dispose();

            return result;
        }
        private void ShowHero(MovieData movie)
        {
            currentHeroMovie = movie;

            pbhero.Image?.Dispose();
            pbhero.Image = CreateHeroImage(movie.Backdrop);

            lblHeroTitle.Text = movie.Title;

            lblHeroGenre.Text =
                $"⭐ {movie.Rating:0.0} • {movie.Genre} • {movie.Runtime}";

            lblHeroOverview.AutoSize = false;
            lblHeroOverview.Width = 650;      // Adjust to fit before the Play button
            lblHeroOverview.Height = 80;      // About 4-5 lines
            lblHeroOverview.MaximumSize = new Size(650, 80);
            lblHeroOverview.TextAlign = ContentAlignment.TopLeft;

            lblHeroOverview.Text = movie.Overview;


        }



        public class AppSettings
        {
            public string MovieFolder { get; set; }
        }

        private void CreateMovieCard(string title, string filePath, string posterfile, FlowLayoutPanel panel)
        {
            Panel card = new Panel();

            card.Width = 160;
            card.Height = 250;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(10);


            PictureBox poster = new PictureBox();

            poster.Width = 140;
            poster.Height = 180;

            poster.Left = 10;
            poster.Top = 10;

            poster.BorderStyle = BorderStyle.FixedSingle;

            poster.SizeMode = PictureBoxSizeMode.Zoom;

            if (!string.IsNullOrEmpty(posterfile))
            {
                poster.ImageLocation = posterfile;
            }


            Label lbltitle = new Label();


            lbltitle.Text = title;
            lbltitle.ForeColor = Color.White;


            lbltitle.Top = 195;
            lbltitle.Left = 10;

            lbltitle.Height = 40;
            lbltitle.Width = 140;


            card.Controls.Add(poster);
            card.Controls.Add(lbltitle);
            panel.Controls.Add(card);



            card.Tag = filePath;    ///tagg
            poster.Tag = filePath;
            lbltitle.Tag = filePath;


            card.Click += Card_Click;
            poster.Click += Card_Click;
            lbltitle.Click += Card_Click;


            card.MouseEnter += Card_MouseEnter; // anim
            card.MouseLeave += Card_MouseLeave;

            poster.MouseEnter += Card_MouseEnter;
            poster.MouseLeave += Card_MouseLeave;

            lbltitle.MouseEnter += Card_MouseEnter;
            lbltitle.MouseLeave += Card_MouseLeave;

            card.Margin = new Padding(10);

        }



        private string CleanTitle(string title)
        {
            title = title.Replace(".", " ");
            title = title.Replace("_", " ");
            title = title.Replace("-", " ");
            title = title.Replace("[", " ");
            title = title.Replace("]", " ");
            title = title.Replace("(", " ");
            title = title.Replace(")", " ");



            string[] removeWords =
            {
                "1080p",
                "2160p",
                "720p",
                "4K",
                "BluRay",
                "WEBRip",
                "WEB-DL",
                "WEB",
                "BrRip",
                "x264",
                "x265",
                "HEVC",
                "AAC",
                "YTS",
                "YTS.MX",
                "MX",
                "REPACK",
                "10bit",
                "5.1",
                "7.1",
                "AG",
                "YIFY",
                "5 1"

            };

            foreach (string word in removeWords)
            {
                title = title.Replace(word, "");
            }

            for (int year = 1900; year <= 2100; year++)
            {
                title = title.Replace(year.ToString(), "");
            }

            title = title.Trim();

            return title;

            
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Control clickedControl = (Control)sender;

            if (clickedControl.Tag is not string filePath)
            {
                MessageBox.Show("Movie information is missing.");
                return;
            }

            string cacheFolder = Path.Combine(Application.StartupPath, "Cache");
            string metadataFolder = Path.Combine(cacheFolder, "Metadata");

            string title = Path.GetFileNameWithoutExtension(filePath);
            title = CleanTitle(title);

            string metadataFile = Path.Combine(metadataFolder, title + ".json");

            //MessageBox.Show(filePath);
            //MessageBox.Show(metadataFile); // test


            Popup details = new Popup(filePath, metadataFile);
            details.ShowDialog();


        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (movies.Count == 0)
                return;

            int newIndex;

            do
            {
                newIndex = rnd.Next(movies.Count);
            }
            while (movies.Count > 1 && newIndex == heroIndex);

            heroIndex = newIndex;
            ShowHero(movies[heroIndex]);
        }

        private void panelOverlay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHeroOverview_Click(object sender, EventArgs e)
        {

        }

        private void flowlayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (currentHeroMovie == null)
                return;

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\VideoLAN\VLC\vlc.exe",
                Arguments = $"--fullscreen --no-video-title-show --play-and-exit \"{currentHeroMovie.MoviePath}\"",
                UseShellExecute = true
            };

            Process.Start(psi);


        }

      

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (currentHeroMovie == null)
                return;

            string metadataFile =
                Path.Combine(
                    Application.StartupPath,
                    "Cache",
                    "Metadata",
                    currentHeroMovie.Title + ".json");

            Popup popup =
                new Popup(
                    currentHeroMovie.MoviePath,
                    metadataFile);

            popup.ShowDialog();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

//ph3nom
