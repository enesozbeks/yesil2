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
        var window = Application.Current?.Windows.FirstOrDefault();

        if (window?.Page is Shell shell)
        {
            var route = typeof(TView).FullName ?? typeof(TView).Name;
            if (!Routing.TryGetRoute(route, out _))
            {
                Routing.RegisterRoute(route, typeof(TView));
            }

            await shell.GoToAsync(route);
        }
        else if (window is not null)
        {
            window.Page = page;
        }
    }
}
