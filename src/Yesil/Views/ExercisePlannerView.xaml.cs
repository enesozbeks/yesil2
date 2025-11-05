using Yesil.ViewModels;

namespace Yesil.Views;

public partial class ExercisePlannerView : ContentPage
{
    public ExercisePlannerView(ExercisePlannerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
