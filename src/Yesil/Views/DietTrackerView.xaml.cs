using Yesil.ViewModels;

namespace Yesil.Views;

public partial class DietTrackerView : ContentPage
{
    public DietTrackerView(DietTrackerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
