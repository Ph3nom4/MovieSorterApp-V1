using System.Diagnostics;
using System.Net.Http; //Api
using System.Reflection;
using System.Text.Json; // Api
using MovieSorterApp1;
using static MovieSorterApp.Form1;


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


        private async Task<string> GetMovieDetails(int movieId) /// 2nd api request 
        {
            using HttpClient client = new HttpClient();

            string url =
                 $"https://api.themoviedb.org/3/movie/{movieId}?api_key={ApiKey}";

            return await client.GetStringAsync(url);
        }

        public class MovieData // metadata
        {
            public string Title { get; set; }

            public string Poster { get; set; }

            public string Backdrop { get; set; }

            public string Overview { get; set; }

            public string ReleaseDate { get; set; }

            public double Rating { get; set; }

            public string Genre { get; set; }

            public string Runtime { get; set; }
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

            string filePath = clickedControl.Tag.ToString();

            string cacheFolder = Path.Combine(Application.StartupPath, "Cache");
            string metadataFolder = Path.Combine(cacheFolder, "Metadata");

            string title = Path.GetFileNameWithoutExtension(filePath);
            title = CleanTitle(title);

            string metadataFile = Path.Combine(metadataFolder, title + ".json");

            //MessageBox.Show(filePath);
            //MessageBox.Show(metadataFile);


            Popup details = new Popup(filePath, metadataFile);
            details.ShowDialog();


        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Controls.Clear(); // Clear before scan so no repeat other option? mas madali hahahah 
            //flowLayoutPanel2.Controls.Clear();
            //flowLayoutPanel2.Controls.Clear();

            string cacheFolder = Path.Combine(Application.StartupPath, "Cache");
            string posterFolder = Path.Combine(cacheFolder, "Posters");
            string metadataFolder = Path.Combine(cacheFolder, "Metadata");
            string backdropFolder = Path.Combine(cacheFolder, "Backdrop");


            Directory.CreateDirectory(cacheFolder);
            Directory.CreateDirectory(posterFolder);
            Directory.CreateDirectory(metadataFolder);
            Directory.CreateDirectory(backdropFolder);

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
                        string backdropURL = "";
                        string backdropFile = Path.Combine(backdropFolder, title + ".jpg");




                        if (results.GetArrayLength() > 0)
                        {
                            JsonElement movie = results[0];



                            int movieId = movie.GetProperty("id").GetInt32(); // Runtime finder

                            string detailsJson = await GetMovieDetails(movieId);

                            using JsonDocument detailsDoc = JsonDocument.Parse(detailsJson);

                            JsonElement details = detailsDoc.RootElement;


                            JsonElement genres = details.GetProperty("genres"); // genre finder

                            List<string> genreList = new();

                            foreach (JsonElement g in genres.EnumerateArray())
                            {
                                genreList.Add(g.GetProperty("name").GetString());
                            }

                            string genreText = string.Join(" • ", genreList); // convert to text





                            string posterPath = movie.GetProperty("poster_path").GetString();
                            string backropPath = movie.GetProperty("backdrop_path").GetString();

                            posterUrl = "https://image.tmdb.org/t/p/w500" + posterPath;
                            backdropURL = "https://image.tmdb.org/t/p/w1280" + backropPath;  // links

                            if (!File.Exists(posterFile))  // catch if nothing is find avoids errors
                            {
                                using HttpClient client = new HttpClient();

                                byte[] imageBytes = await client.GetByteArrayAsync(posterUrl);

                                await File.WriteAllBytesAsync(posterFile, imageBytes);
                            }

                            if (!File.Exists(backdropFile))
                            {
                                using HttpClient client = new HttpClient();

                                byte[] imageBytes = await client.GetByteArrayAsync(backdropURL);

                                await File.WriteAllBytesAsync(backdropFile, imageBytes);
                            }


                            string overview = movie.GetProperty("overview").GetString();
                            string releaseDate = movie.GetProperty("release_date").GetString();
                            double rating = movie.GetProperty("vote_average").GetDouble();

                            int runtime = details.GetProperty("runtime").GetInt32();

                            string runtimeText = $"{runtime / 60}h {runtime % 60}m"; // convert to text or string 


                            MovieData movieData = new MovieData
                            {
                                Title = title,
                                Poster = posterFile,
                                Backdrop = backdropFile,
                                Overview = overview,
                                ReleaseDate = releaseDate,
                                Rating = rating,
                                Genre = genreText,
                                Runtime = runtimeText
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
