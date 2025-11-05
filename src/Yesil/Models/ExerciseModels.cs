namespace Yesil.Models;

public class EgzersizPlanı
{
    public string Baslik { get; set; } = string.Empty;
    public string Seviye { get; set; } = string.Empty;
    public TimeSpan Sure { get; set; }
    public IReadOnlyList<string> HedefKasGruplari { get; set; } = Array.Empty<string>();
    public IReadOnlyList<EgzersizHareketi> Hareketler { get; set; } = Array.Empty<EgzersizHareketi>();
    public string KoçNotu { get; set; } = string.Empty;
    public bool GymEntegrasyonu { get; set; }
    public bool ExtremeSporModulu { get; set; }
    public bool DovusSanati { get; set; }
}

public class EgzersizHareketi
{
    public string Ad { get; set; } = string.Empty;
    public int SetSayisi { get; set; }
    public int Tekrar { get; set; }
    public string VideoUrl { get; set; } = string.Empty;
    public string Ekipman { get; set; } = string.Empty;
}

public class AktiviteKaydi
{
    public DateTime Tarih { get; set; } = DateTime.Today;
    public string AktiviteAd { get; set; } = string.Empty;
    public int AdimSayisi { get; set; }
    public double YakilanKalori { get; set; }
    public TimeSpan Sure { get; set; }
    public string Not { get; set; } = string.Empty;
}
