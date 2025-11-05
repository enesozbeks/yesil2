namespace Yesil.Models;

public record NutrientDetail(
    string Ad,
    double Deger,
    string Birim,
    string? Not = null);

public record HormonEtkisi(string HormonAdi, string Etki); 

public record KimyasalBilesen(string Ad, string Kaynak, string Etki);

public class FoodItem
{
    public string Ad { get; init; } = string.Empty;
    public double PorsiyonGram { get; init; }
    public double Kalori { get; init; }
    public double Natureskor { get; init; }
    public IReadOnlyList<NutrientDetail> Vitaminler { get; init; } = Array.Empty<NutrientDetail>();
    public IReadOnlyList<NutrientDetail> Mineraller { get; init; } = Array.Empty<NutrientDetail>();
    public IReadOnlyList<NutrientDetail> Makrobesinler { get; init; } = Array.Empty<NutrientDetail>();
    public IReadOnlyList<HormonEtkisi> HormonEtkileri { get; init; } = Array.Empty<HormonEtkisi>();
    public IReadOnlyList<KimyasalBilesen> KimyasalIcerik { get; init; } = Array.Empty<KimyasalBilesen>();
    public string GelenekselBilgi { get; init; } = string.Empty;
    public string ModernBilgi { get; init; } = string.Empty;
    public string Kategori { get; init; } = string.Empty;
    public IReadOnlyList<string> HastalikFaydalari { get; init; } = Array.Empty<string>();
}
