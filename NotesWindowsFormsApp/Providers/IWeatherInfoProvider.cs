using NotesWindowsFormsApp.Models;
using System.Threading.Tasks;

namespace NotesWindowsFormsApp.Providers
{
    interface IWeatherInfoProvider
    {
        Task<WeatherInfo> GetData();
    }
}
