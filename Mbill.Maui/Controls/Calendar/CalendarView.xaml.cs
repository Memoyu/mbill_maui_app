using Mbill.Maui.Controls.Calendar.Model;

namespace Mbill.Maui.Controls.Calendar;

public partial class CalendarView : ContentView
{

    public IList<string> DaysOfWeek
    {
        get => (IList<string>)GetValue(DaysOfWeekProperty);
        set => SetValue(DaysOfWeekProperty, value);
    }

    public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<string>), typeof(CalendarView), new List<string> { "一", "二", "三", "四", "五", "六", "日" });


    public IEnumerable<CalendarDay> Days
    {
        get => (IEnumerable<CalendarDay>)GetValue(DaysProperty);
        set => SetValue(DaysProperty, value);
    }
    public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<CalendarDay>), typeof(CalendarView), propertyChanged: DaysPropertyChanged);
    public CalendarView()
    {
        InitializeComponent();
    }

    private static void DaysPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        CalendarView control = (CalendarView)bindable;
        IEnumerable<CalendarDay> newDays = (IEnumerable<CalendarDay>)newValue;
        control.MainDaysView.Days = newDays;
    }
}