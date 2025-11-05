using Yesil.Components;
using Yesil.Models;
using Yesil.Services;

namespace Yesil.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    private readonly WeatherService _weatherService;
    private readonly RecommendationService _recommendationService;
    private readonly StepCounterService _stepCounterService;
    private readonly HealthDataService _healthDataService;
    private readonly SleepService _sleepService;

    private HavaDurumu? _havaDurumu;
    public HavaDurumu? HavaDurumu
    {
        get => _havaDurumu;
        private set => SetProperty(ref _havaDurumu, value);
    }

    public ObservableCollection<ProgressCardViewModel> Kartlar { get; } = new();
    public ObservableCollection<YapayZekaOnerisi> Oneriler { get; } = new();

    public DashboardViewModel(
        WeatherService weatherService,
        RecommendationService recommendationService,
        StepCounterService stepCounterService,
        HealthDataService healthDataService,
        SleepService sleepService)
    {
        _weatherService = weatherService;
        _recommendationService = recommendationService;
        _stepCounterService = stepCounterService;
        _healthDataService = healthDataService;
        _sleepService = sleepService;

        LoadWeatherCommand = new AsyncCommand(LoadWeatherAsync);
        RefreshDashboardCommand = new AsyncCommand(RefreshAsync);
    }

    public IAsyncCommand LoadWeatherCommand { get; }
    public IAsyncCommand RefreshDashboardCommand { get; }

    private async Task LoadWeatherAsync()
    {
        HavaDurumu = await _weatherService.GetWeatherAsync("İstanbul");
    }

    private async Task RefreshAsync()
    {
        await LoadWeatherAsync();
        Kartlar.Clear();

        Kartlar.Add(new ProgressCardViewModel
        {
            Baslik = "Günlük Adım",
            AltBaslik = $"{_stepCounterService.GetTotalSteps(DateTime.Today)} adım",
            RozetMetni = "Hedef"
        });

        var uyku = _healthDataService.GetSleepRecords();
        var ortalamaUyku = _sleepService.CalculateAverageSleep(uyku);
        Kartlar.Add(new ProgressCardViewModel
        {
            Baslik = "Ortalama Uyku",
            AltBaslik = $"{ortalamaUyku.TotalHours:F1} saat",
            RozetMetni = "Dengeli"
        });

        Oneriler.Clear();
        foreach (var oner in _recommendationService.GenerateHolisticRecommendations())
        {
            Oneriler.Add(oner);
        }
    }
}
