using Yesil.Models;
using Yesil.Services;

namespace Yesil.ViewModels;

public class DietTrackerViewModel : BaseViewModel
{
    private readonly NutritionService _nutritionService;
    private readonly InventoryService _inventoryService;

    public ObservableCollection<FoodItem> Besinler { get; } = new();
    public ObservableCollection<BesinKaydi> OgunKayitlari { get; } = new();
    public ObservableCollection<BesinEnvanterOgeleri> Envanter => _inventoryService.Envanter;
    public ObservableCollection<AlisverisOgeleri> AlisverisListesi => _inventoryService.AlisverisListesi;

    private string _aramaMetni = string.Empty;
    public string AramaMetni
    {
        get => _aramaMetni;
        set
        {
            if (SetProperty(ref _aramaMetni, value))
            {
                PerformSearch(value);
            }
        }
    }

    private double _toplamKalori;
    public double ToplamKalori
    {
        get => _toplamKalori;
        private set => SetProperty(ref _toplamKalori, value);
    }

    public IAsyncCommand YiyecekEkleCommand { get; }
    public ICommand EnvantereEkleCommand { get; }
    public ICommand AlisverisGuncelleCommand { get; }

    public DietTrackerViewModel(NutritionService nutritionService, InventoryService inventoryService)
    {
        _nutritionService = nutritionService;
        _inventoryService = inventoryService;

        foreach (var food in _nutritionService.GetPopularFoods())
        {
            Besinler.Add(food);
        }

        if (!AlisverisListesi.Any())
        {
            AlisverisListesi.Add(new AlisverisOgeleri { Ad = "Organik yulaf", Miktar = 2, Birim = "Paket" });
            AlisverisListesi.Add(new AlisverisOgeleri { Ad = "Kefir", Miktar = 1, Birim = "Şişe" });
        }

        YiyecekEkleCommand = new AsyncCommand(OnYiyecekEkleAsync);
        EnvantereEkleCommand = new Command<FoodItem>(OnEnvantereEkle);
        AlisverisGuncelleCommand = new Command<AlisverisOgeleri>(item => item.Tamamlandi = !item.Tamamlandi);
    }

    private void PerformSearch(string query)
    {
        Besinler.Clear();
        var results = string.IsNullOrWhiteSpace(query)
            ? _nutritionService.GetPopularFoods()
            : _nutritionService.SearchFoods(query);

        foreach (var food in results)
        {
            Besinler.Add(food);
        }
    }

    private async Task OnYiyecekEkleAsync(object? parameter)
    {
        if (parameter is not FoodItem food)
        {
            return;
        }

        var kayit = new BesinKaydi
        {
            Tarih = DateTime.Today,
            Besin = food,
            MiktarGram = food.PorsiyonGram,
            Ogun = "Özel",
            Not = "Hızlı ekleme"
        };

        OgunKayitlari.Add(kayit);
        ToplamKalori = _nutritionService.CalculateCalories(OgunKayitlari);
        await Task.CompletedTask;
    }

    private void OnEnvantereEkle(FoodItem food)
    {
        _inventoryService.AddInventoryItem(new BesinEnvanterOgeleri
        {
            Ad = food.Ad,
            Miktar = 1,
            Birim = "Porsiyon",
            YenidenSiparisGerekli = false
        });
    }
}
