namespace Yesil.Services;

public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task NavigateToAsync<TView>() where TView : Page
    {
        var page = _serviceProvider.GetRequiredService<TView>();
        if (Application.Current?.MainPage is Shell shell)
        {
            var route = typeof(TView).FullName ?? typeof(TView).Name;
            if (!Routing.IsRouteRegistered(route))
            {
                Routing.RegisterRoute(route, typeof(TView));
            }

            await shell.GoToAsync(route);
        }
        else
        {
            Application.Current!.MainPage = page;
        }
    }
}
