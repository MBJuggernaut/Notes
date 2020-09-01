using System.Threading.Tasks;

namespace NotesWindowsFormsApp
{
    interface IWeatherInfoProvider
    {
        Task<WeatherInfo> GetData();
    }
}
