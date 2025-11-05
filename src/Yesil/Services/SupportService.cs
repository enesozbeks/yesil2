using Yesil.Models;

namespace Yesil.Services;

public class SupportService
{
    private readonly ObservableCollection<UzmanDestegi> _uzmanlar = new();
    private readonly ObservableCollection<PsikolojikDestekSeansi> _seanslar = new();

    public ObservableCollection<UzmanDestegi> Uzmanlar => _uzmanlar;
    public ObservableCollection<PsikolojikDestekSeansi> Seanslar => _seanslar;

    public SupportService()
    {
        if (_uzmanlar.Count == 0)
        {
            _uzmanlar.Add(new UzmanDestegi
            {
                UzmanTuru = "Diyetisyen",
                AdSoyad = "Dyt. Nisanur Kılıç",
                LisansNo = "TR-56789",
                UzmanlikAlanlari = new[] {"Klinik beslenme", "Sporcu beslenmesi"},
                Iletisim = "video.yesil.app/nisanur",
                CalismaSaatleri = "Hafta içi 09:00-17:00"
            });

            _uzmanlar.Add(new UzmanDestegi
            {
                UzmanTuru = "Spor Psikoloğu",
                AdSoyad = "Dr. Emir Arslan",
                LisansNo = "TR-99881",
                UzmanlikAlanlari = new[] {"Performans psikolojisi", "Meditasyon"},
                Iletisim = "video.yesil.app/emir",
                CalismaSaatleri = "Çarşamba & Cuma 13:00-19:00"
            });
        }
    }

    public void PlanSession(PsikolojikDestekSeansi seans) => _seanslar.Add(seans);
}
