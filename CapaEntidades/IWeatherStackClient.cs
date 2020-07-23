using System.Threading.Tasks;

namespace CapaEntidades
{
    public interface IWeatherStackClient
    {
        Task<WeatherStackResponse> GetCurrentWeather(string city);
    }
}