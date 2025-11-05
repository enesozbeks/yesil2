using Yesil.Models;

namespace Yesil.Services;

public class HealthDataService
{
    private readonly List<KanDegeri> _kanDegerleri = new();
    private readonly List<HormonDegeri> _hormonDegerleri = new();
    private readonly List<UykuKaydi> _uykuKayitlari = new();

    public IReadOnlyList<KanDegeri> GetBloodMarkers() => _kanDegerleri;
    public IReadOnlyList<HormonDegeri> GetHormoneMarkers() => _hormonDegerleri;
    public IReadOnlyList<UykuKaydi> GetSleepRecords() => _uykuKayitlari;

    public void AddOrUpdateBloodMarker(KanDegeri deger)
    {
        var mevcut = _kanDegerleri.FirstOrDefault(k => k.Ad == deger.Ad);
        if (mevcut is null)
        {
            _kanDegerleri.Add(deger);
        }
        else
        {
            mevcut.Deger = deger.Deger;
            mevcut.ReferansAralik = deger.ReferansAralik;
            mevcut.Yorum = deger.Yorum;
        }
    }

    public void AddHormoneMarker(HormonDegeri deger) => _hormonDegerleri.Add(deger);

    public void AddSleepRecord(UykuKaydi kayit) => _uykuKayitlari.Add(kayit);
}
