using Yesil.Models;
using Yesil.Services;

namespace Yesil.ViewModels;

public class SupportCenterViewModel : BaseViewModel
{
    private readonly SupportService _supportService;

    public ObservableCollection<UzmanDestegi> Uzmanlar => _supportService.Uzmanlar;
    public ObservableCollection<PsikolojikDestekSeansi> Seanslar => _supportService.Seanslar;

    public ICommand SeansPlanlaCommand { get; }

    public SupportCenterViewModel(SupportService supportService)
    {
        _supportService = supportService;
        SeansPlanlaCommand = new Command(OnSeansPlanla);
    }

    private void OnSeansPlanla(object? parameter)
    {
        var uzman = Uzmanlar.FirstOrDefault();
        if (uzman is null)
        {
            return;
        }

        _supportService.PlanSession(new PsikolojikDestekSeansi
        {
            Danisman = uzman.AdSoyad,
            TerapiTuru = uzman.UzmanTuru,
            Durum = "Planlandı",
            OdakNoktasi = "Stres yönetimi"
        });
    }
}
