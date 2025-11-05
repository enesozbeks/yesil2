using Yesil.ViewModels;

namespace Yesil.Views;

public partial class CommunityView : ContentPage
{
    public CommunityView(CommunityViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
