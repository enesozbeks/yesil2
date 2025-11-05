using Yesil.Models;

namespace Yesil.Services;

public class WeatherService
{
    public Task<HavaDurumu> GetWeatherAsync(string city)
    {
        // Mocked for demo
        var data = new HavaDurumu
        {
            Konum = city,
            Durum = "Güneşli",
            SıcaklıkC = 22,
            Nem = 45,
            Ruzgar = 12,
            Tarih = DateTime.Now
        };
        return Task.FromResult(data);
    }
}
