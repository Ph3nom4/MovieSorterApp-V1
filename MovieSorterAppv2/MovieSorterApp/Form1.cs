using System.Diagnostics;
using System.Net.Http; //Api
using System.Reflection;
using System.Text.Json; // Api
using MovieSorterApp1;
using static MovieSorterApp.Form1;
using System.Runtime.InteropServices; // window move 


namespace MovieSorterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {


            InitializeComponent();
            
        }

        private MainPage homePage = new MainPage();
        private MoviesPage moviesPage = new MoviesPage();



        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void OpenPage(UserControl page)
        {
            panelcontent.Controls.Clear();

            page.Dock = DockStyle.Fill;

            panelcontent.Controls.Add(page);
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

            public string MoviePath { get; set; }

            public string Poster { get; set; }

            public string Backdrop { get; set; }

            public string Overview { get; set; }

            public string ReleaseDate { get; set; }

            public double Rating { get; set; }

            public string Genre { get; set; }

            public string Runtime { get; set; }
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            this.Opacity = 0; // smooth

            for (double i = 0; i <= 1; i += 0.05)
            {
                this.Opacity = i;
                await Task.Delay(10);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           OpenPage(homePage);


        }

        public class AppSettings
        {
            public string MovieFolder { get; set; }
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
            "1080p","2160p","720p","4K",
            "BluRay","WEBRip","WEB-DL","WEB",
            "BrRip","x264","x265","HEVC",
            "AAC","YTS","YTS.MX","MX",
            "REPACK","10bit","5.1","7.1",
            "AG","YIFY","5 1"
             };

            foreach (string word in removeWords)
            {
                title = title.Replace(word, "", StringComparison.OrdinalIgnoreCase);
            }

            for (int year = 1900; year <= 2100; year++)
            {
                title = title.Replace(year.ToString(), "");
            }

            return title.Trim();
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

                AppSettings settings = new AppSettings
                {
                    MovieFolder = selectedFolder
                };

                string settingsJson = JsonSerializer.Serialize(                         ///cache load 
                 settings,
                 new JsonSerializerOptions
                 {
                     WriteIndented = true
                 });

                await File.WriteAllTextAsync(
                    Path.Combine(cacheFolder, "Settings.json"),
                    settingsJson);                                                      ///cache load



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



                        string posterUrl = "";
                        string posterFile = Path.Combine(posterFolder, title + ".jpg");
                        string backdropURL = "";
                        string backdropFile = Path.Combine(backdropFolder, title + ".jpg");
                        string metadataFile = Path.Combine(metadataFolder, title + ".json");





                        if (File.Exists(metadataFile) &&
                             File.Exists(posterFile) &&
                             File.Exists(backdropFile))
                        {
                            continue;
                        }





                        string json = await SearchMovie(title);

                     

                        using JsonDocument doc = JsonDocument.Parse(json);

                        JsonElement results = doc.RootElement.GetProperty("results");




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
                                MoviePath = file,
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



                            await File.WriteAllTextAsync(metadataFile, metadataJson);


                            await File.WriteAllTextAsync(
                                Path.Combine(metadataFolder, title + ".json"),
                                metadataJson);



                        }

                        else
                        {
                            MessageBox.Show($"Movie not found: {title}");
                        }


                        if (!scannedMovies.Contains(file)) // scan for duplicate 
                        {
                            scannedMovies.Add(file);

                            await homePage.LoadMovies();
                            await moviesPage.LoadMovies();

                            //CreateMovieCard(title, file, posterFile, flowLayoutPanel1);
                            //CreateMovieCard(title, file, posterFile, flowLayoutPanel2); // CreateMovieCard is in MainPage This form only scans and download the rest are loaded by other usercontrol page
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



        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                btn_Fullscreen.Text = "□";
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                btn_Fullscreen.Text = "❐";
            }
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private async void btn_All_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Movies moreMovies = new Movies();
            //moreMovies.ShowDialog();

           
            OpenPage(moviesPage);

          



        }

        private void panelcontent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenPage(homePage);

        }
    }
}
