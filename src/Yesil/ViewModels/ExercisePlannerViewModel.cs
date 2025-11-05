using Yesil.Models;
using Yesil.Services;

namespace Yesil.ViewModels;

public class ExercisePlannerViewModel : BaseViewModel
{
    private readonly ExerciseService _exerciseService;
    private readonly StepCounterService _stepCounterService;

    public ObservableCollection<EgzersizPlanı> Planlar { get; } = new();
    public ObservableCollection<AktiviteKaydi> AktiviteOnerileri { get; } = new();

    private EgzersizPlanı? _seciliPlan;
    public EgzersizPlanı? SeciliPlan
    {
        get => _seciliPlan;
        set
        {
            if (SetProperty(ref _seciliPlan, value) && value is not null)
            {
                OnPlanSelected(value);
            }
        }
    }

    private int _gunlukAdimHedefi = 8000;
    public int GunlukAdimHedefi
    {
        get => _gunlukAdimHedefi;
        set
        {
            if (SetProperty(ref _gunlukAdimHedefi, value))
            {
                if (SeciliPlan is not null)
                {
                    OnPlanSelected(SeciliPlan);
                }
            }
        }
    }

    public ICommand PlanSecCommand { get; }

    public ExercisePlannerViewModel(ExerciseService exerciseService, StepCounterService stepCounterService)
    {
        _exerciseService = exerciseService;
        _stepCounterService = stepCounterService;

        foreach (var plan in _exerciseService.GetPlans())
        {
            Planlar.Add(plan);
        }

        PlanSecCommand = new Command<EgzersizPlanı>(plan => SeciliPlan = plan);
    }

    private void OnPlanSelected(EgzersizPlanı plan)
    {
        AktiviteOnerileri.Clear();
        var bugunAdim = _stepCounterService.GetTotalSteps(DateTime.Today);
        var hedef = Math.Max(GunlukAdimHedefi, bugunAdim);
        foreach (var aktivite in _exerciseService.GenerateStepRecommendations(hedef))
        {
            AktiviteOnerileri.Add(aktivite);
        }
    }
}
