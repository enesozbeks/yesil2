using Yesil.ViewModels;

namespace Yesil.Views;

public partial class SupportCenterView : ContentPage
{
    public SupportCenterView(SupportCenterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
