using Yesil.Models;

namespace Yesil.Services;

public class ExerciseService
{
    private readonly List<EgzersizPlanı> _planlar;

    public ExerciseService()
    {
        _planlar = SeedPlans();
    }

    public IReadOnlyList<EgzersizPlanı> GetPlans() => _planlar;

    public EgzersizPlanı? GetPlanByLevel(string level)
        => _planlar.FirstOrDefault(p => p.Seviye.Equals(level, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<AktiviteKaydi> GenerateStepRecommendations(int dailySteps)
    {
        yield return new AktiviteKaydi
        {
            AktiviteAd = "Tempolu Yürüyüş",
            AdimSayisi = dailySteps,
            YakilanKalori = dailySteps * 0.04,
            Sure = TimeSpan.FromMinutes(dailySteps / 110.0 * 10),
            Not = "Günlük hedefi tamamlamak için hafif koşu ekleyin"
        };
    }

    private static List<EgzersizPlanı> SeedPlans()
    {
        return new List<EgzersizPlanı>
        {
            new()
            {
                Baslik = "Fonksiyonel Başlangıç",
                Seviye = "Başlangıç",
                Sure = TimeSpan.FromMinutes(30),
                HedefKasGruplari = new []{"Tüm vücut"},
                GymEntegrasyonu = false,
                ExtremeSporModulu = false,
                DovusSanati = false,
                Hareketler = new []
                {
                    new EgzersizHareketi{Ad="Isınma Mobilite", SetSayisi=1, Tekrar=10, VideoUrl="https://video.yesil.app/mobility"},
                    new EgzersizHareketi{Ad="Vücut Ağırlığı Squat", SetSayisi=3, Tekrar=12},
                    new EgzersizHareketi{Ad="Plank", SetSayisi=3, Tekrar=45, VideoUrl="https://video.yesil.app/plank"}
                },
                KoçNotu = "Setler arasında nefes çalışmaları ekleyin."
            },
            new()
            {
                Baslik = "Dövüşçi Kondisyonu",
                Seviye = "İleri",
                Sure = TimeSpan.FromMinutes(55),
                HedefKasGruplari = new []{"Core", "Alt vücut", "Kardiyo"},
                GymEntegrasyonu = true,
                ExtremeSporModulu = true,
                DovusSanati = true,
                Hareketler = new []
                {
                    new EgzersizHareketi{Ad="Gölge Boksu", SetSayisi=5, Tekrar=3, VideoUrl="https://video.yesil.app/shadow", Ekipman="Eldiven"},
                    new EgzersizHareketi{Ad="Kettlebell Swings", SetSayisi=4, Tekrar=15, Ekipman="Kettlebell"},
                    new EgzersizHareketi{Ad="Box Jump", SetSayisi=4, Tekrar=12}
                },
                KoçNotu = "Sparring sonrası aktif toparlanma yapın."
            }
        };
    }
}
