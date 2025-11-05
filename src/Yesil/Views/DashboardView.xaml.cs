using Yesil.ViewModels;

namespace Yesil.Views;

public partial class DashboardView : ContentPage
{
    public DashboardView(DashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Loaded += async (_, _) => await viewModel.RefreshDashboardCommand.ExecuteAsync();
    }
}
