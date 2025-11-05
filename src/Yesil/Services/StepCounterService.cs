using Yesil.Models;

namespace Yesil.Services;

public class StepCounterService
{
    private readonly List<AktiviteKaydi> _adimKayitlari = new();

    public void AddStepRecord(AktiviteKaydi kayit) => _adimKayitlari.Add(kayit);

    public int GetTotalSteps(DateTime date)
        => _adimKayitlari.Where(k => k.Tarih.Date == date.Date).Sum(k => k.AdimSayisi);

    public double GetWeeklyCaloriesBurned(DateTime weekStart)
    {
        var end = weekStart.AddDays(7);
        return _adimKayitlari.Where(k => k.Tarih >= weekStart && k.Tarih < end).Sum(k => k.YakilanKalori);
    }
}
