namespace NotesWindowsFormsApp.Models
{
    public class WeatherInfo
    {
        public Weather[] Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public int Timezone { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
    public class Main
    {
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public float Temp_min { get; set; }
        public float Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
    }
    public class Clouds
    {
        public int All { get; set; }
    }
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
