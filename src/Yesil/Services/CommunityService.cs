using Yesil.Models;

namespace Yesil.Services;

public class CommunityService
{
    private readonly ObservableCollection<ToplulukGirdisi> _girdiler = new();

    public ObservableCollection<ToplulukGirdisi> GetEntries() => _girdiler;

    public void SeedDemoEntries()
    {
        if (_girdiler.Count > 0)
        {
            return;
        }

        _girdiler.Add(new ToplulukGirdisi
        {
            KullaniciAdi = "sporcuAyse",
            Baslik = "Bitkisel protein favorilerim",
            Icerik = "Nohut, mercimek ve spirulina ile enerji topluyorum!",
            Etiketler = new[] {"protein", "vegan"},
            Begeni = 124,
            UzmanOnayli = true
        });

        _girdiler.Add(new ToplulukGirdisi
        {
            KullaniciAdi = "diyetisyenCan",
            Baslik = "Intermittent fasting önerileri",
            Icerik = "16:8 uygulayan danışanlarım için örnek beslenme planı paylaşıyorum.",
            Etiketler = new[] {"oruç", "metabolizma"},
            Begeni = 87,
            UzmanOnayli = true
        });
    }
}
