using Yesil.Models;

namespace Yesil.Services;

public class NutritionService
{
    private readonly List<FoodItem> _besinler;

    public NutritionService()
    {
        _besinler = SeedFoods();
    }

    public IReadOnlyList<FoodItem> GetPopularFoods() => _besinler;

    public IEnumerable<FoodItem> SearchFoods(string query)
        => _besinler.Where(f => f.Ad.Contains(query, StringComparison.OrdinalIgnoreCase));

    public double CalculateCalories(IEnumerable<BesinKaydi> kayitlar)
        => kayitlar.Sum(k => (k.Besin.Kalori / k.Besin.PorsiyonGram) * k.MiktarGram);

    public IEnumerable<VitaminEksikligi> PredictVitaminDeficiencies(IEnumerable<KanDegeri> kanDegerleri)
    {
        foreach (var kan in kanDegerleri)
        {
            if (kan.Ad.Contains("Vitamin D", StringComparison.OrdinalIgnoreCase) && kan.Deger < 20)
            {
                yield return new VitaminEksikligi
                {
                    Vitamin = "D",
                    Belirti = "Yorgunluk, kemik ağrısı",
                    OnErenBesinler = "Somon, yumurta, güneş ışığı",
                    TibbiNot = "Doktor kontrolünde takviye alınız"
                };
            }
        }
    }

    private static List<FoodItem> SeedFoods()
    {
        return new List<FoodItem>
        {
            new()
            {
                Ad = "Yeşil Smoothie",
                PorsiyonGram = 300,
                Kalori = 210,
                Natureskor = 92,
                Kategori = "İçecek",
                Makrobesinler = new[]
                {
                    new NutrientDetail("Protein", 12, "g"),
                    new NutrientDetail("Karbonhidrat", 24, "g"),
                    new NutrientDetail("Yağ", 6, "g")
                },
                Vitaminler = new[]
                {
                    new NutrientDetail("Vitamin C", 70, "mg", "Bağışıklığı destekler"),
                    new NutrientDetail("Vitamin K", 110, "µg")
                },
                Mineraller = new[]
                {
                    new NutrientDetail("Demir", 4.2, "mg"),
                    new NutrientDetail("Magnezyum", 80, "mg")
                },
                HormonEtkileri = new[]
                {
                    new HormonEtkisi("Kortizol", "Stresi azaltır"),
                    new HormonEtkisi("Serotonin", "Mutluluk hormonu desteği")
                },
                KimyasalIcerik = new[]
                {
                    new KimyasalBilesen("Klorofil", "Ispanak", "Detoks etkisi"),
                    new KimyasalBilesen("Polifenoller", "Yeşil çay", "Antioksidan" )
                },
                GelenekselBilgi = "Osmanlı tıbbında enerji verici olarak önerilir.",
                ModernBilgi = "Prebiyotik lifler bağırsak sağlığını destekler.",
                HastalikFaydalari = new [] {"Anemi", "Hipertansiyon", "İnsülin direnci"}
            },
            new()
            {
                Ad = "Fermente Kefir",
                PorsiyonGram = 200,
                Kalori = 140,
                Natureskor = 88,
                Kategori = "Süt Ürünü",
                Makrobesinler = new[]
                {
                    new NutrientDetail("Protein", 9, "g"),
                    new NutrientDetail("Karbonhidrat", 10, "g"),
                    new NutrientDetail("Yağ", 5, "g")
                },
                Vitaminler = new[]
                {
                    new NutrientDetail("B12", 1.6, "µg"),
                    new NutrientDetail("B2", 0.2, "mg")
                },
                Mineraller = new[]
                {
                    new NutrientDetail("Kalsiyum", 300, "mg"),
                    new NutrientDetail("Fosfor", 240, "mg")
                },
                HormonEtkileri = new[]
                {
                    new HormonEtkisi("GABA", "Sinir sistemini yatıştırır")
                },
                GelenekselBilgi = "Anadolu tıbbında sindirim düzenleyici.",
                ModernBilgi = "Probiyotik içeriği bağışıklığı kuvvetlendirir.",
                HastalikFaydalari = new [] {"IBS", "Bağışıklık düşüklüğü"}
            }
        };
    }
}
