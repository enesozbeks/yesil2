using Yesil.Models;

namespace Yesil.Services;

public class SleepService
{
    public TimeSpan CalculateAverageSleep(IEnumerable<UykuKaydi> kayitlar)
    {
        var list = kayitlar.ToList();
        if (list.Count == 0)
        {
            return TimeSpan.Zero;
        }
        return TimeSpan.FromMinutes(list.Average(k => k.Sure.TotalMinutes));
    }

    public string GetSleepAdvice(TimeSpan ortalamaSure)
    {
        if (ortalamaSure.TotalHours < 6)
        {
            return "Uyku süreniz düşük. Yatış rutini oluşturun.";
        }
        if (ortalamaSure.TotalHours > 9)
        {
            return "Uyku süreniz yüksek. Gündüz aktivitenizi artırın.";
        }
        return "Harika! Uyku süreniz dengeli.";
    }
}
