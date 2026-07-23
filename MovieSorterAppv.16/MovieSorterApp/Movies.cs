using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices; // window move 
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using MovieSorterApp;


namespace MovieSorterApp1
{
    public partial class Movies : Form
    {
        private Form1 home;

        public Movies(Form1 mainForm)
        {
            InitializeComponent();

            home = mainForm;



            this.DoubleBuffered = true;
            typeof(Panel)
                .GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance)
                ?.SetValue(flowMovies, true);


        }





        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            int lParam);

        public class MovieData
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
                poster.Image = Image.FromFile(posterfile);
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isFullscreen = false;

        private void btn_Full_Click(object sender, EventArgs e)
        {

        }

        private void btn_Minimized_Click(object sender, EventArgs e)
        {

        }

        private void btn_Full_Click_1(object sender, EventArgs e)
        {
            if (!isFullscreen)
            {
                WindowState = FormWindowState.Maximized;
                isFullscreen = true;

                btn_Fullscreen.Text = "❐"; // Restore icon
            }
            else
            {
                WindowState = FormWindowState.Normal;
                isFullscreen = false;

                btn_Fullscreen.Text = "□"; // Maximize icon
            }
        }

        private void btn_Minimized_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 main = new Form1();

            //main.WindowState = this.WindowState;
            //main.Bounds = this.Bounds;
            //main.StartPosition = FormStartPosition.Manual; // rememeber position 
            this.Close();


        }

        private void Movies_Load(object sender, EventArgs e)
        {

            flowMovies.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            flowMovies.Anchor = AnchorStyles.Top |
                                      AnchorStyles.Bottom |
                                      AnchorStyles.Left |
                                      AnchorStyles.Right;


            string metadataFolder = Path.Combine(
              Application.StartupPath,
              "Cache",
              "Metadata");

            if (!Directory.Exists(metadataFolder))
                return;

            string[] files =
                Directory.GetFiles(metadataFolder, "*.json");

            foreach (string metadataFile in files)
            {
                string json = File.ReadAllText(metadataFile);

                MovieData movie =
                    JsonSerializer.Deserialize<MovieData>(json);

                if (movie == null)
                    continue;

                CreateMovieCard(
                    movie.Title,
                    movie.MoviePath,
                    movie.Poster,
                    flowMovies);


            }
        }

        private void flowMovies_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            string query = tb_Search.Text.Trim().ToLowerInvariant();

            foreach (Control c in flowMovies.Controls)
            {
                if (c is Panel card)
                {
                    // prefer label text (title) if present
                    var titleLabel = card.Controls.OfType<Label>().FirstOrDefault();
                    string title = titleLabel != null
                        ? titleLabel.Text
                        : (card.Tag as string) ?? string.Empty;

                    bool match = string.IsNullOrEmpty(query)
                        ? true
                        : title.ToLowerInvariant().Contains(query);

                    card.Visible = match;
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {

        }
    }
}
