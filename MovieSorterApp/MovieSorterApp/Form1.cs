using System.Net.Http; //Api
using System.Text.Json; // Api
using System.Diagnostics;
using System.Reflection;


namespace MovieSorterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private const string ApiKey = "239e1c8a63f4d3c8e1b7b2bcf3fe77bc";





        private HashSet<string> scannedMovies = new HashSet<string>();

        private async Task<string> SearchMovie(string movieTitle)
        {
            using HttpClient client = new HttpClient();

            string url =
                $"https://api.themoviedb.org/3/search/movie?api_key={ApiKey}&query={Uri.EscapeDataString(movieTitle)}";

            string json = await client.GetStringAsync(url);

            return json;
        }

        public class MovieData // metadata
        {
            public string Title { get; set; }

            public string Poster { get; set; }

            public string Overview { get; set; }

            public string ReleaseDate { get; set; }

            public double Rating { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            flowLayoutPanel1.Anchor = AnchorStyles.Top |
                                      AnchorStyles.Bottom |
                                      AnchorStyles.Left |
                                      AnchorStyles.Right;


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
                poster.LoadAsync(posterfile);
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

            card.Tag = filePath;
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

            string filePath = clickedControl.Tag.ToString();
            MessageBox.Show(filePath);

            Process.Start(@"C:\Program Files\VideoLAN\VLC\vlc.exe",
              "\"" + filePath + "\"");
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Controls.Clear(); // Clear before scan so no repeat other option? mas madali hahahah 
            //flowLayoutPanel2.Controls.Clear();

            string cacheFolder = Path.Combine(Application.StartupPath, "Cache");
            string posterFolder = Path.Combine(cacheFolder, "Posters");
            string metadataFolder = Path.Combine(cacheFolder, "Metadata");

            Directory.CreateDirectory(cacheFolder);
            Directory.CreateDirectory(posterFolder);
            Directory.CreateDirectory(metadataFolder);

            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = dialog.SelectedPath;

                MessageBox.Show(selectedFolder + " Loading Movies");



                string[] files = Directory.GetFiles(
                    selectedFolder,
                    "*.*",
                    SearchOption.AllDirectories);



                foreach (string file in files)
                {
                    string extension = Path.GetExtension(file).ToLower();


                    if (extension == ".mp4" ||
                        extension == ".mkv" ||
                        extension == ".mov")
                    {
                        string title = Path.GetFileNameWithoutExtension(file);
                        title = CleanTitle(title);






                        string json = await SearchMovie(title);

                        using JsonDocument doc = JsonDocument.Parse(json);

                        JsonElement results = doc.RootElement.GetProperty("results");



                        string posterUrl = "";
                        string posterFile = Path.Combine(posterFolder, title + ".jpg");

                        if (results.GetArrayLength() > 0)
                        {
                            JsonElement movie = results[0];

                            string posterPath = movie.GetProperty("poster_path").GetString();

                            posterUrl = "https://image.tmdb.org/t/p/w500" + posterPath;

                            if (!File.Exists(posterFile))
                            {
                                using HttpClient client = new HttpClient();

                                byte[] imageBytes = await client.GetByteArrayAsync(posterUrl);

                                await File.WriteAllBytesAsync(posterFile, imageBytes);
                            }


                            string overview = movie.GetProperty("overview").GetString();
                            string releaseDate = movie.GetProperty("release_date").GetString();
                            double rating = movie.GetProperty("vote_average").GetDouble();

                            MovieData movieData = new MovieData
                            {
                                Title = title,
                                Poster = posterFile,
                                Overview = overview,
                                ReleaseDate = releaseDate,
                                Rating = rating
                            };



                            string metadataJson = JsonSerializer.Serialize(movieData, new JsonSerializerOptions
                            {
                                WriteIndented = true
                            });

                            string metadataFile = Path.Combine(metadataFolder, title + ".json");

                            await File.WriteAllTextAsync(metadataFile, metadataJson);


                            await File.WriteAllTextAsync(
                                Path.Combine(metadataFolder, title + ".json"),
                                metadataJson);



                        }

                        else
                        {
                            MessageBox.Show("Movie not found.");
                        }


                        if (!scannedMovies.Contains(file)) // scan for duplicate 
                        {
                            scannedMovies.Add(file);

                            CreateMovieCard(title, file, posterFile, flowLayoutPanel1);
                            CreateMovieCard(title, file, posterFile, flowLayoutPanel2);
                        }



                    }



                }
            }
        }





        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Moveleft_Click(object sender, EventArgs e)
        {
            int newValue = flowLayoutPanel1.HorizontalScroll.Value - 180;

            if (newValue < 0)
                newValue = 0;

            flowLayoutPanel1.HorizontalScroll.Value = newValue;
        }

        private void btn_Moveright_Click(object sender, EventArgs e)
        {
            int newValue = flowLayoutPanel1.HorizontalScroll.Value + 180;

            int max =
                flowLayoutPanel1.HorizontalScroll.Maximum;

            if (newValue > max)
                newValue = max;

            flowLayoutPanel1.HorizontalScroll.Value = newValue;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool isFullscreen = false;

        private void btn_Fullscreen_Click(object sender, EventArgs e)
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

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }





        //private void btnScan_Click(object sender, EventArgs e)
        //{

        //}
    }
}
