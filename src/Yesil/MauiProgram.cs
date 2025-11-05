namespace Yesil;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        builder.Services
            .AddSingleton<Services.NavigationService>()
            .AddSingleton<Services.NutritionService>()
            .AddSingleton<Services.ExerciseService>()
            .AddSingleton<Services.HealthDataService>()
            .AddSingleton<Services.WeatherService>()
            .AddSingleton<Services.StepCounterService>()
            .AddSingleton<Services.SleepService>()
            .AddSingleton<Services.InventoryService>()
            .AddSingleton<Services.RecommendationService>()
            .AddSingleton<Services.CommunityService>()
            .AddSingleton<Services.SupportService>()
            .AddSingleton<ViewModels.DashboardViewModel>()
            .AddSingleton<ViewModels.DietTrackerViewModel>()
            .AddSingleton<ViewModels.ExercisePlannerViewModel>()
            .AddSingleton<ViewModels.CommunityViewModel>()
            .AddSingleton<ViewModels.SupportCenterViewModel>();

        builder.Services
            .AddTransient<Views.DashboardView>()
            .AddTransient<Views.DietTrackerView>()
            .AddTransient<Views.ExercisePlannerView>()
            .AddTransient<Views.CommunityView>()
            .AddTransient<Views.SupportCenterView>();

        return builder.Build();
    }
}
