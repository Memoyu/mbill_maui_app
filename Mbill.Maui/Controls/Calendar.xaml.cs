namespace Mbill.Maui.Controls;

public partial class Calendar : ContentView
{

    public IList<string> DaysOfWeek
    {
        get => (IList<string>)GetValue(DaysOfWeekProperty);
        set => SetValue(DaysOfWeekProperty, value);
    }

    public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<string>), typeof(Calendar), new List<string> { "һ", "��", "��", "��", "��", "��", "��" });

    public Calendar()
    {
        InitializeComponent();
    }
}