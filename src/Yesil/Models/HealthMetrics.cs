namespace Yesil.Models;

public class HavaDurumu
{
    public DateTime Tarih { get; set; } = DateTime.Today;
    public string Konum { get; set; } = string.Empty;
    public string Durum { get; set; } = string.Empty;
    public double SıcaklıkC { get; set; }
    public double Nem { get; set; }
    public double Ruzgar { get; set; }
}

public class KanDegeri
{
    public string Ad { get; set; } = string.Empty;
    public double Deger { get; set; }
    public string Birim { get; set; } = string.Empty;
    public string ReferansAralik { get; set; } = string.Empty;
    public string Yorum { get; set; } = string.Empty;
}

public class HormonDegeri
{
    public string Ad { get; set; } = string.Empty;
    public double Deger { get; set; }
    public string Birim { get; set; } = string.Empty;
    public string GunlukDalgalanma { get; set; } = string.Empty;
}

public class UykuKaydi
{
    public DateTime Baslangic { get; set; } = DateTime.Now.AddHours(-7);
    public DateTime Bitis { get; set; } = DateTime.Now;
    public TimeSpan Sure => Bitis - Baslangic;
    public int KaliteSkoru { get; set; }
    public string Not { get; set; } = string.Empty;
}

public class VitaminEksikligi
{
    public string Vitamin { get; set; } = string.Empty;
    public string Belirti { get; set; } = string.Empty;
    public string OnErenBesinler { get; set; } = string.Empty;
    public string TibbiNot { get; set; } = string.Empty;
}

public class Hedef
{
    public string Baslik { get; set; } = string.Empty;
    public string Kategori { get; set; } = string.Empty;
    public DateTime Baslangic { get; set; } = DateTime.Today;
    public DateTime Bitis { get; set; } = DateTime.Today.AddDays(30);
    public bool Tamamlandi { get; set; }
    public Reward? Odul { get; set; }
}

public class Reward
{
    public string Ad { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public int Puan { get; set; }
}
