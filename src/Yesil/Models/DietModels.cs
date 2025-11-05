namespace Yesil.Models;

public class DiyetHedefi
{
    public string Baslik { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public double HedefKalori { get; set; }
    public double HedefProtein { get; set; }
    public double HedefSu { get; set; }
    public IReadOnlyList<string> Oduller { get; set; } = Array.Empty<string>();
}

public class BesinKaydi
{
    public DateTime Tarih { get; set; } = DateTime.Today;
    public FoodItem Besin { get; set; } = new();
    public double MiktarGram { get; set; }
    public string Ogun { get; set; } = string.Empty;
    public string Not { get; set; } = string.Empty;
}

public class BesinEnvanterOgeleri
{
    public string Ad { get; set; } = string.Empty;
    public double Miktar { get; set; }
    public string Birim { get; set; } = string.Empty;
    public DateTime? SonKullanma { get; set; }
    public bool YenidenSiparisGerekli { get; set; }
}

public class AlisverisOgeleri
{
    public string Ad { get; set; } = string.Empty;
    public double Miktar { get; set; }
    public string Birim { get; set; } = string.Empty;
    public bool Tamamlandi { get; set; }
}
