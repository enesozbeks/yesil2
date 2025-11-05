namespace Yesil.Services;

public class NavigationService
{
    private static readonly object RoutesLock = new();
    private static readonly HashSet<string> RegisteredRoutes = new();

    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task NavigateToAsync<TView>() where TView : Page
    {
        var page = _serviceProvider.GetRequiredService<TView>();
        var route = typeof(TView).Name;

        var shouldRegister = false;
        lock (RoutesLock)
        {
            if (RegisteredRoutes.Add(route))
            {
                shouldRegister = true;
            }
        }

        if (shouldRegister)
        {
            Routing.RegisterRoute(route, typeof(TView));
        }

        if (Shell.Current is not null)
        {
            await Shell.Current.GoToAsync(route);
            return;
        }

        var window = Application.Current?.Windows.FirstOrDefault();
        if (window is not null)
        {
            window.Page = page;
        }
    }
}
