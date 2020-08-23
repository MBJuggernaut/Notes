using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NotesWindowsFormsApp
{
    interface IWeatherInfoRepository
    {
        Task<WeatherInfo> GetData();        
    }
    public class WeatherInfoRepository : IWeatherInfoRepository
    {
        readonly string API = "https://api.openweathermap.org/data/2.5/weather?id=498817&units=metric&appid=4ca2924788b62ba92795cd5c28339ba3&lang=ru";
        public async Task<WeatherInfo> GetData()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync().ConfigureAwait(false);
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var WeatherDataAsString = reader.ReadToEnd();            
            return JsonConvert.DeserializeObject<WeatherInfo>(WeatherDataAsString);
        }             
    }
}
