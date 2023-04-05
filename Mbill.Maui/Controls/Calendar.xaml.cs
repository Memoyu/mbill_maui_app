namespace Mbill.Maui.Controls;

public partial class Calendar : ContentView
{

    public IList<string> DaysOfWeek
    {
        get => (IList<string>)GetValue(DaysOfWeekProperty);
        set => SetValue(DaysOfWeekProperty, value);
    }

    public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<string>), typeof(Calendar), new List<string> { "一", "二", "三", "四", "五", "六", "日" });

    public Calendar()
    {
        InitializeComponent();
    }
}