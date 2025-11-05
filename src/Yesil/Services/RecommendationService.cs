using Yesil.Models;

namespace Yesil.Services;

public class RecommendationService
{
    private readonly NutritionService _nutritionService;
    private readonly ExerciseService _exerciseService;
    private readonly HealthDataService _healthDataService;
    private readonly SleepService _sleepService;

    public RecommendationService(
        NutritionService nutritionService,
        ExerciseService exerciseService,
        HealthDataService healthDataService,
        SleepService sleepService)
    {
        _nutritionService = nutritionService;
        _exerciseService = exerciseService;
        _healthDataService = healthDataService;
        _sleepService = sleepService;
    }

    public IEnumerable<YapayZekaOnerisi> GenerateHolisticRecommendations()
    {
        var vitaminEksikleri = _nutritionService.PredictVitaminDeficiencies(_healthDataService.GetBloodMarkers());
        foreach (var eksik in vitaminEksikleri)
        {
            yield return new YapayZekaOnerisi
            {
                Baslik = $"Vitamin {eksik.Vitamin} takviyesi",
                Aciklama = eksik.TibbiNot,
                DayanakVerileri = new[] {$"Belirti: {eksik.Belirti}", $"Önerilen besinler: {eksik.OnErenBesinler}"},
                Oncelik = "Yüksek"
            };
        }

        var ortalamaUyku = _sleepService.CalculateAverageSleep(_healthDataService.GetSleepRecords());
        yield return new YapayZekaOnerisi
        {
            Baslik = "Uyku optimizasyonu",
            Aciklama = _sleepService.GetSleepAdvice(ortalamaUyku),
            DayanakVerileri = new[] {$"Ortalama uyku: {ortalamaUyku.TotalHours:F1} saat"},
            Oncelik = "Orta"
        };

        var ileriPlan = _exerciseService.GetPlanByLevel("İleri");
        if (ileriPlan is not null)
        {
            yield return new YapayZekaOnerisi
            {
                Baslik = "Fonksiyonel dövüş antremanı",
                Aciklama = ileriPlan.KoçNotu,
                DayanakVerileri = ileriPlan.Hareketler.Select(h => h.Ad).ToArray(),
                Oncelik = "Esnek"
            };
        }
    }
}
