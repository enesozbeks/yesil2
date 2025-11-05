namespace Yesil.Models;

public class YapayZekaOnerisi
{
    public string Baslik { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public IReadOnlyList<string> DayanakVerileri { get; set; } = Array.Empty<string>();
    public string Oncelik { get; set; } = string.Empty;
}

public class ToplulukGirdisi
{
    public string KullaniciAdi { get; set; } = string.Empty;
    public string Baslik { get; set; } = string.Empty;
    public string Icerik { get; set; } = string.Empty;
    public IReadOnlyList<string> Etiketler { get; set; } = Array.Empty<string>();
    public DateTime PaylasimTarihi { get; set; } = DateTime.Now;
    public int Begeni { get; set; }
    public bool UzmanOnayli { get; set; }
}

public class UzmanDestegi
{
    public string UzmanTuru { get; set; } = string.Empty;
    public string AdSoyad { get; set; } = string.Empty;
    public string LisansNo { get; set; } = string.Empty;
    public IReadOnlyList<string> UzmanlikAlanlari { get; set; } = Array.Empty<string>();
    public string Iletisim { get; set; } = string.Empty;
    public string CalismaSaatleri { get; set; } = string.Empty;
}

public class PsikolojikDestekSeansi
{
    public string TerapiTuru { get; set; } = string.Empty;
    public string Danisman { get; set; } = string.Empty;
    public DateTime Tarih { get; set; } = DateTime.Now;
    public string Durum { get; set; } = "Planlandı";
    public string OdakNoktasi { get; set; } = string.Empty;
}
