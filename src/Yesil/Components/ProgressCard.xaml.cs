namespace Yesil.Components;

public partial class ProgressCard : ContentView
{
    public ProgressCard()
    {
        InitializeComponent();
    }
}

public class ProgressCardViewModel : BindableObject
{
    public string Baslik
    {
        get => (string)GetValue(BaslikProperty);
        set => SetValue(BaslikProperty, value);
    }

    public static readonly BindableProperty BaslikProperty =
        BindableProperty.Create(nameof(Baslik), typeof(string), typeof(ProgressCardViewModel), string.Empty);

    public string AltBaslik
    {
        get => (string)GetValue(AltBaslikProperty);
        set => SetValue(AltBaslikProperty, value);
    }

    public static readonly BindableProperty AltBaslikProperty =
        BindableProperty.Create(nameof(AltBaslik), typeof(string), typeof(ProgressCardViewModel), string.Empty);

    public Color RozetRenk
    {
        get => (Color)GetValue(RozetRenkProperty);
        set => SetValue(RozetRenkProperty, value);
    }

    public static readonly BindableProperty RozetRenkProperty =
        BindableProperty.Create(nameof(RozetRenk), typeof(Color), typeof(ProgressCardViewModel), Color.FromArgb("#1FAB54"));

    public string RozetMetni
    {
        get => (string)GetValue(RozetMetniProperty);
        set => SetValue(RozetMetniProperty, value);
    }

    public static readonly BindableProperty RozetMetniProperty =
        BindableProperty.Create(nameof(RozetMetni), typeof(string), typeof(ProgressCardViewModel), string.Empty);
}
