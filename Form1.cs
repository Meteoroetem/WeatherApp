using System.Text.Json;
using System.Net.Http;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        const string WEATHER_API_KEY = "33a34c5f6d601252f155956e00d02b93";
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //setting controls' visbilty to false and showing the loading gif until get request is answered
            LoadingScreen();

            //getting the current weather information
            using HttpClient client = new();
            currentWeatherInfo weatherInfo = await GetCurrentWeatherIconsAsync(client);
            using Stream iconStream =
                await client.GetStreamAsync(weatherInfo.IconsUrls[0]);
            NetworkLoadingCircle.Enabled = false;
            NetworkLoadingCircle.Visible = false;

            pictureBox1.Image = Image.FromStream(iconStream);
            Bitmap iconBmp = new(pictureBox1.Image);
            BackColor = Color.FromArgb(iconBmp.GetPixel(0, 0).ToArgb());
            locationLabel.Text = $"Location: {weatherInfo.Location}";
            locationLabel.Location = new Point(Width / 2 - locationLabel.Width / 2, locationLabel.Location.Y);
            temperatureLabel.Text = $"{weatherInfo.Temperature}℃";
            humidityPrecentLabel.Text = $"{weatherInfo.Humidity}%";
            foreach (var description in weatherInfo.WeatherDescriptions)
            {
                descriptionLabel.Text += $"\n{description}";
            }
            descriptionLabel.Location = new Point(pictureBox1.Location.X + pictureBox1.Width/2
                - descriptionLabel.Width / 2, pictureBox1.Location.Y + pictureBox1.Height);


            ShowCurrentWeather(true);
        }

        /// <summary>
        /// After getting the IP address, it gets the city name associated with it. Sends an API request with
        /// the query being the city name.
        /// </summary>
        /// <param name="client">A HTTP client to use for the requests</param>
        /// <returns>An instance of currentWeatherInfo where it's properties are based on the API's response.</returns>
        static async Task<currentWeatherInfo> GetCurrentWeatherIconsAsync(HttpClient client)
        {
            string ipAddress = await GetPublicIPAddressAsync();
            await using Stream locationStream =
                await client.GetStreamAsync($"http://ip-api.com/json/{ipAddress}");

            string weatherQuery;
            using (JsonDocument locationDocument = JsonDocument.Parse(locationStream))
            {
                JsonElement city = locationDocument.RootElement.GetProperty("city");
                weatherQuery = city.GetString() ?? "Tel Aviv";
            }

            await using Stream weatherStream =
                await client.GetStreamAsync(
                $"http://api.weatherstack.com/current?access_key={WEATHER_API_KEY}&query={weatherQuery}");
            //Console.WriteLine(weatherStream.ToString());
            List<string> iconURLs;
            int temperature;
            int humidity;
            List<string> weatherDescriptions;
            using (JsonDocument weatherDocument = JsonDocument.Parse(weatherStream))
            {
                JsonElement current = weatherDocument.RootElement.GetProperty("current");
                JsonElement weatherIcons = current.GetProperty("weather_icons");
                iconURLs = weatherIcons.Deserialize<List<string>>() ?? new();
                temperature = current.GetProperty("temperature").GetInt16();
                humidity = current.GetProperty("humidity").GetInt16();
                weatherDescriptions = current.GetProperty("weather_descriptions").Deserialize<List<string>>();
            }
            return new currentWeatherInfo(iconURLs, weatherQuery, temperature, humidity, weatherDescriptions);
        }

        /// <summary>
        /// Get's the public IP address using an HTTP request.
        /// </summary>
        /// <returns>The public IP address of the device</returns>
        public static async Task<string> GetPublicIPAddressAsync()
        {
            string url = "http://checkip.dyndns.org";
            using HttpClient client = new();
            string response = await client.GetStringAsync(url);
            //The response is html, here we change the string to only include IP
            int colonIndex = response.IndexOf(':');
            response = response.Substring(colonIndex + 2);
            string[] responseArr = response.Split('<');
            response = responseArr[0];
            return response;
        }

        /// <summary>
        /// Initiates the loading screen. Hides controls and shows a loading gif
        /// </summary>
        void LoadingScreen()
        {
            ShowCurrentWeather(false);
            NetworkLoadingCircle.Enabled = true;
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            NetworkLoadingCircle.Image = Image.FromFile($"{projectDirectory}/output-onlinegiftools.gif");
            NetworkLoadingCircle.Visible = true;
        }

        /// <summary>
        /// Set's the current weather info controls Visibility to <paramref name="value"/>
        /// </summary>
        /// <param name="value">True to show and false to hide</param>
        void ShowCurrentWeather(bool value)
        {
            locationLabel.Visible = value;
            temperatureLabel.Visible = value;
            pictureBox1.Visible = value;
            humidityPrecentLabel.Visible = value;
            humidityLabel.Visible = value;
            descriptionLabel.Visible = value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }
    }


    public record currentWeatherInfo(List<string> IconsUrls,
        string Location, int Temperature, int Humidity, List<string> WeatherDescriptions);
}