namespace Yesil.Behaviors;

public class CheckedChangedToCommandBehavior : Behavior<CheckBox>
{
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command), typeof(ICommand), typeof(CheckedChangedToCommandBehavior));

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter), typeof(object), typeof(CheckedChangedToCommandBehavior), null);

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    protected override void OnAttachedTo(CheckBox bindable)
    {
        base.OnAttachedTo(bindable);
        bindable.CheckedChanged += OnCheckedChanged;
        bindable.BindingContextChanged += OnBindingContextChanged;
    }

    protected override void OnDetachingFrom(CheckBox bindable)
    {
        base.OnDetachingFrom(bindable);
        bindable.CheckedChanged -= OnCheckedChanged;
        bindable.BindingContextChanged -= OnBindingContextChanged;
    }

    private void OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        if (sender is not CheckBox checkBox)
        {
            return;
        }

        var parameter = CommandParameter ?? checkBox.BindingContext;

        if (Command?.CanExecute(parameter) ?? false)
        {
            Command.Execute(parameter);
        }
    }

    private void OnBindingContextChanged(object? sender, EventArgs e)
    {
        if (sender is BindableObject bindable)
        {
            BindingContext = bindable.BindingContext;
        }
    }
}
