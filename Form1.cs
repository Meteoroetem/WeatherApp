﻿using System.Text.Json;
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
            using HttpClient client = new();
            currentWeatherInfo weatherInfo = await GetCurrentWeatherIconsAsync(client);
            using Stream iconStream =
                await client.GetStreamAsync(weatherInfo.IconsUrls[0]);
            pictureBox1.Image = Image.FromStream(iconStream);
            locationLabel.Text = $"Location: {weatherInfo.Location}";
            temperatureLabel.Text = $"{weatherInfo.Temperature}℃";
        }

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
            using (JsonDocument weatherDocument = JsonDocument.Parse(weatherStream))
            {
                JsonElement current = weatherDocument.RootElement.GetProperty("current");
                JsonElement weatherIcons = current.GetProperty("weather_icons");
                iconURLs = weatherIcons.Deserialize<List<string>>() ?? new();
                temperature = current.GetProperty("temperature").GetInt16();
            }
            return new currentWeatherInfo(iconURLs, weatherQuery, temperature);
        }

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }


    public record currentWeatherInfo(List<string> IconsUrls,
        string Location, int Temperature);
}