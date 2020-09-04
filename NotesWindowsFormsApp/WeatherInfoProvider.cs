using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotesWindowsFormsApp
{
    public class WeatherInfoProvider : IWeatherInfoProvider
    {
        readonly string API = "https://api.openweathermap.org/data/2.5/weather?id=498817&units=metric&appid=4ca2924788b62ba92795cd5c28339ba3&lang=ru";
        readonly HttpClient httpClient = new HttpClient();
        public async Task<WeatherInfo> GetData()
        {
            try
            {
                var httpResponse = await httpClient.GetAsync(API).ConfigureAwait(false);
                httpResponse.EnsureSuccessStatusCode();
                var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherInfo>(httpResponseBody);
            }
            catch
            {
                return null;
            }
        }
    }
}
